using Get.Data.Bindings;
using Get.Data.Bindings.Linq;
using Get.Data.DataTemplates;
using Get.Data.Properties;

namespace Get.UI.Data;

public class ContentBundleControl : TemplateControl<Border>
{
    public Property<ContentBundle?> ContentBundleProperty { get; } = new(default);
    protected override void Initialize(Border rootElement)
    {
        var prop = ContentBundleProperty.SelectPath(x => x?.OutputContent ?? new NullProperty());
        prop.ValueChanged += (_, child) => rootElement.Child = child;
        rootElement.Child = prop.CurrentValue;
    }
    public ContentBundleControl()
    {
    }
}
readonly struct NullProperty : IReadOnlyProperty<UIElement?>
{
    UIElement? IReadOnlyDataBinding<UIElement?>.CurrentValue => null;

    event Action INotifyBinding<UIElement?>.RootChanged
    {
        add { }
        remove { }
    }

    event ValueChangingHandler<UIElement> INotifyBinding<UIElement?>.ValueChanging
    {
        add { }
        remove { }
    }

    event ValueChangedHandler<UIElement> INotifyBinding<UIElement?>.ValueChanged
    {
        add { }
        remove { }
    }

    void IReadOnlyProperty<UIElement>.BindOneWayToSource(IBinding<UIElement> binding) { }
}