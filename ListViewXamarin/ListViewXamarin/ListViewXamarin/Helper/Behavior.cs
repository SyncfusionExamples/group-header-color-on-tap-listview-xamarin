using Syncfusion.DataSource.Extensions;
using Syncfusion.GridCommon.ScrollAxis;
using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Control.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewXamarin
{
    public class Behavior : Behavior<ContentPage>
    {
        SfListView listView;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            listView = bindable.FindByName<SfListView>("listView");
            listView.ItemTapped += ListView_ItemTapped;
            base.OnAttachedTo(bindable);
        }

        private void ListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            var groupResult = e.ItemData as GroupResult;
            if (e.ItemType is ItemType.GroupHeader)
            {
                foreach (var item in groupResult.Items)
                {
                    if (!(item as Contacts).IsHeaderTapped)
                        (item as Contacts).IsHeaderTapped = true;
                    else
                        (item as Contacts).IsHeaderTapped = false;
                }
                listView.RefreshListViewItem(-1, -1, true);
            }
        }
        protected override void OnDetachingFrom(BindableObject bindable)
        {
            base.OnDetachingFrom(bindable);
            listView.ItemTapped -= ListView_ItemTapped;
        }
    }
}