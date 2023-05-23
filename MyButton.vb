Public Class MyButton
        Inherits Button
        Public Sub New()
            MyBase.New()
            SetStyle(ControlStyles.StandardDoubleClick, True)
            SetStyle(ControlStyles.StandardClick, True)
        End Sub
    End Class