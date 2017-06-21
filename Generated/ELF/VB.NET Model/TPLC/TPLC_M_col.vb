
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace TPLC


''' <summary>
'''Реализация раздела Мгновенные значенияв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPLC_M_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "TPLC_M"
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
            dt.TableName="TPLC_M"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("DCALL", GetType(System.DateTime))
            dt.Columns.Add("DCOUNTER", GetType(System.DateTime))
            dt.Columns.Add("Q1", GetType(System.double))
            dt.Columns.Add("Q2", GetType(System.double))
            dt.Columns.Add("T1", GetType(System.double))
            dt.Columns.Add("T2", GetType(System.double))
            dt.Columns.Add("DT12", GetType(System.double))
            dt.Columns.Add("T3", GetType(System.double))
            dt.Columns.Add("T4", GetType(System.double))
            dt.Columns.Add("T5", GetType(System.double))
            dt.Columns.Add("DT45", GetType(System.double))
            dt.Columns.Add("T6", GetType(System.double))
            dt.Columns.Add("V1", GetType(System.double))
            dt.Columns.Add("V2", GetType(System.double))
            dt.Columns.Add("DV12", GetType(System.double))
            dt.Columns.Add("V3", GetType(System.double))
            dt.Columns.Add("V4", GetType(System.double))
            dt.Columns.Add("V5", GetType(System.double))
            dt.Columns.Add("DV45", GetType(System.double))
            dt.Columns.Add("V6", GetType(System.double))
            dt.Columns.Add("M1", GetType(System.double))
            dt.Columns.Add("M2", GetType(System.double))
            dt.Columns.Add("DM12", GetType(System.double))
            dt.Columns.Add("M3", GetType(System.double))
            dt.Columns.Add("M4", GetType(System.double))
            dt.Columns.Add("M5", GetType(System.double))
            dt.Columns.Add("DM45", GetType(System.double))
            dt.Columns.Add("M6", GetType(System.double))
            dt.Columns.Add("P1", GetType(System.double))
            dt.Columns.Add("P2", GetType(System.double))
            dt.Columns.Add("P3", GetType(System.double))
            dt.Columns.Add("P4", GetType(System.double))
            dt.Columns.Add("P5", GetType(System.double))
            dt.Columns.Add("P6", GetType(System.double))
            dt.Columns.Add("G1", GetType(System.double))
            dt.Columns.Add("G2", GetType(System.double))
            dt.Columns.Add("G3", GetType(System.double))
            dt.Columns.Add("G4", GetType(System.double))
            dt.Columns.Add("G5", GetType(System.double))
            dt.Columns.Add("G6", GetType(System.double))
            dt.Columns.Add("TCOOL", GetType(System.double))
            dt.Columns.Add("TCE1", GetType(System.double))
            dt.Columns.Add("TCE2", GetType(System.double))
            dt.Columns.Add("TSUM1", GetType(System.double))
            dt.Columns.Add("TSUM2", GetType(System.double))
            dt.Columns.Add("Q1H", GetType(System.double))
            dt.Columns.Add("Q2H", GetType(System.double))
            dt.Columns.Add("V1H", GetType(System.double))
            dt.Columns.Add("V2H", GetType(System.double))
            dt.Columns.Add("V4H", GetType(System.double))
            dt.Columns.Add("V5H", GetType(System.double))
            dt.Columns.Add("ERRTIME", GetType(System.double))
            dt.Columns.Add("ERRTIMEH", GetType(System.double))
            dt.Columns.Add("HC", Gettype(System.string))
            dt.Columns.Add("SP", GetType(System.double))
            dt.Columns.Add("SP_TB1", GetType(System.double))
            dt.Columns.Add("SP_TB2", GetType(System.double))
            dt.Columns.Add("datetimeCOUNTER", GetType(System.DateTime))
            dt.Columns.Add("DG12", GetType(System.double))
            dt.Columns.Add("DG45", GetType(System.double))
            dt.Columns.Add("DP12", GetType(System.double))
            dt.Columns.Add("DP45", GetType(System.double))
            dt.Columns.Add("UNITSR", Gettype(System.string))
            dt.Columns.Add("Q3", GetType(System.double))
            dt.Columns.Add("Q4", GetType(System.double))
            dt.Columns.Add("PATM", GetType(System.double))
            dt.Columns.Add("Q5", GetType(System.double))
            dt.Columns.Add("DQ12", GetType(System.double))
            dt.Columns.Add("DQ45", GetType(System.double))
            dt.Columns.Add("PXB", GetType(System.double))
            dt.Columns.Add("DQ", GetType(System.double))
            dt.Columns.Add("HC_1", Gettype(System.string))
            dt.Columns.Add("HC_2", Gettype(System.string))
            dt.Columns.Add("THOT", GetType(System.double))
            dt.Columns.Add("DANS1", GetType(System.double))
            dt.Columns.Add("DANS2", GetType(System.double))
            dt.Columns.Add("DANS3", GetType(System.double))
            dt.Columns.Add("DANS4", GetType(System.double))
            dt.Columns.Add("DANS5", GetType(System.double))
            dt.Columns.Add("DANS6", GetType(System.double))
            dt.Columns.Add("CHECK_A", GetType(System.double))
            dt.Columns.Add("OKTIME", GetType(System.double))
            dt.Columns.Add("WORKTIME", GetType(System.double))
            dt.Columns.Add("TAIR1", GetType(System.double))
            dt.Columns.Add("TAIR2", GetType(System.double))
            dt.Columns.Add("HC_CODE", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New TPLC_M
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As TPLC.TPLC_M
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(TPLC.TPLC_M))
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
        Public Shadows Function Item( vIndex as object ) As TPLC.TPLC_M
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("TPLC_MID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.Date2Base("DCALL") 
           mFieldList =mFieldList+","+.Date2Base("DCOUNTER") 
           mFieldList =mFieldList+ ", q1" 
           mFieldList =mFieldList+ ", q2" 
           mFieldList =mFieldList+ ", t1" 
           mFieldList =mFieldList+ ", t2" 
           mFieldList =mFieldList+ ", dt12" 
           mFieldList =mFieldList+ ", t3" 
           mFieldList =mFieldList+ ", t4" 
           mFieldList =mFieldList+ ", t5" 
           mFieldList =mFieldList+ ", dt45" 
           mFieldList =mFieldList+ ", t6" 
           mFieldList =mFieldList+ ", v1" 
           mFieldList =mFieldList+ ", v2" 
           mFieldList =mFieldList+ ", dv12" 
           mFieldList =mFieldList+ ", v3" 
           mFieldList =mFieldList+ ", v4" 
           mFieldList =mFieldList+ ", v5" 
           mFieldList =mFieldList+ ", dv45" 
           mFieldList =mFieldList+ ", v6" 
           mFieldList =mFieldList+ ", m1" 
           mFieldList =mFieldList+ ", m2" 
           mFieldList =mFieldList+ ", dm12" 
           mFieldList =mFieldList+ ", m3" 
           mFieldList =mFieldList+ ", m4" 
           mFieldList =mFieldList+ ", m5" 
           mFieldList =mFieldList+ ", dm45" 
           mFieldList =mFieldList+ ", m6" 
           mFieldList =mFieldList+ ", p1" 
           mFieldList =mFieldList+ ", p2" 
           mFieldList =mFieldList+ ", p3" 
           mFieldList =mFieldList+ ", p4" 
           mFieldList =mFieldList+ ", p5" 
           mFieldList =mFieldList+ ", p6" 
           mFieldList =mFieldList+ ", g1" 
           mFieldList =mFieldList+ ", g2" 
           mFieldList =mFieldList+ ", g3" 
           mFieldList =mFieldList+ ", g4" 
           mFieldList =mFieldList+ ", g5" 
           mFieldList =mFieldList+ ", g6" 
           mFieldList =mFieldList+ ", tcool" 
           mFieldList =mFieldList+ ", tce1" 
           mFieldList =mFieldList+ ", tce2" 
           mFieldList =mFieldList+ ", tsum1" 
           mFieldList =mFieldList+ ", tsum2" 
           mFieldList =mFieldList+ ", q1h" 
           mFieldList =mFieldList+ ", q2h" 
           mFieldList =mFieldList+ ", v1h" 
           mFieldList =mFieldList+ ", v2h" 
           mFieldList =mFieldList+ ", v4h" 
           mFieldList =mFieldList+ ", v5h" 
           mFieldList =mFieldList+ ", errtime" 
           mFieldList =mFieldList+ ", errtimeh" 
           mFieldList =mFieldList+ ", hc" 
           mFieldList =mFieldList+ ", sp" 
           mFieldList =mFieldList+ ", sp_tb1" 
           mFieldList =mFieldList+ ", sp_tb2" 
           mFieldList =mFieldList+","+.Date2Base("datetimeCOUNTER") 
           mFieldList =mFieldList+ ", dg12" 
           mFieldList =mFieldList+ ", dg45" 
           mFieldList =mFieldList+ ", dp12" 
           mFieldList =mFieldList+ ", dp45" 
           mFieldList =mFieldList+ ", unitsr" 
           mFieldList =mFieldList+ ", q3" 
           mFieldList =mFieldList+ ", q4" 
           mFieldList =mFieldList+ ", patm" 
           mFieldList =mFieldList+ ", q5" 
           mFieldList =mFieldList+ ", dq12" 
           mFieldList =mFieldList+ ", dq45" 
           mFieldList =mFieldList+ ", pxb" 
           mFieldList =mFieldList+ ", dq" 
           mFieldList =mFieldList+ ", hc_1" 
           mFieldList =mFieldList+ ", hc_2" 
           mFieldList =mFieldList+ ", thot" 
           mFieldList =mFieldList+ ", dans1" 
           mFieldList =mFieldList+ ", dans2" 
           mFieldList =mFieldList+ ", dans3" 
           mFieldList =mFieldList+ ", dans4" 
           mFieldList =mFieldList+ ", dans5" 
           mFieldList =mFieldList+ ", dans6" 
           mFieldList =mFieldList+ ", check_a" 
           mFieldList =mFieldList+ ", oktime" 
           mFieldList =mFieldList+ ", worktime" 
           mFieldList =mFieldList+ ", tair1" 
           mFieldList =mFieldList+ ", tair2" 
           mFieldList =mFieldList+ ", hc_code" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
