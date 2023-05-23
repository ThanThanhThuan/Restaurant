Imports System.Runtime.CompilerServices
Module modPanelExtension
    <Extension()>
    Sub ScrollDown(ByVal p As Panel, ByVal pos As Integer)
        Using c As Control = New Control() With {.Parent = p, .Height = 1, .Top = p.ClientSize.Height + pos}
            p.ScrollControlIntoView(c)
        End Using
    End Sub

    <Extension()>
    Sub ScrollUp(ByVal p As Panel, ByVal pos As Integer)
        Using c As Control = New Control() With {.Parent = p, .Height = 1, .Top = pos}
            p.ScrollControlIntoView(c)
        End Using
    End Sub
End Module
