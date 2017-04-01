Public Class ColorPicker
    Inherits System.Windows.Controls.UserControl

    Public ColorProperty As DependencyProperty

    Public RedProperty As DependencyProperty
    Public GreenProperty As DependencyProperty
    Public BlueProperty As DependencyProperty

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавить код инициализации после вызова InitializeComponent().


        ColorProperty = DependencyProperty.Register("Color", GetType(Color), GetType(ColorPicker),
                New FrameworkPropertyMetadata(Colors.Black, New PropertyChangedCallback(AddressOf OnColorChanged)))

        RedProperty = DependencyProperty.Register("Red", GetType(Byte), GetType(ColorPicker),
                New FrameworkPropertyMetadata(New PropertyChangedCallback(AddressOf OnColorRGBChanged)))
        GreenProperty = DependencyProperty.Register("Green", GetType(Byte), GetType(ColorPicker),
                New FrameworkPropertyMetadata(New PropertyChangedCallback(AddressOf OnColorRGBChanged)))
        BlueProperty = DependencyProperty.Register("Blue", GetType(Byte), GetType(ColorPicker),
                 New FrameworkPropertyMetadata(New PropertyChangedCallback(AddressOf OnColorRGBChanged)))

        ColorChangedEvent = EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble,
                                                             GetType(RoutedPropertyChangedEventHandler(Of Color)),
                                                             GetType(ColorPicker))

    End Sub


    Public Property Color As Color

        Get
            Return CType(GetValue(ColorProperty), Color)
        End Get
        Set(value As Color)
            SetValue(ColorProperty, value)
        End Set
    End Property

    Public Property Red As Byte
        Get
            Return CType(GetValue(RedProperty), Byte)
        End Get
        Set(value As Byte)
            SetValue(RedProperty, value)
        End Set
    End Property

    Public Property Green As Byte
        Get
            Return CType(GetValue(GreenProperty), Byte)
        End Get
        Set(value As Byte)
            SetValue(GreenProperty, value)
        End Set
    End Property

    Public Property Blue As Byte
        Get
            Return CType(GetValue(BlueProperty), Byte)
        End Get
        Set(value As Byte)
            SetValue(BlueProperty, value)
        End Set
    End Property




    Private Sub OnColorRGBChanged(sender As DependencyObject,
           e As DependencyPropertyChangedEventArgs)

        Dim ColorPicker As ColorPicker = CType(sender, ColorPicker)
        Dim Color As Color = ColorPicker.Color
        If (e.Property Is RedProperty) Then
            Color.R = CType(e.NewValue, Byte)
        ElseIf (e.Property Is GreenProperty) Then
            Color.G = CType(e.NewValue, Byte)
        ElseIf (e.Property Is BlueProperty) Then
            Color.B = CType(e.NewValue, Byte)
        End If
        ColorPicker.Color = Color
    End Sub

    Private Sub OnColorChanged(sender As DependencyObject,
                                      e As DependencyPropertyChangedEventArgs)
        Dim newColor = CType(e.NewValue, Color)
        Dim colorpicker As ColorPicker = CType(sender, ColorPicker)
        colorpicker.Red = newColor.R
        colorpicker.Green = newColor.G
        colorpicker.Blue = newColor.B
    End Sub

    Public Property ColorChangedEvent As RoutedEvent

    'Public Event ColorChanged As RoutedPropertyChangedEventHandler(Of Color)()










End Class
