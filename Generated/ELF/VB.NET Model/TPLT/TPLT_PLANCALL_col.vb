
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace TPLT


''' <summary>
'''Реализация раздела План опроса устройствв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPLT_PLANCALL_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "TPLT_PLANCALL"
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
            dt.TableName="TPLT_PLANCALL"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("CSTATUS_VAL" , Gettype(System.Int16))
            dt.Columns.Add("CSTATUS", Gettype(System.string))
            dt.Columns.Add("NMAXCALL", Gettype(System.Int32))
            dt.Columns.Add("MINREPEAT", Gettype(System.Int32))
            dt.Columns.Add("DLOCK", GetType(System.DateTime))
            dt.Columns.Add("DLASTCALL", GetType(System.DateTime))
            dt.Columns.Add("CCURR_VAL" , Gettype(System.Int16))
            dt.Columns.Add("CCURR", Gettype(System.string))
            dt.Columns.Add("ICALLCURR", Gettype(System.Int32))
            dt.Columns.Add("DNEXTCURR", GetType(System.DateTime))
            dt.Columns.Add("CHOUR_VAL" , Gettype(System.Int16))
            dt.Columns.Add("CHOUR", Gettype(System.string))
            dt.Columns.Add("ICALL", Gettype(System.Int32))
            dt.Columns.Add("NUMHOUR", Gettype(System.Int32))
            dt.Columns.Add("DNEXTHOUR", GetType(System.DateTime))
            dt.Columns.Add("DLASTHOUR", GetType(System.DateTime))
            dt.Columns.Add("C24_VAL" , Gettype(System.Int16))
            dt.Columns.Add("C24", Gettype(System.string))
            dt.Columns.Add("ICALL24", Gettype(System.Int32))
            dt.Columns.Add("NUM24", Gettype(System.Int32))
            dt.Columns.Add("DNEXT24", GetType(System.DateTime))
            dt.Columns.Add("DLASTDAY", GetType(System.DateTime))
            dt.Columns.Add("CSUM_VAL" , Gettype(System.Int16))
            dt.Columns.Add("CSUM", Gettype(System.string))
            dt.Columns.Add("ICALLSUM", Gettype(System.Int32))
            dt.Columns.Add("DNEXTSUM", GetType(System.DateTime))
            dt.Columns.Add("CEL_VAL" , Gettype(System.Int16))
            dt.Columns.Add("CEL", Gettype(System.string))
            dt.Columns.Add("IEL", Gettype(System.Int32))
            dt.Columns.Add("DNEXTEL", GetType(System.DateTime))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New TPLT_PLANCALL
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As TPLT.TPLT_PLANCALL
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(TPLT.TPLT_PLANCALL))
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
        Public Shadows Function Item( vIndex as object ) As TPLT.TPLT_PLANCALL
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("TPLT_PLANCALLID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", cstatus" 
           mFieldList =mFieldList+ ", nmaxcall" 
           mFieldList =mFieldList+ ", minrepeat" 
           mFieldList =mFieldList+","+.Date2Base("DLOCK") 
           mFieldList =mFieldList+","+.Date2Base("DLASTCALL") 
           mFieldList =mFieldList+ ", ccurr" 
           mFieldList =mFieldList+ ", icallcurr" 
           mFieldList =mFieldList+","+.Date2Base("DNEXTCURR") 
           mFieldList =mFieldList+ ", chour" 
           mFieldList =mFieldList+ ", icall" 
           mFieldList =mFieldList+ ", numhour" 
           mFieldList =mFieldList+","+.Date2Base("DNEXTHOUR") 
           mFieldList =mFieldList+","+.Date2Base("DLASTHOUR") 
           mFieldList =mFieldList+ ", c24" 
           mFieldList =mFieldList+ ", icall24" 
           mFieldList =mFieldList+ ", num24" 
           mFieldList =mFieldList+","+.Date2Base("DNEXT24") 
           mFieldList =mFieldList+","+.Date2Base("DLASTDAY") 
           mFieldList =mFieldList+ ", csum" 
           mFieldList =mFieldList+ ", icallsum" 
           mFieldList =mFieldList+","+.Date2Base("DNEXTSUM") 
           mFieldList =mFieldList+ ", cel" 
           mFieldList =mFieldList+ ", iel" 
           mFieldList =mFieldList+","+.Date2Base("DNEXTEL") 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
