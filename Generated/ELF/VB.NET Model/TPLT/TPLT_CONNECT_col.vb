
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace TPLT


''' <summary>
'''Реализация раздела Параметры соединенияв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPLT_CONNECT_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "TPLT_CONNECT"
        End Function



''' <summary>
'''Вернуть даные текущей коллекции в виде DataTable
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function CreateDataTable() As System.Data.DataTable
            Dim dt As DataTable
            dt = New DataTable
            dt.TableName="TPLT_CONNECT"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("ConnectionEnabled_VAL" , Gettype(System.Int16))
            dt.Columns.Add("ConnectionEnabled", Gettype(System.string))
            dt.Columns.Add("ConnectType_ID" , GetType(System.guid))
            dt.Columns.Add("ConnectType", Gettype(System.string))
            dt.Columns.Add("CONNECTLIMIT", GetType(System.double))
            dt.Columns.Add("TheServer_ID" , GetType(System.guid))
            dt.Columns.Add("TheServer", Gettype(System.string))
            dt.Columns.Add("netaddr", Gettype(System.Int32))
            dt.Columns.Add("CSPEED", Gettype(System.string))
            dt.Columns.Add("CDATABIT", Gettype(System.string))
            dt.Columns.Add("CPARITY_VAL" , Gettype(System.Int16))
            dt.Columns.Add("CPARITY", Gettype(System.string))
            dt.Columns.Add("CSTOPBITS", Gettype(System.Int32))
            dt.Columns.Add("FlowControl", Gettype(System.string))
            dt.Columns.Add("ComPortNum", Gettype(System.string))
            dt.Columns.Add("IPAddr", Gettype(System.string))
            dt.Columns.Add("PortNum", Gettype(System.Int32))
            dt.Columns.Add("UserName", Gettype(System.string))
            dt.Columns.Add("Password", Gettype(System.string))
            dt.Columns.Add("CTOWNCODE", Gettype(System.string))
            dt.Columns.Add("CPHONE", Gettype(System.string))
            dt.Columns.Add("ATCommand", Gettype(System.string))
            dt.Columns.Add("callerID", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New TPLT_CONNECT
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As TPLT.TPLT_CONNECT
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(TPLT.TPLT_CONNECT))
catch ex as System.Exception
 Debug.Print( ex.Message + " >> " + ex.StackTrace)
end try
        End Function


''' <summary>
'''Получить элемент коллекции, более свежий вариант
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Shadows Function Item( vIndex as object ) As TPLT.TPLT_CONNECT
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("TPLT_CONNECTID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", connectionenabled" 
           mFieldList =mFieldList+","+.ID2Base("ConnectType") 
           mFieldList =mFieldList+ ", connectlimit" 
           mFieldList =mFieldList+","+.ID2Base("TheServer") 
           mFieldList =mFieldList+ ", netaddr" 
           mFieldList =mFieldList+ ", cspeed" 
           mFieldList =mFieldList+ ", cdatabit" 
           mFieldList =mFieldList+ ", cparity" 
           mFieldList =mFieldList+ ", cstopbits" 
           mFieldList =mFieldList+ ", flowcontrol" 
           mFieldList =mFieldList+ ", comportnum" 
           mFieldList =mFieldList+ ", ipaddr" 
           mFieldList =mFieldList+ ", portnum" 
           mFieldList =mFieldList+ ", username" 
           mFieldList =mFieldList+ ", password" 
           mFieldList =mFieldList+ ", ctowncode" 
           mFieldList =mFieldList+ ", cphone" 
           mFieldList =mFieldList+ ", atcommand" 
           mFieldList =mFieldList+ ", callerid" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
