# How to change the group header color on tap in Xamarin.Forms ListView (SfListView)

You can change the background color of group header of [SfListview](https://help.syncfusion.com/xamarin/listview/getting-started) at runtime with the help of [converter](https://docs.microsoft.com/en-us/dotnet/api/system.windows.data.ivalueconverter?view=netcore-3.1).

You can also refer the following article.

https://www.syncfusion.com/kb/11952/how-to-change-the-group-header-color-on-tap-in-xamarin-forms-listview-sflistview

**C#**

Converter returns the background color for the group header based on group items.

``` c#
public class GroupHeaderConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
            return Color.Yellow;
        var items = (value as GroupResult).Items.ToList<Contacts>().ToList();
        if (items[0].IsHeaderTapped)
            return Color.Green;
        else
            return Color.Yellow;
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
```

**C#**

In [ItemTapped](https://help.syncfusion.com/cr/xamarin/Syncfusion.ListView.XForms.ItemTappedEventArgs.html) Event, change the model property value for the respective group header and refresh the listview item by using [Listview.RefreshListViewItem](https://help.syncfusion.com/cr/xamarin/Syncfusion.ListView.XForms.SfListView.html#Syncfusion_ListView_XForms_SfListView_RefreshListViewItem_System_Int32_System_Int32_System_Boolean_)

``` c#
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
```

**XAML**

Bind the BackgroundColor property with **GroupHeaderConverter** in [GroupHeaderTemplate](https://help.syncfusion.com/cr/xamarin/Syncfusion.ListView.XForms.SfListView.html#Syncfusion_ListView_XForms_SfListView_GroupHeaderTemplate).

``` xml
<syncfusion:SfListView.GroupHeaderTemplate>
    <DataTemplate >
        <Grid x:Name="headergrid" BackgroundColor="{Binding .,
            Converter={StaticResource GroupHeaderConverter}}" >
            <Label x:Name="label" Text="{Binding Key}"  />
        </Grid>
    </DataTemplate>
</syncfusion:SfListView.GroupHeaderTemplate>
```

**Output**

![GroupHeaderColorOnTap](https://github.com/SyncfusionExamples/group-header-color-on-tap-listview-xamarin/blob/master/ScreenShot/GroupHeaderColorOnTap.gif)
