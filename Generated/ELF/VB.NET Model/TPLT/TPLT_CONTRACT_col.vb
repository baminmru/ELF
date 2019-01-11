
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace TPLT


''' <summary>
'''Реализация раздела Договорные установкив виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPLT_CONTRACT_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "TPLT_CONTRACT"
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
            dt.TableName="TPLT_CONTRACT"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("FLD12", Gettype(System.string))
            dt.Columns.Add("FLD13", Gettype(System.string))
            dt.Columns.Add("FLD14", Gettype(System.string))
            dt.Columns.Add("FLD15", Gettype(System.string))
            dt.Columns.Add("FLD16", Gettype(System.string))
            dt.Columns.Add("FLD17", Gettype(System.string))
            dt.Columns.Add("FLD18", Gettype(System.string))
            dt.Columns.Add("FLD19", Gettype(System.string))
            dt.Columns.Add("FLD20", Gettype(System.string))
            dt.Columns.Add("FLD21", Gettype(System.string))
            dt.Columns.Add("FLD22", Gettype(System.string))
            dt.Columns.Add("FLD23", Gettype(System.string))
            dt.Columns.Add("FLD24", Gettype(System.string))
            dt.Columns.Add("FLD25", Gettype(System.string))
            dt.Columns.Add("FLD26", Gettype(System.string))
            dt.Columns.Add("FLD27", Gettype(System.string))
            dt.Columns.Add("FLD28", Gettype(System.string))
            dt.Columns.Add("FLD29", Gettype(System.string))
            dt.Columns.Add("FLD30", Gettype(System.string))
            dt.Columns.Add("FLD31", Gettype(System.string))
            dt.Columns.Add("FLD32", Gettype(System.string))
            dt.Columns.Add("FLD33", Gettype(System.string))
            dt.Columns.Add("FLD34", Gettype(System.string))
            dt.Columns.Add("FLD35", Gettype(System.string))
            dt.Columns.Add("FLD36", Gettype(System.string))
            dt.Columns.Add("FLD37", Gettype(System.string))
            dt.Columns.Add("FLD40", Gettype(System.string))
            dt.Columns.Add("FLD41", Gettype(System.string))
            dt.Columns.Add("FLD42", Gettype(System.string))
            dt.Columns.Add("FLD43", Gettype(System.string))
            dt.Columns.Add("FLD45", Gettype(System.string))
            dt.Columns.Add("FLD46", Gettype(System.string))
            dt.Columns.Add("FLD47", Gettype(System.string))
            dt.Columns.Add("FLD48", Gettype(System.string))
            dt.Columns.Add("FLD49", Gettype(System.string))
            dt.Columns.Add("FLD50", Gettype(System.string))
            dt.Columns.Add("FLD51", Gettype(System.string))
            dt.Columns.Add("FLD52", Gettype(System.string))
            dt.Columns.Add("FLD53", Gettype(System.string))
            dt.Columns.Add("FLD54", Gettype(System.string))
            dt.Columns.Add("FLD55", Gettype(System.string))
            dt.Columns.Add("FLD56", Gettype(System.string))
            dt.Columns.Add("FLD57", Gettype(System.string))
            dt.Columns.Add("FLD58", Gettype(System.string))
            dt.Columns.Add("FLD59", Gettype(System.string))
            dt.Columns.Add("FLD60", Gettype(System.string))
            dt.Columns.Add("FLD61", Gettype(System.string))
            dt.Columns.Add("FLD62", Gettype(System.string))
            dt.Columns.Add("FLD63", Gettype(System.string))
            dt.Columns.Add("FLD64", Gettype(System.string))
            dt.Columns.Add("FLD65", Gettype(System.string))
            dt.Columns.Add("FLD66", Gettype(System.string))
            dt.Columns.Add("FLD67", Gettype(System.string))
            dt.Columns.Add("FLD68", Gettype(System.string))
            dt.Columns.Add("FLD69", Gettype(System.string))
            dt.Columns.Add("FLD70", Gettype(System.string))
            dt.Columns.Add("FLD71", Gettype(System.string))
            dt.Columns.Add("FLD72", Gettype(System.string))
            dt.Columns.Add("FLD73", Gettype(System.string))
            dt.Columns.Add("FLD81", Gettype(System.string))
            dt.Columns.Add("FLD82", Gettype(System.string))
            dt.Columns.Add("FLD83", Gettype(System.string))
            dt.Columns.Add("FLD84", Gettype(System.string))
            dt.Columns.Add("FLD85", Gettype(System.string))
            dt.Columns.Add("FLD86", Gettype(System.string))
            dt.Columns.Add("FLD87", Gettype(System.string))
            dt.Columns.Add("FLD88", Gettype(System.string))
            dt.Columns.Add("FLD89", Gettype(System.string))
            dt.Columns.Add("FLD90", Gettype(System.string))
            dt.Columns.Add("FLD92", Gettype(System.string))
            dt.Columns.Add("FLD93", Gettype(System.string))
            dt.Columns.Add("FLD94", Gettype(System.string))
            dt.Columns.Add("FLD95", Gettype(System.string))
            dt.Columns.Add("FLD96", Gettype(System.string))
            dt.Columns.Add("FLD97", Gettype(System.string))
            dt.Columns.Add("FLD98", Gettype(System.string))
            dt.Columns.Add("FLD99", Gettype(System.string))
            dt.Columns.Add("FLD100", Gettype(System.string))
            dt.Columns.Add("FLD101", Gettype(System.string))
            dt.Columns.Add("FLD102", Gettype(System.string))
            dt.Columns.Add("FLD103", Gettype(System.string))
            dt.Columns.Add("FLD104", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New TPLT_CONTRACT
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As TPLT.TPLT_CONTRACT
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(TPLT.TPLT_CONTRACT))
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
        Public Shadows Function Item( vIndex as object ) As TPLT.TPLT_CONTRACT
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("TPLT_CONTRACTID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", fld12" 
           mFieldList =mFieldList+ ", fld13" 
           mFieldList =mFieldList+ ", fld14" 
           mFieldList =mFieldList+ ", fld15" 
           mFieldList =mFieldList+ ", fld16" 
           mFieldList =mFieldList+ ", fld17" 
           mFieldList =mFieldList+ ", fld18" 
           mFieldList =mFieldList+ ", fld19" 
           mFieldList =mFieldList+ ", fld20" 
           mFieldList =mFieldList+ ", fld21" 
           mFieldList =mFieldList+ ", fld22" 
           mFieldList =mFieldList+ ", fld23" 
           mFieldList =mFieldList+ ", fld24" 
           mFieldList =mFieldList+ ", fld25" 
           mFieldList =mFieldList+ ", fld26" 
           mFieldList =mFieldList+ ", fld27" 
           mFieldList =mFieldList+ ", fld28" 
           mFieldList =mFieldList+ ", fld29" 
           mFieldList =mFieldList+ ", fld30" 
           mFieldList =mFieldList+ ", fld31" 
           mFieldList =mFieldList+ ", fld32" 
           mFieldList =mFieldList+ ", fld33" 
           mFieldList =mFieldList+ ", fld34" 
           mFieldList =mFieldList+ ", fld35" 
           mFieldList =mFieldList+ ", fld36" 
           mFieldList =mFieldList+ ", fld37" 
           mFieldList =mFieldList+ ", fld40" 
           mFieldList =mFieldList+ ", fld41" 
           mFieldList =mFieldList+ ", fld42" 
           mFieldList =mFieldList+ ", fld43" 
           mFieldList =mFieldList+ ", fld45" 
           mFieldList =mFieldList+ ", fld46" 
           mFieldList =mFieldList+ ", fld47" 
           mFieldList =mFieldList+ ", fld48" 
           mFieldList =mFieldList+ ", fld49" 
           mFieldList =mFieldList+ ", fld50" 
           mFieldList =mFieldList+ ", fld51" 
           mFieldList =mFieldList+ ", fld52" 
           mFieldList =mFieldList+ ", fld53" 
           mFieldList =mFieldList+ ", fld54" 
           mFieldList =mFieldList+ ", fld55" 
           mFieldList =mFieldList+ ", fld56" 
           mFieldList =mFieldList+ ", fld57" 
           mFieldList =mFieldList+ ", fld58" 
           mFieldList =mFieldList+ ", fld59" 
           mFieldList =mFieldList+ ", fld60" 
           mFieldList =mFieldList+ ", fld61" 
           mFieldList =mFieldList+ ", fld62" 
           mFieldList =mFieldList+ ", fld63" 
           mFieldList =mFieldList+ ", fld64" 
           mFieldList =mFieldList+ ", fld65" 
           mFieldList =mFieldList+ ", fld66" 
           mFieldList =mFieldList+ ", fld67" 
           mFieldList =mFieldList+ ", fld68" 
           mFieldList =mFieldList+ ", fld69" 
           mFieldList =mFieldList+ ", fld70" 
           mFieldList =mFieldList+ ", fld71" 
           mFieldList =mFieldList+ ", fld72" 
           mFieldList =mFieldList+ ", fld73" 
           mFieldList =mFieldList+ ", fld81" 
           mFieldList =mFieldList+ ", fld82" 
           mFieldList =mFieldList+ ", fld83" 
           mFieldList =mFieldList+ ", fld84" 
           mFieldList =mFieldList+ ", fld85" 
           mFieldList =mFieldList+ ", fld86" 
           mFieldList =mFieldList+ ", fld87" 
           mFieldList =mFieldList+ ", fld88" 
           mFieldList =mFieldList+ ", fld89" 
           mFieldList =mFieldList+ ", fld90" 
           mFieldList =mFieldList+ ", fld92" 
           mFieldList =mFieldList+ ", fld93" 
           mFieldList =mFieldList+ ", fld94" 
           mFieldList =mFieldList+ ", fld95" 
           mFieldList =mFieldList+ ", fld96" 
           mFieldList =mFieldList+ ", fld97" 
           mFieldList =mFieldList+ ", fld98" 
           mFieldList =mFieldList+ ", fld99" 
           mFieldList =mFieldList+ ", fld100" 
           mFieldList =mFieldList+ ", fld101" 
           mFieldList =mFieldList+ ", fld102" 
           mFieldList =mFieldList+ ", fld103" 
           mFieldList =mFieldList+ ", fld104" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
