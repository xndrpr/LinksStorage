using DevExpress.Mvvm;
using LinksStorage.DAL.Entities;
using LinksStorage.Domain.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace LinksStorage.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly ILinksService _service;

        public string Name { get; set; }
        public string Url { get; set; }
        public State ActionButtonState { get; set; } = State.Add;
        public IEnumerable<LinkEntity>? Links { get; set; } = new List<LinkEntity>();
        public LinkEntity SelectedItem { get; set; }


        public MainViewModel(ILinksService service)
        {
            _service = service;

            GetLinks();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
        }

        private void TimerTick(object? sernder, EventArgs e)
        {
            GetLinks();
        }

        #region Commands

        public ICommand ActionButtonCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (Url == null) return;

                    if (Url.StartsWith("https://") == false
                        && Url.StartsWith("http://") == false)
                    {
                        MessageBox.Show("Link type not supported", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                        return;
                    }
                    var domain = new Uri(Url).Host;
                    var iconName = domain + ".ico";

                    var iconPath = @$"{Directory.GetCurrentDirectory()}\Icons";
                    if (Directory.Exists(iconPath) == false)
                        Directory.CreateDirectory(iconPath);

                    var client = new WebClient();
                    client.DownloadFileAsync(new Uri($"http://www.google.com/s2/favicons?domain={domain}"), @$"{Directory.GetCurrentDirectory()}\Icons\{iconName}");
                        
                    if (ActionButtonState == State.Add)
                    {
                        _service.Add(new LinkEntity
                        {
                            Name = Name,
                            Url = Url,
                            CreationDate = DateTime.Now.ToShortDateString(),
                            Icon = @$"{iconPath}\{iconName}"
                        });

                        Name = string.Empty;
                        Url = string.Empty;
                    }
                    else
                    {
                        var newEntity = SelectedItem;
                        newEntity.Name = Name;
                        newEntity.Url = Url;

                        _service.Update(newEntity);

                        Name = string.Empty;
                        Url = string.Empty;

                        ActionButtonState = State.Add;
                    }
                    GetLinks();
                });
            }
        }

        public ICommand CopyUrlCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Clipboard.SetText(SelectedItem.Url);
                });
            }
        }
        public ICommand EditLinkCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    ActionButtonState = State.Save;

                    Name = SelectedItem.Name;
                    Url = SelectedItem.Url;
                });
            }
        }
        public ICommand DeleteLinkCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _service.Remove(SelectedItem);

                    GetLinks();

                    if (ActionButtonState == State.Save)
                    {
                        Name = string.Empty;
                        Url = string.Empty;

                        ActionButtonState = State.Add;
                    }
                });
            }
        }

        #endregion


        private async void GetLinks()
        {
            Links = await _service.GetAll();
        }
    }
}
