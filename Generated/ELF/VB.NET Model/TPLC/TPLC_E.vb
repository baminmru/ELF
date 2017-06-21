
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace TPLC


''' <summary>
'''Реализация строки раздела Электроэнергия
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPLC_E
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Дата опроса
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DCALL  as DATE


''' <summary>
'''Локальная переменная для поля Дата счетчика
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DCOUNTER  as DATE


''' <summary>
'''Локальная переменная для поля Энергия общ.
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_E0  as double


''' <summary>
'''Локальная переменная для поля Энергия тариф 1
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_E1  as double


''' <summary>
'''Локальная переменная для поля Энергия тариф 2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_E2  as double


''' <summary>
'''Локальная переменная для поля Энергия тариф 3
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_E3  as double


''' <summary>
'''Локальная переменная для поля Энергия тариф 4
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_E4  as double


''' <summary>
'''Локальная переменная для поля Энергия общ. НИ
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_E0S  as double


''' <summary>
'''Локальная переменная для поля Энергия тариф 1 НИ
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_E1S  as double


''' <summary>
'''Локальная переменная для поля Энергия тариф 2 НИ
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_E2S  as double


''' <summary>
'''Локальная переменная для поля Энергия тариф 3 НИ
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_E3S  as double


''' <summary>
'''Локальная переменная для поля Энергия тариф 4 НИ
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_E4S  as double


''' <summary>
'''Локальная переменная для поля Активная +
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AP  as double


''' <summary>
'''Локальная переменная для поля Активная - 
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AM  as double


''' <summary>
'''Локальная переменная для поля Реактивная +
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_RP  as double


''' <summary>
'''Локальная переменная для поля Реактивная -
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_RM  as double


''' <summary>
'''Локальная переменная для поля Ток Ф1
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_I1  as double


''' <summary>
'''Локальная переменная для поля Ток Ф2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_I2  as double


''' <summary>
'''Локальная переменная для поля Ток Ф3
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_I3  as double


''' <summary>
'''Локальная переменная для поля Напряжение Ф1
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_U1  as double


''' <summary>
'''Локальная переменная для поля Напряжение Ф2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_U2  as double


''' <summary>
'''Локальная переменная для поля Напряжение Ф3
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_U3  as double


''' <summary>
'''Локальная переменная для поля Время безошиб.работы
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_OKTIME  as double


''' <summary>
'''Локальная переменная для поля Время работы
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_WORKTIME  as double


''' <summary>
'''Локальная переменная для поля Ошибки
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_errInfo  as String



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_DCALL=   
            ' m_DCOUNTER=   
            ' m_E0=   
            ' m_E1=   
            ' m_E2=   
            ' m_E3=   
            ' m_E4=   
            ' m_E0S=   
            ' m_E1S=   
            ' m_E2S=   
            ' m_E3S=   
            ' m_E4S=   
            ' m_AP=   
            ' m_AM=   
            ' m_RP=   
            ' m_RM=   
            ' m_I1=   
            ' m_I2=   
            ' m_I3=   
            ' m_U1=   
            ' m_U2=   
            ' m_U3=   
            ' m_OKTIME=   
            ' m_WORKTIME=   
            ' m_errInfo=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 25
        End Get
    End Property



''' <summary>
'''Получить \Задать поле по номеру 
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Overrides Property Value(ByVal Index As Object) As Object
    Get
        If Microsoft.VisualBasic.IsNumeric(Index) Then
            Dim l As Long
            l = CLng(Index)
            Select Case l
                Case 0
                    Value = ID
                Case 1
                    Value = DCALL
                Case 2
                    Value = DCOUNTER
                Case 3
                    Value = E0
                Case 4
                    Value = E1
                Case 5
                    Value = E2
                Case 6
                    Value = E3
                Case 7
                    Value = E4
                Case 8
                    Value = E0S
                Case 9
                    Value = E1S
                Case 10
                    Value = E2S
                Case 11
                    Value = E3S
                Case 12
                    Value = E4S
                Case 13
                    Value = AP
                Case 14
                    Value = AM
                Case 15
                    Value = RP
                Case 16
                    Value = RM
                Case 17
                    Value = I1
                Case 18
                    Value = I2
                Case 19
                    Value = I3
                Case 20
                    Value = U1
                Case 21
                    Value = U2
                Case 22
                    Value = U3
                Case 23
                    Value = OKTIME
                Case 24
                    Value = WORKTIME
                Case 25
                    Value = errInfo
            End Select
        else
        try
          Value = Microsoft.VisualBasic.CallByName(Me, Index.ToString(), Microsoft.VisualBasic.CallType.Get, Nothing)
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
              Value=nothing
          end try
        End If
    End Get
    Set(ByVal value As Object)
    If Microsoft.VisualBasic.IsNumeric(Index) Then
        Dim l As Long
        l = CLng(Index)
        Select Case l
            Case 0
                 ID=value
                Case 1
                    DCALL = value
                Case 2
                    DCOUNTER = value
                Case 3
                    E0 = value
                Case 4
                    E1 = value
                Case 5
                    E2 = value
                Case 6
                    E3 = value
                Case 7
                    E4 = value
                Case 8
                    E0S = value
                Case 9
                    E1S = value
                Case 10
                    E2S = value
                Case 11
                    E3S = value
                Case 12
                    E4S = value
                Case 13
                    AP = value
                Case 14
                    AM = value
                Case 15
                    RP = value
                Case 16
                    RM = value
                Case 17
                    I1 = value
                Case 18
                    I2 = value
                Case 19
                    I3 = value
                Case 20
                    U1 = value
                Case 21
                    U2 = value
                Case 22
                    U3 = value
                Case 23
                    OKTIME = value
                Case 24
                    WORKTIME = value
                Case 25
                    errInfo = value
        End Select
     Else
        Try
            Try
                Microsoft.VisualBasic.CallByName(Me, Index.ToString(), Microsoft.VisualBasic.CallType.Set, value)
            Catch ex As Exception
                Microsoft.VisualBasic.CallByName(Me, Index.ToString(), Microsoft.VisualBasic.CallType.Let, value)
            End Try
        Catch ex As Exception
        End Try
     End If
  End Set

End Property



''' <summary>
'''Название поля по номеру
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Overrides Function FieldNameByID(ByVal Index As long) As String
        If Microsoft.VisualBasic.IsNumeric(Index) Then
            Dim l As Long
            l = CLng(Index)
            Select Case l
                Case 0
                   Return "ID"
                Case 1
                    Return "DCALL"
                Case 2
                    Return "DCOUNTER"
                Case 3
                    Return "E0"
                Case 4
                    Return "E1"
                Case 5
                    Return "E2"
                Case 6
                    Return "E3"
                Case 7
                    Return "E4"
                Case 8
                    Return "E0S"
                Case 9
                    Return "E1S"
                Case 10
                    Return "E2S"
                Case 11
                    Return "E3S"
                Case 12
                    Return "E4S"
                Case 13
                    Return "AP"
                Case 14
                    Return "AM"
                Case 15
                    Return "RP"
                Case 16
                    Return "RM"
                Case 17
                    Return "I1"
                Case 18
                    Return "I2"
                Case 19
                    Return "I3"
                Case 20
                    Return "U1"
                Case 21
                    Return "U2"
                Case 22
                    Return "U3"
                Case 23
                    Return "OKTIME"
                Case 24
                    Return "WORKTIME"
                Case 25
                    Return "errInfo"
                Case else
                return "" 
            End Select
        End If
        return "" 
End Function



''' <summary>
'''Заполнить строку таблицы данными из полей
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub FillDataTable(ByRef DestDataTable As System.Data.DataTable)
            Dim dr As  DataRow
            dr = destdatatable.NewRow
            try
            dr("ID") =ID
            dr("Brief") =Brief
             dr("DCALL") =DCALL
             dr("DCOUNTER") =DCOUNTER
             dr("E0") =E0
             dr("E1") =E1
             dr("E2") =E2
             dr("E3") =E3
             dr("E4") =E4
             dr("E0S") =E0S
             dr("E1S") =E1S
             dr("E2S") =E2S
             dr("E3S") =E3S
             dr("E4S") =E4S
             dr("AP") =AP
             dr("AM") =AM
             dr("RP") =RP
             dr("RM") =RM
             dr("I1") =I1
             dr("I2") =I2
             dr("I3") =I3
             dr("U1") =U1
             dr("U2") =U2
             dr("U3") =U3
             dr("OKTIME") =OKTIME
             dr("WORKTIME") =WORKTIME
             dr("errInfo") =errInfo
            DestDataTable.Rows.Add (dr)
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub



''' <summary>
'''Найти строку в коллекции по идентификатору
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function FindInside(ByVal Table As String, ByVal RowID As String) As LATIR2.Document.DocRow_Base
            dim mFindInside As LATIR2.Document.DocRow_Base = Nothing
            Return Nothing
        End Function



''' <summary>
'''Заполнить коллекцю именованных полей
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub Pack(ByVal nv As LATIR2.NamedValues)
          if DCALL=System.DateTime.MinValue then
            nv.Add("DCALL", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("DCALL", DCALL, dbtype.DATETIME)
          end if 
          if DCOUNTER=System.DateTime.MinValue then
            nv.Add("DCOUNTER", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("DCOUNTER", DCOUNTER, dbtype.DATETIME)
          end if 
          nv.Add("E0", E0, dbtype.double)
          nv.Add("E1", E1, dbtype.double)
          nv.Add("E2", E2, dbtype.double)
          nv.Add("E3", E3, dbtype.double)
          nv.Add("E4", E4, dbtype.double)
          nv.Add("E0S", E0S, dbtype.double)
          nv.Add("E1S", E1S, dbtype.double)
          nv.Add("E2S", E2S, dbtype.double)
          nv.Add("E3S", E3S, dbtype.double)
          nv.Add("E4S", E4S, dbtype.double)
          nv.Add("AP", AP, dbtype.double)
          nv.Add("AM", AM, dbtype.double)
          nv.Add("RP", RP, dbtype.double)
          nv.Add("RM", RM, dbtype.double)
          nv.Add("I1", I1, dbtype.double)
          nv.Add("I2", I2, dbtype.double)
          nv.Add("I3", I3, dbtype.double)
          nv.Add("U1", U1, dbtype.double)
          nv.Add("U2", U2, dbtype.double)
          nv.Add("U3", U3, dbtype.double)
          nv.Add("OKTIME", OKTIME, dbtype.double)
          nv.Add("WORKTIME", WORKTIME, dbtype.double)
          nv.Add("errInfo", errInfo, dbtype.string)
            nv.Add(PartName() & "id", Application.Session.GetProvider.ID2Param(ID),  Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
        End Sub




''' <summary>
'''Заполнить поля из именованной коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub Unpack(ByVal reader As System.Data.DataRow)
            try  
            If IsDBNull(reader.item("SecurityStyleID")) Then
                SecureStyleID = System.guid.Empty
            Else
                SecureStyleID = new Guid(reader.item("SecurityStyleID").ToString())
            End If

            RowRetrived = True
            RetriveTime = Now
      If reader.Table.Columns.Contains("DCALL") Then
          if isdbnull(reader.item("DCALL")) then
            If reader.Table.Columns.Contains("DCALL") Then m_DCALL = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("DCALL") Then m_DCALL=reader.item("DCALL")
          end if 
      end if 
      If reader.Table.Columns.Contains("DCOUNTER") Then
          if isdbnull(reader.item("DCOUNTER")) then
            If reader.Table.Columns.Contains("DCOUNTER") Then m_DCOUNTER = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("DCOUNTER") Then m_DCOUNTER=reader.item("DCOUNTER")
          end if 
      end if 
          If reader.Table.Columns.Contains("E0") Then m_E0=reader.item("E0")
          If reader.Table.Columns.Contains("E1") Then m_E1=reader.item("E1")
          If reader.Table.Columns.Contains("E2") Then m_E2=reader.item("E2")
          If reader.Table.Columns.Contains("E3") Then m_E3=reader.item("E3")
          If reader.Table.Columns.Contains("E4") Then m_E4=reader.item("E4")
          If reader.Table.Columns.Contains("E0S") Then m_E0S=reader.item("E0S")
          If reader.Table.Columns.Contains("E1S") Then m_E1S=reader.item("E1S")
          If reader.Table.Columns.Contains("E2S") Then m_E2S=reader.item("E2S")
          If reader.Table.Columns.Contains("E3S") Then m_E3S=reader.item("E3S")
          If reader.Table.Columns.Contains("E4S") Then m_E4S=reader.item("E4S")
          If reader.Table.Columns.Contains("AP") Then m_AP=reader.item("AP")
          If reader.Table.Columns.Contains("AM") Then m_AM=reader.item("AM")
          If reader.Table.Columns.Contains("RP") Then m_RP=reader.item("RP")
          If reader.Table.Columns.Contains("RM") Then m_RM=reader.item("RM")
          If reader.Table.Columns.Contains("I1") Then m_I1=reader.item("I1")
          If reader.Table.Columns.Contains("I2") Then m_I2=reader.item("I2")
          If reader.Table.Columns.Contains("I3") Then m_I3=reader.item("I3")
          If reader.Table.Columns.Contains("U1") Then m_U1=reader.item("U1")
          If reader.Table.Columns.Contains("U2") Then m_U2=reader.item("U2")
          If reader.Table.Columns.Contains("U3") Then m_U3=reader.item("U3")
          If reader.Table.Columns.Contains("OKTIME") Then m_OKTIME=reader.item("OKTIME")
          If reader.Table.Columns.Contains("WORKTIME") Then m_WORKTIME=reader.item("WORKTIME")
          If reader.Table.Columns.Contains("errInfo") Then m_errInfo=reader.item("errInfo").ToString()
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Дата опроса
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DCALL() As DATE
            Get
                LoadFromDatabase()
                DCALL = m_DCALL
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_DCALL = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Дата счетчика
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DCOUNTER() As DATE
            Get
                LoadFromDatabase()
                DCOUNTER = m_DCOUNTER
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_DCOUNTER = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Энергия общ.
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property E0() As double
            Get
                LoadFromDatabase()
                E0 = m_E0
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_E0 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Энергия тариф 1
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property E1() As double
            Get
                LoadFromDatabase()
                E1 = m_E1
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_E1 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Энергия тариф 2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property E2() As double
            Get
                LoadFromDatabase()
                E2 = m_E2
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_E2 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Энергия тариф 3
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property E3() As double
            Get
                LoadFromDatabase()
                E3 = m_E3
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_E3 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Энергия тариф 4
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property E4() As double
            Get
                LoadFromDatabase()
                E4 = m_E4
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_E4 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Энергия общ. НИ
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property E0S() As double
            Get
                LoadFromDatabase()
                E0S = m_E0S
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_E0S = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Энергия тариф 1 НИ
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property E1S() As double
            Get
                LoadFromDatabase()
                E1S = m_E1S
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_E1S = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Энергия тариф 2 НИ
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property E2S() As double
            Get
                LoadFromDatabase()
                E2S = m_E2S
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_E2S = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Энергия тариф 3 НИ
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property E3S() As double
            Get
                LoadFromDatabase()
                E3S = m_E3S
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_E3S = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Энергия тариф 4 НИ
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property E4S() As double
            Get
                LoadFromDatabase()
                E4S = m_E4S
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_E4S = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Активная +
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AP() As double
            Get
                LoadFromDatabase()
                AP = m_AP
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_AP = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Активная - 
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AM() As double
            Get
                LoadFromDatabase()
                AM = m_AM
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_AM = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Реактивная +
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property RP() As double
            Get
                LoadFromDatabase()
                RP = m_RP
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_RP = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Реактивная -
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property RM() As double
            Get
                LoadFromDatabase()
                RM = m_RM
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_RM = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Ток Ф1
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property I1() As double
            Get
                LoadFromDatabase()
                I1 = m_I1
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_I1 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Ток Ф2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property I2() As double
            Get
                LoadFromDatabase()
                I2 = m_I2
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_I2 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Ток Ф3
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property I3() As double
            Get
                LoadFromDatabase()
                I3 = m_I3
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_I3 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Напряжение Ф1
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property U1() As double
            Get
                LoadFromDatabase()
                U1 = m_U1
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_U1 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Напряжение Ф2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property U2() As double
            Get
                LoadFromDatabase()
                U2 = m_U2
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_U2 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Напряжение Ф3
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property U3() As double
            Get
                LoadFromDatabase()
                U3 = m_U3
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_U3 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Время безошиб.работы
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property OKTIME() As double
            Get
                LoadFromDatabase()
                OKTIME = m_OKTIME
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_OKTIME = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Время работы
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property WORKTIME() As double
            Get
                LoadFromDatabase()
                WORKTIME = m_WORKTIME
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_WORKTIME = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Ошибки
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property errInfo() As String
            Get
                LoadFromDatabase()
                errInfo = m_errInfo
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_errInfo = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Заполнить поля данными из XML
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides sub XMLUnpack(ByVal node As System.Xml.XmlNode, Optional ByVal LoadMode As Integer = 0)
          Dim e_list As XmlNodeList
          try 
            m_DCALL = System.DateTime.MinValue
            DCALL = m_DCALL.AddTicks( node.Attributes.GetNamedItem("DCALL").Value)
            m_DCOUNTER = System.DateTime.MinValue
            DCOUNTER = m_DCOUNTER.AddTicks( node.Attributes.GetNamedItem("DCOUNTER").Value)
            E0 = node.Attributes.GetNamedItem("E0").Value
            E1 = node.Attributes.GetNamedItem("E1").Value
            E2 = node.Attributes.GetNamedItem("E2").Value
            E3 = node.Attributes.GetNamedItem("E3").Value
            E4 = node.Attributes.GetNamedItem("E4").Value
            E0S = node.Attributes.GetNamedItem("E0S").Value
            E1S = node.Attributes.GetNamedItem("E1S").Value
            E2S = node.Attributes.GetNamedItem("E2S").Value
            E3S = node.Attributes.GetNamedItem("E3S").Value
            E4S = node.Attributes.GetNamedItem("E4S").Value
            AP = node.Attributes.GetNamedItem("AP").Value
            AM = node.Attributes.GetNamedItem("AM").Value
            RP = node.Attributes.GetNamedItem("RP").Value
            RM = node.Attributes.GetNamedItem("RM").Value
            I1 = node.Attributes.GetNamedItem("I1").Value
            I2 = node.Attributes.GetNamedItem("I2").Value
            I3 = node.Attributes.GetNamedItem("I3").Value
            U1 = node.Attributes.GetNamedItem("U1").Value
            U2 = node.Attributes.GetNamedItem("U2").Value
            U3 = node.Attributes.GetNamedItem("U3").Value
            OKTIME = node.Attributes.GetNamedItem("OKTIME").Value
            WORKTIME = node.Attributes.GetNamedItem("WORKTIME").Value
            errInfo = node.Attributes.GetNamedItem("errInfo").Value
             Changed = true
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End sub
        Public Overrides Sub Dispose()
        End Sub


''' <summary>
'''Записать данные раздела в XML файл
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides sub XLMPack(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)
           try 
         ' if DCALL = System.DateTime.MinValue then DCALL=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("DCALL", DCALL.Ticks)  
         ' if DCOUNTER = System.DateTime.MinValue then DCOUNTER=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("DCOUNTER", DCOUNTER.Ticks)  
          node.SetAttribute("E0", E0)  
          node.SetAttribute("E1", E1)  
          node.SetAttribute("E2", E2)  
          node.SetAttribute("E3", E3)  
          node.SetAttribute("E4", E4)  
          node.SetAttribute("E0S", E0S)  
          node.SetAttribute("E1S", E1S)  
          node.SetAttribute("E2S", E2S)  
          node.SetAttribute("E3S", E3S)  
          node.SetAttribute("E4S", E4S)  
          node.SetAttribute("AP", AP)  
          node.SetAttribute("AM", AM)  
          node.SetAttribute("RP", RP)  
          node.SetAttribute("RM", RM)  
          node.SetAttribute("I1", I1)  
          node.SetAttribute("I2", I2)  
          node.SetAttribute("I3", I3)  
          node.SetAttribute("U1", U1)  
          node.SetAttribute("U2", U2)  
          node.SetAttribute("U3", U3)  
          node.SetAttribute("OKTIME", OKTIME)  
          node.SetAttribute("WORKTIME", WORKTIME)  
          node.SetAttribute("errInfo", errInfo)  
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End sub


''' <summary>
'''Записать изменения в базу данных
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Overrides Sub BatchUpdate()
  If Deleted Then
    Delete
    Exit Sub
  End If
  If Changed Then Save
End Sub


''' <summary>
'''Количество дочерних разделов
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides ReadOnly Property CountOfParts() As Long
            Get
                CountOfParts = 0
            End Get
        End Property



''' <summary>
'''Доступ к дочернему разделу по номеру
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function GetDocCollection_Base(ByVal Index As Long) As LATIR2.Document.DocCollection_Base
            Select Case Index
            End Select
            return nothing
        End Function
    End Class
End Namespace
