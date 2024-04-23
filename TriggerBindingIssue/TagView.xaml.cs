namespace TriggerBindingIssue;

public partial class TagView : StackLayout
{
    public static readonly BindableProperty MyTagProperty = BindableProperty.Create(nameof(MyTagProperty), typeof(TagType), typeof(TagView), TagType.TODO, BindingMode.TwoWay, propertyChanged: TypePropertyChanged);

    private static void TypePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (TagView)bindable;
        TagType tagType = (TagType)newValue;
        control.SetType(tagType);
    }

    public TagView()
    {
        InitializeComponent();
        SetType(TagType.TODO);
    }

    private void SetType(TagType tagType)
    {
        switch (tagType)
        {
            case TagType.TODO:
                this.BackgroundColor = Colors.Blue;
                break;
            case TagType.IN_PROGRESS:
                this.BackgroundColor = Colors.Orange;
                break;
            case TagType.OK:
                this.BackgroundColor = Colors.Green;
                break;
            case TagType.KO:
            default:
                this.BackgroundColor = Colors.Red;
                break;
        }
    }
    public TagType MyTag { get => (TagType)GetValue(MyTagProperty); set => SetValue(MyTagProperty, value); }
}
public enum TagType
{
    TODO,
    IN_PROGRESS,
    OK,
    KO
}