
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace TPLT


''' <summary>
'''Реализация строки раздела План опроса устройств
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPLT_PLANCALL
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Исключить из опроса
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_CSTATUS  as enumBoolean


''' <summary>
'''Локальная переменная для поля Max число попыток дозвона
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_NMAXCALL  as long


''' <summary>
'''Локальная переменная для поля Повторить через (минут)
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_MINREPEAT  as long


''' <summary>
'''Локальная переменная для поля Когда заблокирован
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DLOCK  as DATE


''' <summary>
'''Локальная переменная для поля Последний опрос
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DLASTCALL  as DATE


''' <summary>
'''Локальная переменная для поля Опрашивать текущие
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_CCURR  as enumBoolean


''' <summary>
'''Локальная переменная для поля Интервал (минут) 
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ICALLCURR  as long


''' <summary>
'''Локальная переменная для поля Следующий опрос
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DNEXTCURR  as DATE


''' <summary>
'''Локальная переменная для поля Опрашивать ч.
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_CHOUR  as enumBoolean


''' <summary>
'''Локальная переменная для поля Интервал опроса (минут)
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ICALL  as long


''' <summary>
'''Локальная переменная для поля За сколько часов
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_NUMHOUR  as long


''' <summary>
'''Локальная переменная для поля Следующий опрос
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DNEXTHOUR  as DATE


''' <summary>
'''Локальная переменная для поля Последний опрос
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DLASTHOUR  as DATE


''' <summary>
'''Локальная переменная для поля Опрашивать С.
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_C24  as enumBoolean


''' <summary>
'''Локальная переменная для поля Интервал (часов)
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ICALL24  as long


''' <summary>
'''Локальная переменная для поля За сколько суток
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_NUM24  as long


''' <summary>
'''Локальная переменная для поля Следующий опрос
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DNEXT24  as DATE


''' <summary>
'''Локальная переменная для поля Последний опрос
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DLASTDAY  as DATE


''' <summary>
'''Локальная переменная для поля Опрашивать Ит.
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_CSUM  as enumBoolean


''' <summary>
'''Локальная переменная для поля Интервал  (минут) 
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ICALLSUM  as long


''' <summary>
'''Локальная переменная для поля Следующий опрос
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DNEXTSUM  as DATE


''' <summary>
'''Локальная переменная для поля Опрашивать Эл.
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_CEL  as enumBoolean


''' <summary>
'''Локальная переменная для поля Интервал (мин.)
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_IEL  as long


''' <summary>
'''Локальная переменная для поля Дата следующего опроса
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DNEXTEL  as DATE



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_CSTATUS=   
            ' m_NMAXCALL=   
            ' m_MINREPEAT=   
            ' m_DLOCK=   
            ' m_DLASTCALL=   
            ' m_CCURR=   
            ' m_ICALLCURR=   
            ' m_DNEXTCURR=   
            ' m_CHOUR=   
            ' m_ICALL=   
            ' m_NUMHOUR=   
            ' m_DNEXTHOUR=   
            ' m_DLASTHOUR=   
            ' m_C24=   
            ' m_ICALL24=   
            ' m_NUM24=   
            ' m_DNEXT24=   
            ' m_DLASTDAY=   
            ' m_CSUM=   
            ' m_ICALLSUM=   
            ' m_DNEXTSUM=   
            ' m_CEL=   
            ' m_IEL=   
            ' m_DNEXTEL=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 24
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
                    Value = CSTATUS
                Case 2
                    Value = NMAXCALL
                Case 3
                    Value = MINREPEAT
                Case 4
                    Value = DLOCK
                Case 5
                    Value = DLASTCALL
                Case 6
                    Value = CCURR
                Case 7
                    Value = ICALLCURR
                Case 8
                    Value = DNEXTCURR
                Case 9
                    Value = CHOUR
                Case 10
                    Value = ICALL
                Case 11
                    Value = NUMHOUR
                Case 12
                    Value = DNEXTHOUR
                Case 13
                    Value = DLASTHOUR
                Case 14
                    Value = C24
                Case 15
                    Value = ICALL24
                Case 16
                    Value = NUM24
                Case 17
                    Value = DNEXT24
                Case 18
                    Value = DLASTDAY
                Case 19
                    Value = CSUM
                Case 20
                    Value = ICALLSUM
                Case 21
                    Value = DNEXTSUM
                Case 22
                    Value = CEL
                Case 23
                    Value = IEL
                Case 24
                    Value = DNEXTEL
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
                    CSTATUS = value
                Case 2
                    NMAXCALL = value
                Case 3
                    MINREPEAT = value
                Case 4
                    DLOCK = value
                Case 5
                    DLASTCALL = value
                Case 6
                    CCURR = value
                Case 7
                    ICALLCURR = value
                Case 8
                    DNEXTCURR = value
                Case 9
                    CHOUR = value
                Case 10
                    ICALL = value
                Case 11
                    NUMHOUR = value
                Case 12
                    DNEXTHOUR = value
                Case 13
                    DLASTHOUR = value
                Case 14
                    C24 = value
                Case 15
                    ICALL24 = value
                Case 16
                    NUM24 = value
                Case 17
                    DNEXT24 = value
                Case 18
                    DLASTDAY = value
                Case 19
                    CSUM = value
                Case 20
                    ICALLSUM = value
                Case 21
                    DNEXTSUM = value
                Case 22
                    CEL = value
                Case 23
                    IEL = value
                Case 24
                    DNEXTEL = value
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
                    Return "CSTATUS"
                Case 2
                    Return "NMAXCALL"
                Case 3
                    Return "MINREPEAT"
                Case 4
                    Return "DLOCK"
                Case 5
                    Return "DLASTCALL"
                Case 6
                    Return "CCURR"
                Case 7
                    Return "ICALLCURR"
                Case 8
                    Return "DNEXTCURR"
                Case 9
                    Return "CHOUR"
                Case 10
                    Return "ICALL"
                Case 11
                    Return "NUMHOUR"
                Case 12
                    Return "DNEXTHOUR"
                Case 13
                    Return "DLASTHOUR"
                Case 14
                    Return "C24"
                Case 15
                    Return "ICALL24"
                Case 16
                    Return "NUM24"
                Case 17
                    Return "DNEXT24"
                Case 18
                    Return "DLASTDAY"
                Case 19
                    Return "CSUM"
                Case 20
                    Return "ICALLSUM"
                Case 21
                    Return "DNEXTSUM"
                Case 22
                    Return "CEL"
                Case 23
                    Return "IEL"
                Case 24
                    Return "DNEXTEL"
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
             select case CSTATUS
            case enumBoolean.Boolean_Da
              dr ("CSTATUS")  = "Да"
              dr ("CSTATUS_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("CSTATUS")  = "Нет"
              dr ("CSTATUS_VAL")  = 0
              end select 'CSTATUS
             dr("NMAXCALL") =NMAXCALL
             dr("MINREPEAT") =MINREPEAT
             dr("DLOCK") =DLOCK
             dr("DLASTCALL") =DLASTCALL
             select case CCURR
            case enumBoolean.Boolean_Da
              dr ("CCURR")  = "Да"
              dr ("CCURR_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("CCURR")  = "Нет"
              dr ("CCURR_VAL")  = 0
              end select 'CCURR
             dr("ICALLCURR") =ICALLCURR
             dr("DNEXTCURR") =DNEXTCURR
             select case CHOUR
            case enumBoolean.Boolean_Da
              dr ("CHOUR")  = "Да"
              dr ("CHOUR_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("CHOUR")  = "Нет"
              dr ("CHOUR_VAL")  = 0
              end select 'CHOUR
             dr("ICALL") =ICALL
             dr("NUMHOUR") =NUMHOUR
             dr("DNEXTHOUR") =DNEXTHOUR
             dr("DLASTHOUR") =DLASTHOUR
             select case C24
            case enumBoolean.Boolean_Da
              dr ("C24")  = "Да"
              dr ("C24_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("C24")  = "Нет"
              dr ("C24_VAL")  = 0
              end select 'C24
             dr("ICALL24") =ICALL24
             dr("NUM24") =NUM24
             dr("DNEXT24") =DNEXT24
             dr("DLASTDAY") =DLASTDAY
             select case CSUM
            case enumBoolean.Boolean_Da
              dr ("CSUM")  = "Да"
              dr ("CSUM_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("CSUM")  = "Нет"
              dr ("CSUM_VAL")  = 0
              end select 'CSUM
             dr("ICALLSUM") =ICALLSUM
             dr("DNEXTSUM") =DNEXTSUM
             select case CEL
            case enumBoolean.Boolean_Da
              dr ("CEL")  = "Да"
              dr ("CEL_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("CEL")  = "Нет"
              dr ("CEL_VAL")  = 0
              end select 'CEL
             dr("IEL") =IEL
             dr("DNEXTEL") =DNEXTEL
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
          nv.Add("CSTATUS", CSTATUS, dbtype.int16)
          nv.Add("NMAXCALL", NMAXCALL, dbtype.Int32)
          nv.Add("MINREPEAT", MINREPEAT, dbtype.Int32)
          if DLOCK=System.DateTime.MinValue then
            nv.Add("DLOCK", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("DLOCK", DLOCK, dbtype.DATETIME)
          end if 
          if DLASTCALL=System.DateTime.MinValue then
            nv.Add("DLASTCALL", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("DLASTCALL", DLASTCALL, dbtype.DATETIME)
          end if 
          nv.Add("CCURR", CCURR, dbtype.int16)
          nv.Add("ICALLCURR", ICALLCURR, dbtype.Int32)
          if DNEXTCURR=System.DateTime.MinValue then
            nv.Add("DNEXTCURR", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("DNEXTCURR", DNEXTCURR, dbtype.DATETIME)
          end if 
          nv.Add("CHOUR", CHOUR, dbtype.int16)
          nv.Add("ICALL", ICALL, dbtype.Int32)
          nv.Add("NUMHOUR", NUMHOUR, dbtype.Int32)
          if DNEXTHOUR=System.DateTime.MinValue then
            nv.Add("DNEXTHOUR", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("DNEXTHOUR", DNEXTHOUR, dbtype.DATETIME)
          end if 
          if DLASTHOUR=System.DateTime.MinValue then
            nv.Add("DLASTHOUR", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("DLASTHOUR", DLASTHOUR, dbtype.DATETIME)
          end if 
          nv.Add("C24", C24, dbtype.int16)
          nv.Add("ICALL24", ICALL24, dbtype.Int32)
          nv.Add("NUM24", NUM24, dbtype.Int32)
          if DNEXT24=System.DateTime.MinValue then
            nv.Add("DNEXT24", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("DNEXT24", DNEXT24, dbtype.DATETIME)
          end if 
          if DLASTDAY=System.DateTime.MinValue then
            nv.Add("DLASTDAY", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("DLASTDAY", DLASTDAY, dbtype.DATETIME)
          end if 
          nv.Add("CSUM", CSUM, dbtype.int16)
          nv.Add("ICALLSUM", ICALLSUM, dbtype.Int32)
          if DNEXTSUM=System.DateTime.MinValue then
            nv.Add("DNEXTSUM", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("DNEXTSUM", DNEXTSUM, dbtype.DATETIME)
          end if 
          nv.Add("CEL", CEL, dbtype.int16)
          nv.Add("IEL", IEL, dbtype.Int32)
          if DNEXTEL=System.DateTime.MinValue then
            nv.Add("DNEXTEL", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("DNEXTEL", DNEXTEL, dbtype.DATETIME)
          end if 
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
          If reader.Table.Columns.Contains("CSTATUS") Then m_CSTATUS=reader.item("CSTATUS")
          If reader.Table.Columns.Contains("NMAXCALL") Then m_NMAXCALL=reader.item("NMAXCALL")
          If reader.Table.Columns.Contains("MINREPEAT") Then m_MINREPEAT=reader.item("MINREPEAT")
      If reader.Table.Columns.Contains("DLOCK") Then
          if isdbnull(reader.item("DLOCK")) then
            If reader.Table.Columns.Contains("DLOCK") Then m_DLOCK = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("DLOCK") Then m_DLOCK=reader.item("DLOCK")
          end if 
      end if 
      If reader.Table.Columns.Contains("DLASTCALL") Then
          if isdbnull(reader.item("DLASTCALL")) then
            If reader.Table.Columns.Contains("DLASTCALL") Then m_DLASTCALL = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("DLASTCALL") Then m_DLASTCALL=reader.item("DLASTCALL")
          end if 
      end if 
          If reader.Table.Columns.Contains("CCURR") Then m_CCURR=reader.item("CCURR")
          If reader.Table.Columns.Contains("ICALLCURR") Then m_ICALLCURR=reader.item("ICALLCURR")
      If reader.Table.Columns.Contains("DNEXTCURR") Then
          if isdbnull(reader.item("DNEXTCURR")) then
            If reader.Table.Columns.Contains("DNEXTCURR") Then m_DNEXTCURR = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("DNEXTCURR") Then m_DNEXTCURR=reader.item("DNEXTCURR")
          end if 
      end if 
          If reader.Table.Columns.Contains("CHOUR") Then m_CHOUR=reader.item("CHOUR")
          If reader.Table.Columns.Contains("ICALL") Then m_ICALL=reader.item("ICALL")
          If reader.Table.Columns.Contains("NUMHOUR") Then m_NUMHOUR=reader.item("NUMHOUR")
      If reader.Table.Columns.Contains("DNEXTHOUR") Then
          if isdbnull(reader.item("DNEXTHOUR")) then
            If reader.Table.Columns.Contains("DNEXTHOUR") Then m_DNEXTHOUR = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("DNEXTHOUR") Then m_DNEXTHOUR=reader.item("DNEXTHOUR")
          end if 
      end if 
      If reader.Table.Columns.Contains("DLASTHOUR") Then
          if isdbnull(reader.item("DLASTHOUR")) then
            If reader.Table.Columns.Contains("DLASTHOUR") Then m_DLASTHOUR = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("DLASTHOUR") Then m_DLASTHOUR=reader.item("DLASTHOUR")
          end if 
      end if 
          If reader.Table.Columns.Contains("C24") Then m_C24=reader.item("C24")
          If reader.Table.Columns.Contains("ICALL24") Then m_ICALL24=reader.item("ICALL24")
          If reader.Table.Columns.Contains("NUM24") Then m_NUM24=reader.item("NUM24")
      If reader.Table.Columns.Contains("DNEXT24") Then
          if isdbnull(reader.item("DNEXT24")) then
            If reader.Table.Columns.Contains("DNEXT24") Then m_DNEXT24 = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("DNEXT24") Then m_DNEXT24=reader.item("DNEXT24")
          end if 
      end if 
      If reader.Table.Columns.Contains("DLASTDAY") Then
          if isdbnull(reader.item("DLASTDAY")) then
            If reader.Table.Columns.Contains("DLASTDAY") Then m_DLASTDAY = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("DLASTDAY") Then m_DLASTDAY=reader.item("DLASTDAY")
          end if 
      end if 
          If reader.Table.Columns.Contains("CSUM") Then m_CSUM=reader.item("CSUM")
          If reader.Table.Columns.Contains("ICALLSUM") Then m_ICALLSUM=reader.item("ICALLSUM")
      If reader.Table.Columns.Contains("DNEXTSUM") Then
          if isdbnull(reader.item("DNEXTSUM")) then
            If reader.Table.Columns.Contains("DNEXTSUM") Then m_DNEXTSUM = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("DNEXTSUM") Then m_DNEXTSUM=reader.item("DNEXTSUM")
          end if 
      end if 
          If reader.Table.Columns.Contains("CEL") Then m_CEL=reader.item("CEL")
          If reader.Table.Columns.Contains("IEL") Then m_IEL=reader.item("IEL")
      If reader.Table.Columns.Contains("DNEXTEL") Then
          if isdbnull(reader.item("DNEXTEL")) then
            If reader.Table.Columns.Contains("DNEXTEL") Then m_DNEXTEL = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("DNEXTEL") Then m_DNEXTEL=reader.item("DNEXTEL")
          end if 
      end if 
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Исключить из опроса
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property CSTATUS() As enumBoolean
            Get
                LoadFromDatabase()
                CSTATUS = m_CSTATUS
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_CSTATUS = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Max число попыток дозвона
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property NMAXCALL() As long
            Get
                LoadFromDatabase()
                NMAXCALL = m_NMAXCALL
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_NMAXCALL = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Повторить через (минут)
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property MINREPEAT() As long
            Get
                LoadFromDatabase()
                MINREPEAT = m_MINREPEAT
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_MINREPEAT = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Когда заблокирован
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DLOCK() As DATE
            Get
                LoadFromDatabase()
                DLOCK = m_DLOCK
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_DLOCK = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Последний опрос
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DLASTCALL() As DATE
            Get
                LoadFromDatabase()
                DLASTCALL = m_DLASTCALL
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_DLASTCALL = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Опрашивать текущие
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property CCURR() As enumBoolean
            Get
                LoadFromDatabase()
                CCURR = m_CCURR
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_CCURR = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Интервал (минут) 
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ICALLCURR() As long
            Get
                LoadFromDatabase()
                ICALLCURR = m_ICALLCURR
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_ICALLCURR = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Следующий опрос
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DNEXTCURR() As DATE
            Get
                LoadFromDatabase()
                DNEXTCURR = m_DNEXTCURR
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_DNEXTCURR = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Опрашивать ч.
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property CHOUR() As enumBoolean
            Get
                LoadFromDatabase()
                CHOUR = m_CHOUR
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_CHOUR = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Интервал опроса (минут)
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ICALL() As long
            Get
                LoadFromDatabase()
                ICALL = m_ICALL
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_ICALL = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю За сколько часов
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property NUMHOUR() As long
            Get
                LoadFromDatabase()
                NUMHOUR = m_NUMHOUR
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_NUMHOUR = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Следующий опрос
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DNEXTHOUR() As DATE
            Get
                LoadFromDatabase()
                DNEXTHOUR = m_DNEXTHOUR
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_DNEXTHOUR = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Последний опрос
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DLASTHOUR() As DATE
            Get
                LoadFromDatabase()
                DLASTHOUR = m_DLASTHOUR
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_DLASTHOUR = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Опрашивать С.
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property C24() As enumBoolean
            Get
                LoadFromDatabase()
                C24 = m_C24
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_C24 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Интервал (часов)
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ICALL24() As long
            Get
                LoadFromDatabase()
                ICALL24 = m_ICALL24
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_ICALL24 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю За сколько суток
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property NUM24() As long
            Get
                LoadFromDatabase()
                NUM24 = m_NUM24
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_NUM24 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Следующий опрос
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DNEXT24() As DATE
            Get
                LoadFromDatabase()
                DNEXT24 = m_DNEXT24
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_DNEXT24 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Последний опрос
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DLASTDAY() As DATE
            Get
                LoadFromDatabase()
                DLASTDAY = m_DLASTDAY
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_DLASTDAY = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Опрашивать Ит.
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property CSUM() As enumBoolean
            Get
                LoadFromDatabase()
                CSUM = m_CSUM
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_CSUM = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Интервал  (минут) 
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ICALLSUM() As long
            Get
                LoadFromDatabase()
                ICALLSUM = m_ICALLSUM
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_ICALLSUM = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Следующий опрос
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DNEXTSUM() As DATE
            Get
                LoadFromDatabase()
                DNEXTSUM = m_DNEXTSUM
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_DNEXTSUM = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Опрашивать Эл.
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property CEL() As enumBoolean
            Get
                LoadFromDatabase()
                CEL = m_CEL
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_CEL = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Интервал (мин.)
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property IEL() As long
            Get
                LoadFromDatabase()
                IEL = m_IEL
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_IEL = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Дата следующего опроса
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DNEXTEL() As DATE
            Get
                LoadFromDatabase()
                DNEXTEL = m_DNEXTEL
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_DNEXTEL = Value
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
            CSTATUS = node.Attributes.GetNamedItem("CSTATUS").Value
            NMAXCALL = node.Attributes.GetNamedItem("NMAXCALL").Value
            MINREPEAT = node.Attributes.GetNamedItem("MINREPEAT").Value
            m_DLOCK = System.DateTime.MinValue
            DLOCK = m_DLOCK.AddTicks( node.Attributes.GetNamedItem("DLOCK").Value)
            m_DLASTCALL = System.DateTime.MinValue
            DLASTCALL = m_DLASTCALL.AddTicks( node.Attributes.GetNamedItem("DLASTCALL").Value)
            CCURR = node.Attributes.GetNamedItem("CCURR").Value
            ICALLCURR = node.Attributes.GetNamedItem("ICALLCURR").Value
            m_DNEXTCURR = System.DateTime.MinValue
            DNEXTCURR = m_DNEXTCURR.AddTicks( node.Attributes.GetNamedItem("DNEXTCURR").Value)
            CHOUR = node.Attributes.GetNamedItem("CHOUR").Value
            ICALL = node.Attributes.GetNamedItem("ICALL").Value
            NUMHOUR = node.Attributes.GetNamedItem("NUMHOUR").Value
            m_DNEXTHOUR = System.DateTime.MinValue
            DNEXTHOUR = m_DNEXTHOUR.AddTicks( node.Attributes.GetNamedItem("DNEXTHOUR").Value)
            m_DLASTHOUR = System.DateTime.MinValue
            DLASTHOUR = m_DLASTHOUR.AddTicks( node.Attributes.GetNamedItem("DLASTHOUR").Value)
            C24 = node.Attributes.GetNamedItem("C24").Value
            ICALL24 = node.Attributes.GetNamedItem("ICALL24").Value
            NUM24 = node.Attributes.GetNamedItem("NUM24").Value
            m_DNEXT24 = System.DateTime.MinValue
            DNEXT24 = m_DNEXT24.AddTicks( node.Attributes.GetNamedItem("DNEXT24").Value)
            m_DLASTDAY = System.DateTime.MinValue
            DLASTDAY = m_DLASTDAY.AddTicks( node.Attributes.GetNamedItem("DLASTDAY").Value)
            CSUM = node.Attributes.GetNamedItem("CSUM").Value
            ICALLSUM = node.Attributes.GetNamedItem("ICALLSUM").Value
            m_DNEXTSUM = System.DateTime.MinValue
            DNEXTSUM = m_DNEXTSUM.AddTicks( node.Attributes.GetNamedItem("DNEXTSUM").Value)
            CEL = node.Attributes.GetNamedItem("CEL").Value
            IEL = node.Attributes.GetNamedItem("IEL").Value
            m_DNEXTEL = System.DateTime.MinValue
            DNEXTEL = m_DNEXTEL.AddTicks( node.Attributes.GetNamedItem("DNEXTEL").Value)
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
          node.SetAttribute("CSTATUS", CSTATUS)  
          node.SetAttribute("NMAXCALL", NMAXCALL)  
          node.SetAttribute("MINREPEAT", MINREPEAT)  
         ' if DLOCK = System.DateTime.MinValue then DLOCK=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("DLOCK", DLOCK.Ticks)  
         ' if DLASTCALL = System.DateTime.MinValue then DLASTCALL=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("DLASTCALL", DLASTCALL.Ticks)  
          node.SetAttribute("CCURR", CCURR)  
          node.SetAttribute("ICALLCURR", ICALLCURR)  
         ' if DNEXTCURR = System.DateTime.MinValue then DNEXTCURR=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("DNEXTCURR", DNEXTCURR.Ticks)  
          node.SetAttribute("CHOUR", CHOUR)  
          node.SetAttribute("ICALL", ICALL)  
          node.SetAttribute("NUMHOUR", NUMHOUR)  
         ' if DNEXTHOUR = System.DateTime.MinValue then DNEXTHOUR=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("DNEXTHOUR", DNEXTHOUR.Ticks)  
         ' if DLASTHOUR = System.DateTime.MinValue then DLASTHOUR=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("DLASTHOUR", DLASTHOUR.Ticks)  
          node.SetAttribute("C24", C24)  
          node.SetAttribute("ICALL24", ICALL24)  
          node.SetAttribute("NUM24", NUM24)  
         ' if DNEXT24 = System.DateTime.MinValue then DNEXT24=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("DNEXT24", DNEXT24.Ticks)  
         ' if DLASTDAY = System.DateTime.MinValue then DLASTDAY=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("DLASTDAY", DLASTDAY.Ticks)  
          node.SetAttribute("CSUM", CSUM)  
          node.SetAttribute("ICALLSUM", ICALLSUM)  
         ' if DNEXTSUM = System.DateTime.MinValue then DNEXTSUM=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("DNEXTSUM", DNEXTSUM.Ticks)  
          node.SetAttribute("CEL", CEL)  
          node.SetAttribute("IEL", IEL)  
         ' if DNEXTEL = System.DateTime.MinValue then DNEXTEL=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("DNEXTEL", DNEXTEL.Ticks)  
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
