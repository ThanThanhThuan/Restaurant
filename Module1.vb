Imports System.Runtime.CompilerServices
Imports System.Reflection
Imports System.ComponentModel

Module Module1

    <Extension()>
    Public Sub RemoveAllHandlers(ByVal ctrl As Control)
        If ctrl IsNot Nothing Then
            Dim ctrlType As Type = ctrl.GetType()
            Dim propInfo As PropertyInfo = ctrlType.GetProperty("Events", BindingFlags.Instance Or BindingFlags.NonPublic)
            Dim handlerList As EventHandlerList = CType(propInfo.GetValue(ctrl, Nothing), EventHandlerList)
            Dim headInfo As FieldInfo = handlerList.GetType.GetField("head", BindingFlags.Instance Or BindingFlags.NonPublic)
            Dim handlerDict As New Dictionary(Of Object, [Delegate]())
            Dim head As Object = headInfo.GetValue(handlerList)
            If head IsNot Nothing Then
                Dim entry As Type = head.GetType()
                Dim handlerFI As FieldInfo = entry.GetField("handler", BindingFlags.Instance Or BindingFlags.NonPublic)
                Dim keyFI As FieldInfo = entry.GetField("key", BindingFlags.Instance Or BindingFlags.NonPublic)
                Dim nextFI As FieldInfo = entry.GetField("next", BindingFlags.Instance Or BindingFlags.NonPublic)
                HelpAddEntry(handlerDict, head, handlerFI, keyFI, nextFI)
                For Each pair As KeyValuePair(Of Object, [Delegate]()) In handlerDict
                    For x As Integer = pair.Value.Length - 1 To 0 Step -1
                        handlerList.RemoveHandler(pair.Key, pair.Value(x))
                    Next
                Next
            End If
        End If
    End Sub

    Private Sub HelpAddEntry(ByVal dict As Dictionary(Of Object, [Delegate]()), ByVal entry As Object, ByVal handlerFI As FieldInfo, ByVal keyFI As FieldInfo, ByVal nextFI As FieldInfo)
        Dim del As [Delegate] = CType(handlerFI.GetValue(entry), [Delegate])
        Dim key As Object = keyFI.GetValue(entry)
        Dim nxt As Object = nextFI.GetValue(entry)
        Dim listeners As [Delegate]() = del.GetInvocationList()
        If listeners IsNot Nothing AndAlso listeners.Length > 0 Then
            dict.Add(key, listeners)
        End If
        If nxt IsNot Nothing Then
            HelpAddEntry(dict, nxt, handlerFI, keyFI, nextFI)
        End If
    End Sub
End Module