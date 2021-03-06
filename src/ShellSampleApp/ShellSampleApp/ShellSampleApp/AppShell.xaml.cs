﻿using ShellSampleApp.Views;
using System;
using Xamarin.Forms;

namespace ShellSampleApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        // 追加
        protected override bool OnBackButtonPressed()
        {
            if (CurrentState.Location.OriginalString == "//AboutPage")
            {
                // トップページならそのまま終わる
                return base.OnBackButtonPressed();
            }
            else
            {
                // トップページ以外の場合はトップページに戻る
                _ = GoToAsync("//AboutPage").ContinueWith(async (result) =>
                {
                    if (result.Exception != null)
                    {
                        // エラーが起きてたら何か処理
                        await Device.InvokeOnMainThreadAsync(async () =>
                        {
                            await DisplayAlert("Error", result.Exception.Message, "Close");
                        });
                    }
                });
                return true;
            }
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
