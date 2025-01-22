using Get.Data.Properties;
using static Get.Data.Properties.AutoTyper;
namespace Get.UI.Data;
public partial class ThemeResources
{
    public static IReadOnlyProperty<T> Get<T>(string resourcesName, FrameworkElement ele)
    {
        if (!ele.Resources.TryGetValue(resourcesName, out var val)) val = Application.Current.Resources[resourcesName];
        var prop = new Property<T>((T)val);
        ele.ActualThemeChanged += delegate
        {
            if (!ele.Resources.TryGetValue(resourcesName, out var val)) val = Application.Current.Resources[resourcesName];
            prop.Value = (T)val;
        };
        return AutoReadOnly<T>(prop);
    }
    public static IReadOnlyProperty<T> Create<T>(FrameworkElement ele, T darkResource, T lightResource)
    {
        var prop = new Property<T>(ele.ActualTheme is ElementTheme.Dark ? darkResource : lightResource);
        ele.ActualThemeChanged += delegate
        {
            prop.Value = ele.ActualTheme is ElementTheme.Dark ? darkResource : lightResource;
        };
        return AutoReadOnly<T>(prop);
    }
}