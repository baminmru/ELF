
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
'''Реализация строки раздела Договорные установки
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPLT_CONTRACT
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля № прибора
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD12  as String


''' <summary>
'''Локальная переменная для поля №ключа
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD13  as String


''' <summary>
'''Локальная переменная для поля D20ОБ
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD14  as String


''' <summary>
'''Локальная переменная для поля D20ПР
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD15  as String


''' <summary>
'''Локальная переменная для поля DyГВС
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD16  as String


''' <summary>
'''Локальная переменная для поля DyОБР
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD17  as String


''' <summary>
'''Локальная переменная для поля DyПР
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD18  as String


''' <summary>
'''Локальная переменная для поля dРпрОБ
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD19  as String


''' <summary>
'''Локальная переменная для поля dРпрПР
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD20  as String


''' <summary>
'''Локальная переменная для поля G(гвс)ПР
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD21  as String


''' <summary>
'''Локальная переменная для поля Gгвс
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD22  as String


''' <summary>
'''Локальная переменная для поля Gоб(гвс min)
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD23  as String


''' <summary>
'''Локальная переменная для поля Gов
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD24  as String


''' <summary>
'''Локальная переменная для поля Gпр(гвс min)
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD25  as String


''' <summary>
'''Локальная переменная для поля Gпр_minОБ
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD26  as String


''' <summary>
'''Локальная переменная для поля Gпр_minПР
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD27  as String


''' <summary>
'''Локальная переменная для поля GпрОБ
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD28  as String


''' <summary>
'''Локальная переменная для поля GпрПР
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD29  as String


''' <summary>
'''Локальная переменная для поля Gут
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD30  as String


''' <summary>
'''Локальная переменная для поля д20ОБ
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD31  as String


''' <summary>
'''Локальная переменная для поля д20ПР
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD32  as String


''' <summary>
'''Локальная переменная для поля Договор
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD33  as String


''' <summary>
'''Локальная переменная для поля Договор G2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD34  as String


''' <summary>
'''Локальная переменная для поля Договор G1
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD35  as String


''' <summary>
'''Локальная переменная для поля Источник
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD36  as String


''' <summary>
'''Локальная переменная для поля Магистраль
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD37  as String


''' <summary>
'''Локальная переменная для поля Расходомер
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD40  as String


''' <summary>
'''Локальная переменная для поля Расходомер ГВС
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD41  as String


''' <summary>
'''Локальная переменная для поля Робр
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD42  as String


''' <summary>
'''Локальная переменная для поля Рпр
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD43  as String


''' <summary>
'''Локальная переменная для поля Способ отбора
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD45  as String


''' <summary>
'''Локальная переменная для поля Т_график
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD46  as String


''' <summary>
'''Локальная переменная для поля Теп_камера
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD47  as String


''' <summary>
'''Локальная переменная для поля Тип расходомера
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD48  as String


''' <summary>
'''Локальная переменная для поля тип термометра
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD49  as String


''' <summary>
'''Локальная переменная для поля Формула
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD50  as String


''' <summary>
'''Локальная переменная для поля Наименование счетчика
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD51  as String


''' <summary>
'''Локальная переменная для поля Схема
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD52  as String


''' <summary>
'''Локальная переменная для поля Qот
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD53  as String


''' <summary>
'''Локальная переменная для поля Qв
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD54  as String


''' <summary>
'''Локальная переменная для поля Qгвс
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD55  as String


''' <summary>
'''Локальная переменная для поля Qну
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD56  as String


''' <summary>
'''Локальная переменная для поля Gот
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD57  as String


''' <summary>
'''Локальная переменная для поля Gв
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD58  as String


''' <summary>
'''Локальная переменная для поля Gну
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD59  as String


''' <summary>
'''Локальная переменная для поля Часов_архив
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD60  as String


''' <summary>
'''Локальная переменная для поля Сут_архив
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD61  as String


''' <summary>
'''Локальная переменная для поля Термопреобр ГВС
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD62  as String


''' <summary>
'''Локальная переменная для поля Т1
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD63  as String


''' <summary>
'''Локальная переменная для поля Т2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD64  as String


''' <summary>
'''Локальная переменная для поля Т3
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD65  as String


''' <summary>
'''Локальная переменная для поля Т4
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD66  as String


''' <summary>
'''Локальная переменная для поля Gтех
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD67  as String


''' <summary>
'''Локальная переменная для поля Gтех_гвс
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD68  as String


''' <summary>
'''Локальная переменная для поля Gгвс_м
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD69  as String


''' <summary>
'''Локальная переменная для поля Qтех
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD70  as String


''' <summary>
'''Локальная переменная для поля Qвент
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD71  as String


''' <summary>
'''Локальная переменная для поля Тхв
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD72  as String


''' <summary>
'''Локальная переменная для поля Расходомер ГВСц
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD73  as String


''' <summary>
'''Локальная переменная для поля Формула2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD81  as String


''' <summary>
'''Локальная переменная для поля Термопреобр
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD82  as String


''' <summary>
'''Локальная переменная для поля Gвент
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD83  as String


''' <summary>
'''Локальная переменная для поля Код УУТЭ
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD84  as String


''' <summary>
'''Локальная переменная для поля Сист_теплопотребления
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD85  as String


''' <summary>
'''Локальная переменная для поля Qтех_гвс
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD86  as String


''' <summary>
'''Локальная переменная для поля Qтех_гвс ср
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD87  as String


''' <summary>
'''Локальная переменная для поля Qгвс ср
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD88  as String


''' <summary>
'''Локальная переменная для поля Дата поверки
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD89  as String


''' <summary>
'''Локальная переменная для поля Фамилия
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD90  as String


''' <summary>
'''Локальная переменная для поля Узел учета
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD92  as String


''' <summary>
'''Локальная переменная для поля Стр.адрес
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD93  as String


''' <summary>
'''Локальная переменная для поля G(гвс)ОБР
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD94  as String


''' <summary>
'''Локальная переменная для поля DyГВСц
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD95  as String


''' <summary>
'''Локальная переменная для поля Цена_имп_M1
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD96  as String


''' <summary>
'''Локальная переменная для поля Цена_имп_M2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD97  as String


''' <summary>
'''Локальная переменная для поля Цена_имп_M1гв
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD98  as String


''' <summary>
'''Локальная переменная для поля Цена_имп_M2гв
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD99  as String


''' <summary>
'''Локальная переменная для поля Доп_погр_изм_M1%
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD100  as String


''' <summary>
'''Локальная переменная для поля Доп_погр_изм_M2%
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD101  as String


''' <summary>
'''Локальная переменная для поля Доп_погр_изм_M1гв%
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD102  as String


''' <summary>
'''Локальная переменная для поля Доп_погр_изм_M2гв%
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD103  as String


''' <summary>
'''Локальная переменная для поля Расходомер M2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FLD104  as String



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_FLD12=   
            ' m_FLD13=   
            ' m_FLD14=   
            ' m_FLD15=   
            ' m_FLD16=   
            ' m_FLD17=   
            ' m_FLD18=   
            ' m_FLD19=   
            ' m_FLD20=   
            ' m_FLD21=   
            ' m_FLD22=   
            ' m_FLD23=   
            ' m_FLD24=   
            ' m_FLD25=   
            ' m_FLD26=   
            ' m_FLD27=   
            ' m_FLD28=   
            ' m_FLD29=   
            ' m_FLD30=   
            ' m_FLD31=   
            ' m_FLD32=   
            ' m_FLD33=   
            ' m_FLD34=   
            ' m_FLD35=   
            ' m_FLD36=   
            ' m_FLD37=   
            ' m_FLD40=   
            ' m_FLD41=   
            ' m_FLD42=   
            ' m_FLD43=   
            ' m_FLD45=   
            ' m_FLD46=   
            ' m_FLD47=   
            ' m_FLD48=   
            ' m_FLD49=   
            ' m_FLD50=   
            ' m_FLD51=   
            ' m_FLD52=   
            ' m_FLD53=   
            ' m_FLD54=   
            ' m_FLD55=   
            ' m_FLD56=   
            ' m_FLD57=   
            ' m_FLD58=   
            ' m_FLD59=   
            ' m_FLD60=   
            ' m_FLD61=   
            ' m_FLD62=   
            ' m_FLD63=   
            ' m_FLD64=   
            ' m_FLD65=   
            ' m_FLD66=   
            ' m_FLD67=   
            ' m_FLD68=   
            ' m_FLD69=   
            ' m_FLD70=   
            ' m_FLD71=   
            ' m_FLD72=   
            ' m_FLD73=   
            ' m_FLD81=   
            ' m_FLD82=   
            ' m_FLD83=   
            ' m_FLD84=   
            ' m_FLD85=   
            ' m_FLD86=   
            ' m_FLD87=   
            ' m_FLD88=   
            ' m_FLD89=   
            ' m_FLD90=   
            ' m_FLD92=   
            ' m_FLD93=   
            ' m_FLD94=   
            ' m_FLD95=   
            ' m_FLD96=   
            ' m_FLD97=   
            ' m_FLD98=   
            ' m_FLD99=   
            ' m_FLD100=   
            ' m_FLD101=   
            ' m_FLD102=   
            ' m_FLD103=   
            ' m_FLD104=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 82
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
                    Value = FLD12
                Case 2
                    Value = FLD13
                Case 3
                    Value = FLD14
                Case 4
                    Value = FLD15
                Case 5
                    Value = FLD16
                Case 6
                    Value = FLD17
                Case 7
                    Value = FLD18
                Case 8
                    Value = FLD19
                Case 9
                    Value = FLD20
                Case 10
                    Value = FLD21
                Case 11
                    Value = FLD22
                Case 12
                    Value = FLD23
                Case 13
                    Value = FLD24
                Case 14
                    Value = FLD25
                Case 15
                    Value = FLD26
                Case 16
                    Value = FLD27
                Case 17
                    Value = FLD28
                Case 18
                    Value = FLD29
                Case 19
                    Value = FLD30
                Case 20
                    Value = FLD31
                Case 21
                    Value = FLD32
                Case 22
                    Value = FLD33
                Case 23
                    Value = FLD34
                Case 24
                    Value = FLD35
                Case 25
                    Value = FLD36
                Case 26
                    Value = FLD37
                Case 27
                    Value = FLD40
                Case 28
                    Value = FLD41
                Case 29
                    Value = FLD42
                Case 30
                    Value = FLD43
                Case 31
                    Value = FLD45
                Case 32
                    Value = FLD46
                Case 33
                    Value = FLD47
                Case 34
                    Value = FLD48
                Case 35
                    Value = FLD49
                Case 36
                    Value = FLD50
                Case 37
                    Value = FLD51
                Case 38
                    Value = FLD52
                Case 39
                    Value = FLD53
                Case 40
                    Value = FLD54
                Case 41
                    Value = FLD55
                Case 42
                    Value = FLD56
                Case 43
                    Value = FLD57
                Case 44
                    Value = FLD58
                Case 45
                    Value = FLD59
                Case 46
                    Value = FLD60
                Case 47
                    Value = FLD61
                Case 48
                    Value = FLD62
                Case 49
                    Value = FLD63
                Case 50
                    Value = FLD64
                Case 51
                    Value = FLD65
                Case 52
                    Value = FLD66
                Case 53
                    Value = FLD67
                Case 54
                    Value = FLD68
                Case 55
                    Value = FLD69
                Case 56
                    Value = FLD70
                Case 57
                    Value = FLD71
                Case 58
                    Value = FLD72
                Case 59
                    Value = FLD73
                Case 60
                    Value = FLD81
                Case 61
                    Value = FLD82
                Case 62
                    Value = FLD83
                Case 63
                    Value = FLD84
                Case 64
                    Value = FLD85
                Case 65
                    Value = FLD86
                Case 66
                    Value = FLD87
                Case 67
                    Value = FLD88
                Case 68
                    Value = FLD89
                Case 69
                    Value = FLD90
                Case 70
                    Value = FLD92
                Case 71
                    Value = FLD93
                Case 72
                    Value = FLD94
                Case 73
                    Value = FLD95
                Case 74
                    Value = FLD96
                Case 75
                    Value = FLD97
                Case 76
                    Value = FLD98
                Case 77
                    Value = FLD99
                Case 78
                    Value = FLD100
                Case 79
                    Value = FLD101
                Case 80
                    Value = FLD102
                Case 81
                    Value = FLD103
                Case 82
                    Value = FLD104
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
                    FLD12 = value
                Case 2
                    FLD13 = value
                Case 3
                    FLD14 = value
                Case 4
                    FLD15 = value
                Case 5
                    FLD16 = value
                Case 6
                    FLD17 = value
                Case 7
                    FLD18 = value
                Case 8
                    FLD19 = value
                Case 9
                    FLD20 = value
                Case 10
                    FLD21 = value
                Case 11
                    FLD22 = value
                Case 12
                    FLD23 = value
                Case 13
                    FLD24 = value
                Case 14
                    FLD25 = value
                Case 15
                    FLD26 = value
                Case 16
                    FLD27 = value
                Case 17
                    FLD28 = value
                Case 18
                    FLD29 = value
                Case 19
                    FLD30 = value
                Case 20
                    FLD31 = value
                Case 21
                    FLD32 = value
                Case 22
                    FLD33 = value
                Case 23
                    FLD34 = value
                Case 24
                    FLD35 = value
                Case 25
                    FLD36 = value
                Case 26
                    FLD37 = value
                Case 27
                    FLD40 = value
                Case 28
                    FLD41 = value
                Case 29
                    FLD42 = value
                Case 30
                    FLD43 = value
                Case 31
                    FLD45 = value
                Case 32
                    FLD46 = value
                Case 33
                    FLD47 = value
                Case 34
                    FLD48 = value
                Case 35
                    FLD49 = value
                Case 36
                    FLD50 = value
                Case 37
                    FLD51 = value
                Case 38
                    FLD52 = value
                Case 39
                    FLD53 = value
                Case 40
                    FLD54 = value
                Case 41
                    FLD55 = value
                Case 42
                    FLD56 = value
                Case 43
                    FLD57 = value
                Case 44
                    FLD58 = value
                Case 45
                    FLD59 = value
                Case 46
                    FLD60 = value
                Case 47
                    FLD61 = value
                Case 48
                    FLD62 = value
                Case 49
                    FLD63 = value
                Case 50
                    FLD64 = value
                Case 51
                    FLD65 = value
                Case 52
                    FLD66 = value
                Case 53
                    FLD67 = value
                Case 54
                    FLD68 = value
                Case 55
                    FLD69 = value
                Case 56
                    FLD70 = value
                Case 57
                    FLD71 = value
                Case 58
                    FLD72 = value
                Case 59
                    FLD73 = value
                Case 60
                    FLD81 = value
                Case 61
                    FLD82 = value
                Case 62
                    FLD83 = value
                Case 63
                    FLD84 = value
                Case 64
                    FLD85 = value
                Case 65
                    FLD86 = value
                Case 66
                    FLD87 = value
                Case 67
                    FLD88 = value
                Case 68
                    FLD89 = value
                Case 69
                    FLD90 = value
                Case 70
                    FLD92 = value
                Case 71
                    FLD93 = value
                Case 72
                    FLD94 = value
                Case 73
                    FLD95 = value
                Case 74
                    FLD96 = value
                Case 75
                    FLD97 = value
                Case 76
                    FLD98 = value
                Case 77
                    FLD99 = value
                Case 78
                    FLD100 = value
                Case 79
                    FLD101 = value
                Case 80
                    FLD102 = value
                Case 81
                    FLD103 = value
                Case 82
                    FLD104 = value
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
                    Return "FLD12"
                Case 2
                    Return "FLD13"
                Case 3
                    Return "FLD14"
                Case 4
                    Return "FLD15"
                Case 5
                    Return "FLD16"
                Case 6
                    Return "FLD17"
                Case 7
                    Return "FLD18"
                Case 8
                    Return "FLD19"
                Case 9
                    Return "FLD20"
                Case 10
                    Return "FLD21"
                Case 11
                    Return "FLD22"
                Case 12
                    Return "FLD23"
                Case 13
                    Return "FLD24"
                Case 14
                    Return "FLD25"
                Case 15
                    Return "FLD26"
                Case 16
                    Return "FLD27"
                Case 17
                    Return "FLD28"
                Case 18
                    Return "FLD29"
                Case 19
                    Return "FLD30"
                Case 20
                    Return "FLD31"
                Case 21
                    Return "FLD32"
                Case 22
                    Return "FLD33"
                Case 23
                    Return "FLD34"
                Case 24
                    Return "FLD35"
                Case 25
                    Return "FLD36"
                Case 26
                    Return "FLD37"
                Case 27
                    Return "FLD40"
                Case 28
                    Return "FLD41"
                Case 29
                    Return "FLD42"
                Case 30
                    Return "FLD43"
                Case 31
                    Return "FLD45"
                Case 32
                    Return "FLD46"
                Case 33
                    Return "FLD47"
                Case 34
                    Return "FLD48"
                Case 35
                    Return "FLD49"
                Case 36
                    Return "FLD50"
                Case 37
                    Return "FLD51"
                Case 38
                    Return "FLD52"
                Case 39
                    Return "FLD53"
                Case 40
                    Return "FLD54"
                Case 41
                    Return "FLD55"
                Case 42
                    Return "FLD56"
                Case 43
                    Return "FLD57"
                Case 44
                    Return "FLD58"
                Case 45
                    Return "FLD59"
                Case 46
                    Return "FLD60"
                Case 47
                    Return "FLD61"
                Case 48
                    Return "FLD62"
                Case 49
                    Return "FLD63"
                Case 50
                    Return "FLD64"
                Case 51
                    Return "FLD65"
                Case 52
                    Return "FLD66"
                Case 53
                    Return "FLD67"
                Case 54
                    Return "FLD68"
                Case 55
                    Return "FLD69"
                Case 56
                    Return "FLD70"
                Case 57
                    Return "FLD71"
                Case 58
                    Return "FLD72"
                Case 59
                    Return "FLD73"
                Case 60
                    Return "FLD81"
                Case 61
                    Return "FLD82"
                Case 62
                    Return "FLD83"
                Case 63
                    Return "FLD84"
                Case 64
                    Return "FLD85"
                Case 65
                    Return "FLD86"
                Case 66
                    Return "FLD87"
                Case 67
                    Return "FLD88"
                Case 68
                    Return "FLD89"
                Case 69
                    Return "FLD90"
                Case 70
                    Return "FLD92"
                Case 71
                    Return "FLD93"
                Case 72
                    Return "FLD94"
                Case 73
                    Return "FLD95"
                Case 74
                    Return "FLD96"
                Case 75
                    Return "FLD97"
                Case 76
                    Return "FLD98"
                Case 77
                    Return "FLD99"
                Case 78
                    Return "FLD100"
                Case 79
                    Return "FLD101"
                Case 80
                    Return "FLD102"
                Case 81
                    Return "FLD103"
                Case 82
                    Return "FLD104"
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
             dr("FLD12") =FLD12
             dr("FLD13") =FLD13
             dr("FLD14") =FLD14
             dr("FLD15") =FLD15
             dr("FLD16") =FLD16
             dr("FLD17") =FLD17
             dr("FLD18") =FLD18
             dr("FLD19") =FLD19
             dr("FLD20") =FLD20
             dr("FLD21") =FLD21
             dr("FLD22") =FLD22
             dr("FLD23") =FLD23
             dr("FLD24") =FLD24
             dr("FLD25") =FLD25
             dr("FLD26") =FLD26
             dr("FLD27") =FLD27
             dr("FLD28") =FLD28
             dr("FLD29") =FLD29
             dr("FLD30") =FLD30
             dr("FLD31") =FLD31
             dr("FLD32") =FLD32
             dr("FLD33") =FLD33
             dr("FLD34") =FLD34
             dr("FLD35") =FLD35
             dr("FLD36") =FLD36
             dr("FLD37") =FLD37
             dr("FLD40") =FLD40
             dr("FLD41") =FLD41
             dr("FLD42") =FLD42
             dr("FLD43") =FLD43
             dr("FLD45") =FLD45
             dr("FLD46") =FLD46
             dr("FLD47") =FLD47
             dr("FLD48") =FLD48
             dr("FLD49") =FLD49
             dr("FLD50") =FLD50
             dr("FLD51") =FLD51
             dr("FLD52") =FLD52
             dr("FLD53") =FLD53
             dr("FLD54") =FLD54
             dr("FLD55") =FLD55
             dr("FLD56") =FLD56
             dr("FLD57") =FLD57
             dr("FLD58") =FLD58
             dr("FLD59") =FLD59
             dr("FLD60") =FLD60
             dr("FLD61") =FLD61
             dr("FLD62") =FLD62
             dr("FLD63") =FLD63
             dr("FLD64") =FLD64
             dr("FLD65") =FLD65
             dr("FLD66") =FLD66
             dr("FLD67") =FLD67
             dr("FLD68") =FLD68
             dr("FLD69") =FLD69
             dr("FLD70") =FLD70
             dr("FLD71") =FLD71
             dr("FLD72") =FLD72
             dr("FLD73") =FLD73
             dr("FLD81") =FLD81
             dr("FLD82") =FLD82
             dr("FLD83") =FLD83
             dr("FLD84") =FLD84
             dr("FLD85") =FLD85
             dr("FLD86") =FLD86
             dr("FLD87") =FLD87
             dr("FLD88") =FLD88
             dr("FLD89") =FLD89
             dr("FLD90") =FLD90
             dr("FLD92") =FLD92
             dr("FLD93") =FLD93
             dr("FLD94") =FLD94
             dr("FLD95") =FLD95
             dr("FLD96") =FLD96
             dr("FLD97") =FLD97
             dr("FLD98") =FLD98
             dr("FLD99") =FLD99
             dr("FLD100") =FLD100
             dr("FLD101") =FLD101
             dr("FLD102") =FLD102
             dr("FLD103") =FLD103
             dr("FLD104") =FLD104
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
          nv.Add("FLD12", FLD12, dbtype.string)
          nv.Add("FLD13", FLD13, dbtype.string)
          nv.Add("FLD14", FLD14, dbtype.string)
          nv.Add("FLD15", FLD15, dbtype.string)
          nv.Add("FLD16", FLD16, dbtype.string)
          nv.Add("FLD17", FLD17, dbtype.string)
          nv.Add("FLD18", FLD18, dbtype.string)
          nv.Add("FLD19", FLD19, dbtype.string)
          nv.Add("FLD20", FLD20, dbtype.string)
          nv.Add("FLD21", FLD21, dbtype.string)
          nv.Add("FLD22", FLD22, dbtype.string)
          nv.Add("FLD23", FLD23, dbtype.string)
          nv.Add("FLD24", FLD24, dbtype.string)
          nv.Add("FLD25", FLD25, dbtype.string)
          nv.Add("FLD26", FLD26, dbtype.string)
          nv.Add("FLD27", FLD27, dbtype.string)
          nv.Add("FLD28", FLD28, dbtype.string)
          nv.Add("FLD29", FLD29, dbtype.string)
          nv.Add("FLD30", FLD30, dbtype.string)
          nv.Add("FLD31", FLD31, dbtype.string)
          nv.Add("FLD32", FLD32, dbtype.string)
          nv.Add("FLD33", FLD33, dbtype.string)
          nv.Add("FLD34", FLD34, dbtype.string)
          nv.Add("FLD35", FLD35, dbtype.string)
          nv.Add("FLD36", FLD36, dbtype.string)
          nv.Add("FLD37", FLD37, dbtype.string)
          nv.Add("FLD40", FLD40, dbtype.string)
          nv.Add("FLD41", FLD41, dbtype.string)
          nv.Add("FLD42", FLD42, dbtype.string)
          nv.Add("FLD43", FLD43, dbtype.string)
          nv.Add("FLD45", FLD45, dbtype.string)
          nv.Add("FLD46", FLD46, dbtype.string)
          nv.Add("FLD47", FLD47, dbtype.string)
          nv.Add("FLD48", FLD48, dbtype.string)
          nv.Add("FLD49", FLD49, dbtype.string)
          nv.Add("FLD50", FLD50, dbtype.string)
          nv.Add("FLD51", FLD51, dbtype.string)
          nv.Add("FLD52", FLD52, dbtype.string)
          nv.Add("FLD53", FLD53, dbtype.string)
          nv.Add("FLD54", FLD54, dbtype.string)
          nv.Add("FLD55", FLD55, dbtype.string)
          nv.Add("FLD56", FLD56, dbtype.string)
          nv.Add("FLD57", FLD57, dbtype.string)
          nv.Add("FLD58", FLD58, dbtype.string)
          nv.Add("FLD59", FLD59, dbtype.string)
          nv.Add("FLD60", FLD60, dbtype.string)
          nv.Add("FLD61", FLD61, dbtype.string)
          nv.Add("FLD62", FLD62, dbtype.string)
          nv.Add("FLD63", FLD63, dbtype.string)
          nv.Add("FLD64", FLD64, dbtype.string)
          nv.Add("FLD65", FLD65, dbtype.string)
          nv.Add("FLD66", FLD66, dbtype.string)
          nv.Add("FLD67", FLD67, dbtype.string)
          nv.Add("FLD68", FLD68, dbtype.string)
          nv.Add("FLD69", FLD69, dbtype.string)
          nv.Add("FLD70", FLD70, dbtype.string)
          nv.Add("FLD71", FLD71, dbtype.string)
          nv.Add("FLD72", FLD72, dbtype.string)
          nv.Add("FLD73", FLD73, dbtype.string)
          nv.Add("FLD81", FLD81, dbtype.string)
          nv.Add("FLD82", FLD82, dbtype.string)
          nv.Add("FLD83", FLD83, dbtype.string)
          nv.Add("FLD84", FLD84, dbtype.string)
          nv.Add("FLD85", FLD85, dbtype.string)
          nv.Add("FLD86", FLD86, dbtype.string)
          nv.Add("FLD87", FLD87, dbtype.string)
          nv.Add("FLD88", FLD88, dbtype.string)
          nv.Add("FLD89", FLD89, dbtype.string)
          nv.Add("FLD90", FLD90, dbtype.string)
          nv.Add("FLD92", FLD92, dbtype.string)
          nv.Add("FLD93", FLD93, dbtype.string)
          nv.Add("FLD94", FLD94, dbtype.string)
          nv.Add("FLD95", FLD95, dbtype.string)
          nv.Add("FLD96", FLD96, dbtype.string)
          nv.Add("FLD97", FLD97, dbtype.string)
          nv.Add("FLD98", FLD98, dbtype.string)
          nv.Add("FLD99", FLD99, dbtype.string)
          nv.Add("FLD100", FLD100, dbtype.string)
          nv.Add("FLD101", FLD101, dbtype.string)
          nv.Add("FLD102", FLD102, dbtype.string)
          nv.Add("FLD103", FLD103, dbtype.string)
          nv.Add("FLD104", FLD104, dbtype.string)
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
          If reader.Table.Columns.Contains("FLD12") Then m_FLD12=reader.item("FLD12").ToString()
          If reader.Table.Columns.Contains("FLD13") Then m_FLD13=reader.item("FLD13").ToString()
          If reader.Table.Columns.Contains("FLD14") Then m_FLD14=reader.item("FLD14").ToString()
          If reader.Table.Columns.Contains("FLD15") Then m_FLD15=reader.item("FLD15").ToString()
          If reader.Table.Columns.Contains("FLD16") Then m_FLD16=reader.item("FLD16").ToString()
          If reader.Table.Columns.Contains("FLD17") Then m_FLD17=reader.item("FLD17").ToString()
          If reader.Table.Columns.Contains("FLD18") Then m_FLD18=reader.item("FLD18").ToString()
          If reader.Table.Columns.Contains("FLD19") Then m_FLD19=reader.item("FLD19").ToString()
          If reader.Table.Columns.Contains("FLD20") Then m_FLD20=reader.item("FLD20").ToString()
          If reader.Table.Columns.Contains("FLD21") Then m_FLD21=reader.item("FLD21").ToString()
          If reader.Table.Columns.Contains("FLD22") Then m_FLD22=reader.item("FLD22").ToString()
          If reader.Table.Columns.Contains("FLD23") Then m_FLD23=reader.item("FLD23").ToString()
          If reader.Table.Columns.Contains("FLD24") Then m_FLD24=reader.item("FLD24").ToString()
          If reader.Table.Columns.Contains("FLD25") Then m_FLD25=reader.item("FLD25").ToString()
          If reader.Table.Columns.Contains("FLD26") Then m_FLD26=reader.item("FLD26").ToString()
          If reader.Table.Columns.Contains("FLD27") Then m_FLD27=reader.item("FLD27").ToString()
          If reader.Table.Columns.Contains("FLD28") Then m_FLD28=reader.item("FLD28").ToString()
          If reader.Table.Columns.Contains("FLD29") Then m_FLD29=reader.item("FLD29").ToString()
          If reader.Table.Columns.Contains("FLD30") Then m_FLD30=reader.item("FLD30").ToString()
          If reader.Table.Columns.Contains("FLD31") Then m_FLD31=reader.item("FLD31").ToString()
          If reader.Table.Columns.Contains("FLD32") Then m_FLD32=reader.item("FLD32").ToString()
          If reader.Table.Columns.Contains("FLD33") Then m_FLD33=reader.item("FLD33").ToString()
          If reader.Table.Columns.Contains("FLD34") Then m_FLD34=reader.item("FLD34").ToString()
          If reader.Table.Columns.Contains("FLD35") Then m_FLD35=reader.item("FLD35").ToString()
          If reader.Table.Columns.Contains("FLD36") Then m_FLD36=reader.item("FLD36").ToString()
          If reader.Table.Columns.Contains("FLD37") Then m_FLD37=reader.item("FLD37").ToString()
          If reader.Table.Columns.Contains("FLD40") Then m_FLD40=reader.item("FLD40").ToString()
          If reader.Table.Columns.Contains("FLD41") Then m_FLD41=reader.item("FLD41").ToString()
          If reader.Table.Columns.Contains("FLD42") Then m_FLD42=reader.item("FLD42").ToString()
          If reader.Table.Columns.Contains("FLD43") Then m_FLD43=reader.item("FLD43").ToString()
          If reader.Table.Columns.Contains("FLD45") Then m_FLD45=reader.item("FLD45").ToString()
          If reader.Table.Columns.Contains("FLD46") Then m_FLD46=reader.item("FLD46").ToString()
          If reader.Table.Columns.Contains("FLD47") Then m_FLD47=reader.item("FLD47").ToString()
          If reader.Table.Columns.Contains("FLD48") Then m_FLD48=reader.item("FLD48").ToString()
          If reader.Table.Columns.Contains("FLD49") Then m_FLD49=reader.item("FLD49").ToString()
          If reader.Table.Columns.Contains("FLD50") Then m_FLD50=reader.item("FLD50").ToString()
          If reader.Table.Columns.Contains("FLD51") Then m_FLD51=reader.item("FLD51").ToString()
          If reader.Table.Columns.Contains("FLD52") Then m_FLD52=reader.item("FLD52").ToString()
          If reader.Table.Columns.Contains("FLD53") Then m_FLD53=reader.item("FLD53").ToString()
          If reader.Table.Columns.Contains("FLD54") Then m_FLD54=reader.item("FLD54").ToString()
          If reader.Table.Columns.Contains("FLD55") Then m_FLD55=reader.item("FLD55").ToString()
          If reader.Table.Columns.Contains("FLD56") Then m_FLD56=reader.item("FLD56").ToString()
          If reader.Table.Columns.Contains("FLD57") Then m_FLD57=reader.item("FLD57").ToString()
          If reader.Table.Columns.Contains("FLD58") Then m_FLD58=reader.item("FLD58").ToString()
          If reader.Table.Columns.Contains("FLD59") Then m_FLD59=reader.item("FLD59").ToString()
          If reader.Table.Columns.Contains("FLD60") Then m_FLD60=reader.item("FLD60").ToString()
          If reader.Table.Columns.Contains("FLD61") Then m_FLD61=reader.item("FLD61").ToString()
          If reader.Table.Columns.Contains("FLD62") Then m_FLD62=reader.item("FLD62").ToString()
          If reader.Table.Columns.Contains("FLD63") Then m_FLD63=reader.item("FLD63").ToString()
          If reader.Table.Columns.Contains("FLD64") Then m_FLD64=reader.item("FLD64").ToString()
          If reader.Table.Columns.Contains("FLD65") Then m_FLD65=reader.item("FLD65").ToString()
          If reader.Table.Columns.Contains("FLD66") Then m_FLD66=reader.item("FLD66").ToString()
          If reader.Table.Columns.Contains("FLD67") Then m_FLD67=reader.item("FLD67").ToString()
          If reader.Table.Columns.Contains("FLD68") Then m_FLD68=reader.item("FLD68").ToString()
          If reader.Table.Columns.Contains("FLD69") Then m_FLD69=reader.item("FLD69").ToString()
          If reader.Table.Columns.Contains("FLD70") Then m_FLD70=reader.item("FLD70").ToString()
          If reader.Table.Columns.Contains("FLD71") Then m_FLD71=reader.item("FLD71").ToString()
          If reader.Table.Columns.Contains("FLD72") Then m_FLD72=reader.item("FLD72").ToString()
          If reader.Table.Columns.Contains("FLD73") Then m_FLD73=reader.item("FLD73").ToString()
          If reader.Table.Columns.Contains("FLD81") Then m_FLD81=reader.item("FLD81").ToString()
          If reader.Table.Columns.Contains("FLD82") Then m_FLD82=reader.item("FLD82").ToString()
          If reader.Table.Columns.Contains("FLD83") Then m_FLD83=reader.item("FLD83").ToString()
          If reader.Table.Columns.Contains("FLD84") Then m_FLD84=reader.item("FLD84").ToString()
          If reader.Table.Columns.Contains("FLD85") Then m_FLD85=reader.item("FLD85").ToString()
          If reader.Table.Columns.Contains("FLD86") Then m_FLD86=reader.item("FLD86").ToString()
          If reader.Table.Columns.Contains("FLD87") Then m_FLD87=reader.item("FLD87").ToString()
          If reader.Table.Columns.Contains("FLD88") Then m_FLD88=reader.item("FLD88").ToString()
          If reader.Table.Columns.Contains("FLD89") Then m_FLD89=reader.item("FLD89").ToString()
          If reader.Table.Columns.Contains("FLD90") Then m_FLD90=reader.item("FLD90").ToString()
          If reader.Table.Columns.Contains("FLD92") Then m_FLD92=reader.item("FLD92").ToString()
          If reader.Table.Columns.Contains("FLD93") Then m_FLD93=reader.item("FLD93").ToString()
          If reader.Table.Columns.Contains("FLD94") Then m_FLD94=reader.item("FLD94").ToString()
          If reader.Table.Columns.Contains("FLD95") Then m_FLD95=reader.item("FLD95").ToString()
          If reader.Table.Columns.Contains("FLD96") Then m_FLD96=reader.item("FLD96").ToString()
          If reader.Table.Columns.Contains("FLD97") Then m_FLD97=reader.item("FLD97").ToString()
          If reader.Table.Columns.Contains("FLD98") Then m_FLD98=reader.item("FLD98").ToString()
          If reader.Table.Columns.Contains("FLD99") Then m_FLD99=reader.item("FLD99").ToString()
          If reader.Table.Columns.Contains("FLD100") Then m_FLD100=reader.item("FLD100").ToString()
          If reader.Table.Columns.Contains("FLD101") Then m_FLD101=reader.item("FLD101").ToString()
          If reader.Table.Columns.Contains("FLD102") Then m_FLD102=reader.item("FLD102").ToString()
          If reader.Table.Columns.Contains("FLD103") Then m_FLD103=reader.item("FLD103").ToString()
          If reader.Table.Columns.Contains("FLD104") Then m_FLD104=reader.item("FLD104").ToString()
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю № прибора
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD12() As String
            Get
                LoadFromDatabase()
                FLD12 = m_FLD12
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD12 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю №ключа
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD13() As String
            Get
                LoadFromDatabase()
                FLD13 = m_FLD13
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD13 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю D20ОБ
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD14() As String
            Get
                LoadFromDatabase()
                FLD14 = m_FLD14
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD14 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю D20ПР
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD15() As String
            Get
                LoadFromDatabase()
                FLD15 = m_FLD15
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD15 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю DyГВС
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD16() As String
            Get
                LoadFromDatabase()
                FLD16 = m_FLD16
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD16 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю DyОБР
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD17() As String
            Get
                LoadFromDatabase()
                FLD17 = m_FLD17
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD17 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю DyПР
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD18() As String
            Get
                LoadFromDatabase()
                FLD18 = m_FLD18
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD18 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю dРпрОБ
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD19() As String
            Get
                LoadFromDatabase()
                FLD19 = m_FLD19
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD19 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю dРпрПР
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD20() As String
            Get
                LoadFromDatabase()
                FLD20 = m_FLD20
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD20 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю G(гвс)ПР
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD21() As String
            Get
                LoadFromDatabase()
                FLD21 = m_FLD21
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD21 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Gгвс
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD22() As String
            Get
                LoadFromDatabase()
                FLD22 = m_FLD22
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD22 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Gоб(гвс min)
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD23() As String
            Get
                LoadFromDatabase()
                FLD23 = m_FLD23
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD23 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Gов
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD24() As String
            Get
                LoadFromDatabase()
                FLD24 = m_FLD24
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD24 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Gпр(гвс min)
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD25() As String
            Get
                LoadFromDatabase()
                FLD25 = m_FLD25
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD25 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Gпр_minОБ
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD26() As String
            Get
                LoadFromDatabase()
                FLD26 = m_FLD26
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD26 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Gпр_minПР
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD27() As String
            Get
                LoadFromDatabase()
                FLD27 = m_FLD27
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD27 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю GпрОБ
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD28() As String
            Get
                LoadFromDatabase()
                FLD28 = m_FLD28
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD28 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю GпрПР
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD29() As String
            Get
                LoadFromDatabase()
                FLD29 = m_FLD29
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD29 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Gут
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD30() As String
            Get
                LoadFromDatabase()
                FLD30 = m_FLD30
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD30 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю д20ОБ
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD31() As String
            Get
                LoadFromDatabase()
                FLD31 = m_FLD31
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD31 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю д20ПР
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD32() As String
            Get
                LoadFromDatabase()
                FLD32 = m_FLD32
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD32 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Договор
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD33() As String
            Get
                LoadFromDatabase()
                FLD33 = m_FLD33
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD33 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Договор G2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD34() As String
            Get
                LoadFromDatabase()
                FLD34 = m_FLD34
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD34 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Договор G1
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD35() As String
            Get
                LoadFromDatabase()
                FLD35 = m_FLD35
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD35 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Источник
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD36() As String
            Get
                LoadFromDatabase()
                FLD36 = m_FLD36
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD36 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Магистраль
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD37() As String
            Get
                LoadFromDatabase()
                FLD37 = m_FLD37
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD37 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Расходомер
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD40() As String
            Get
                LoadFromDatabase()
                FLD40 = m_FLD40
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD40 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Расходомер ГВС
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD41() As String
            Get
                LoadFromDatabase()
                FLD41 = m_FLD41
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD41 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Робр
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD42() As String
            Get
                LoadFromDatabase()
                FLD42 = m_FLD42
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD42 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Рпр
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD43() As String
            Get
                LoadFromDatabase()
                FLD43 = m_FLD43
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD43 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Способ отбора
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD45() As String
            Get
                LoadFromDatabase()
                FLD45 = m_FLD45
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD45 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Т_график
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD46() As String
            Get
                LoadFromDatabase()
                FLD46 = m_FLD46
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD46 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Теп_камера
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD47() As String
            Get
                LoadFromDatabase()
                FLD47 = m_FLD47
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD47 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Тип расходомера
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD48() As String
            Get
                LoadFromDatabase()
                FLD48 = m_FLD48
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD48 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю тип термометра
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD49() As String
            Get
                LoadFromDatabase()
                FLD49 = m_FLD49
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD49 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Формула
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD50() As String
            Get
                LoadFromDatabase()
                FLD50 = m_FLD50
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD50 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Наименование счетчика
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD51() As String
            Get
                LoadFromDatabase()
                FLD51 = m_FLD51
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD51 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Схема
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD52() As String
            Get
                LoadFromDatabase()
                FLD52 = m_FLD52
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD52 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Qот
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD53() As String
            Get
                LoadFromDatabase()
                FLD53 = m_FLD53
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD53 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Qв
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD54() As String
            Get
                LoadFromDatabase()
                FLD54 = m_FLD54
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD54 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Qгвс
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD55() As String
            Get
                LoadFromDatabase()
                FLD55 = m_FLD55
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD55 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Qну
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD56() As String
            Get
                LoadFromDatabase()
                FLD56 = m_FLD56
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD56 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Gот
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD57() As String
            Get
                LoadFromDatabase()
                FLD57 = m_FLD57
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD57 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Gв
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD58() As String
            Get
                LoadFromDatabase()
                FLD58 = m_FLD58
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD58 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Gну
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD59() As String
            Get
                LoadFromDatabase()
                FLD59 = m_FLD59
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD59 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Часов_архив
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD60() As String
            Get
                LoadFromDatabase()
                FLD60 = m_FLD60
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD60 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Сут_архив
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD61() As String
            Get
                LoadFromDatabase()
                FLD61 = m_FLD61
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD61 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Термопреобр ГВС
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD62() As String
            Get
                LoadFromDatabase()
                FLD62 = m_FLD62
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD62 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Т1
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD63() As String
            Get
                LoadFromDatabase()
                FLD63 = m_FLD63
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD63 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Т2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD64() As String
            Get
                LoadFromDatabase()
                FLD64 = m_FLD64
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD64 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Т3
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD65() As String
            Get
                LoadFromDatabase()
                FLD65 = m_FLD65
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD65 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Т4
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD66() As String
            Get
                LoadFromDatabase()
                FLD66 = m_FLD66
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD66 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Gтех
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD67() As String
            Get
                LoadFromDatabase()
                FLD67 = m_FLD67
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD67 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Gтех_гвс
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD68() As String
            Get
                LoadFromDatabase()
                FLD68 = m_FLD68
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD68 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Gгвс_м
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD69() As String
            Get
                LoadFromDatabase()
                FLD69 = m_FLD69
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD69 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Qтех
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD70() As String
            Get
                LoadFromDatabase()
                FLD70 = m_FLD70
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD70 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Qвент
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD71() As String
            Get
                LoadFromDatabase()
                FLD71 = m_FLD71
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD71 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Тхв
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD72() As String
            Get
                LoadFromDatabase()
                FLD72 = m_FLD72
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD72 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Расходомер ГВСц
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD73() As String
            Get
                LoadFromDatabase()
                FLD73 = m_FLD73
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD73 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Формула2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD81() As String
            Get
                LoadFromDatabase()
                FLD81 = m_FLD81
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD81 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Термопреобр
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD82() As String
            Get
                LoadFromDatabase()
                FLD82 = m_FLD82
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD82 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Gвент
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD83() As String
            Get
                LoadFromDatabase()
                FLD83 = m_FLD83
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD83 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Код УУТЭ
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD84() As String
            Get
                LoadFromDatabase()
                FLD84 = m_FLD84
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD84 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Сист_теплопотребления
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD85() As String
            Get
                LoadFromDatabase()
                FLD85 = m_FLD85
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD85 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Qтех_гвс
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD86() As String
            Get
                LoadFromDatabase()
                FLD86 = m_FLD86
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD86 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Qтех_гвс ср
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD87() As String
            Get
                LoadFromDatabase()
                FLD87 = m_FLD87
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD87 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Qгвс ср
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD88() As String
            Get
                LoadFromDatabase()
                FLD88 = m_FLD88
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD88 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Дата поверки
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD89() As String
            Get
                LoadFromDatabase()
                FLD89 = m_FLD89
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD89 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Фамилия
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD90() As String
            Get
                LoadFromDatabase()
                FLD90 = m_FLD90
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD90 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Узел учета
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD92() As String
            Get
                LoadFromDatabase()
                FLD92 = m_FLD92
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD92 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Стр.адрес
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD93() As String
            Get
                LoadFromDatabase()
                FLD93 = m_FLD93
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD93 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю G(гвс)ОБР
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD94() As String
            Get
                LoadFromDatabase()
                FLD94 = m_FLD94
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD94 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю DyГВСц
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD95() As String
            Get
                LoadFromDatabase()
                FLD95 = m_FLD95
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD95 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Цена_имп_M1
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD96() As String
            Get
                LoadFromDatabase()
                FLD96 = m_FLD96
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD96 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Цена_имп_M2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD97() As String
            Get
                LoadFromDatabase()
                FLD97 = m_FLD97
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD97 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Цена_имп_M1гв
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD98() As String
            Get
                LoadFromDatabase()
                FLD98 = m_FLD98
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD98 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Цена_имп_M2гв
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD99() As String
            Get
                LoadFromDatabase()
                FLD99 = m_FLD99
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD99 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Доп_погр_изм_M1%
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD100() As String
            Get
                LoadFromDatabase()
                FLD100 = m_FLD100
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD100 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Доп_погр_изм_M2%
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD101() As String
            Get
                LoadFromDatabase()
                FLD101 = m_FLD101
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD101 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Доп_погр_изм_M1гв%
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD102() As String
            Get
                LoadFromDatabase()
                FLD102 = m_FLD102
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD102 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Доп_погр_изм_M2гв%
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD103() As String
            Get
                LoadFromDatabase()
                FLD103 = m_FLD103
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD103 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Расходомер M2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FLD104() As String
            Get
                LoadFromDatabase()
                FLD104 = m_FLD104
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FLD104 = Value
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
            FLD12 = node.Attributes.GetNamedItem("FLD12").Value
            FLD13 = node.Attributes.GetNamedItem("FLD13").Value
            FLD14 = node.Attributes.GetNamedItem("FLD14").Value
            FLD15 = node.Attributes.GetNamedItem("FLD15").Value
            FLD16 = node.Attributes.GetNamedItem("FLD16").Value
            FLD17 = node.Attributes.GetNamedItem("FLD17").Value
            FLD18 = node.Attributes.GetNamedItem("FLD18").Value
            FLD19 = node.Attributes.GetNamedItem("FLD19").Value
            FLD20 = node.Attributes.GetNamedItem("FLD20").Value
            FLD21 = node.Attributes.GetNamedItem("FLD21").Value
            FLD22 = node.Attributes.GetNamedItem("FLD22").Value
            FLD23 = node.Attributes.GetNamedItem("FLD23").Value
            FLD24 = node.Attributes.GetNamedItem("FLD24").Value
            FLD25 = node.Attributes.GetNamedItem("FLD25").Value
            FLD26 = node.Attributes.GetNamedItem("FLD26").Value
            FLD27 = node.Attributes.GetNamedItem("FLD27").Value
            FLD28 = node.Attributes.GetNamedItem("FLD28").Value
            FLD29 = node.Attributes.GetNamedItem("FLD29").Value
            FLD30 = node.Attributes.GetNamedItem("FLD30").Value
            FLD31 = node.Attributes.GetNamedItem("FLD31").Value
            FLD32 = node.Attributes.GetNamedItem("FLD32").Value
            FLD33 = node.Attributes.GetNamedItem("FLD33").Value
            FLD34 = node.Attributes.GetNamedItem("FLD34").Value
            FLD35 = node.Attributes.GetNamedItem("FLD35").Value
            FLD36 = node.Attributes.GetNamedItem("FLD36").Value
            FLD37 = node.Attributes.GetNamedItem("FLD37").Value
            FLD40 = node.Attributes.GetNamedItem("FLD40").Value
            FLD41 = node.Attributes.GetNamedItem("FLD41").Value
            FLD42 = node.Attributes.GetNamedItem("FLD42").Value
            FLD43 = node.Attributes.GetNamedItem("FLD43").Value
            FLD45 = node.Attributes.GetNamedItem("FLD45").Value
            FLD46 = node.Attributes.GetNamedItem("FLD46").Value
            FLD47 = node.Attributes.GetNamedItem("FLD47").Value
            FLD48 = node.Attributes.GetNamedItem("FLD48").Value
            FLD49 = node.Attributes.GetNamedItem("FLD49").Value
            FLD50 = node.Attributes.GetNamedItem("FLD50").Value
            FLD51 = node.Attributes.GetNamedItem("FLD51").Value
            FLD52 = node.Attributes.GetNamedItem("FLD52").Value
            FLD53 = node.Attributes.GetNamedItem("FLD53").Value
            FLD54 = node.Attributes.GetNamedItem("FLD54").Value
            FLD55 = node.Attributes.GetNamedItem("FLD55").Value
            FLD56 = node.Attributes.GetNamedItem("FLD56").Value
            FLD57 = node.Attributes.GetNamedItem("FLD57").Value
            FLD58 = node.Attributes.GetNamedItem("FLD58").Value
            FLD59 = node.Attributes.GetNamedItem("FLD59").Value
            FLD60 = node.Attributes.GetNamedItem("FLD60").Value
            FLD61 = node.Attributes.GetNamedItem("FLD61").Value
            FLD62 = node.Attributes.GetNamedItem("FLD62").Value
            FLD63 = node.Attributes.GetNamedItem("FLD63").Value
            FLD64 = node.Attributes.GetNamedItem("FLD64").Value
            FLD65 = node.Attributes.GetNamedItem("FLD65").Value
            FLD66 = node.Attributes.GetNamedItem("FLD66").Value
            FLD67 = node.Attributes.GetNamedItem("FLD67").Value
            FLD68 = node.Attributes.GetNamedItem("FLD68").Value
            FLD69 = node.Attributes.GetNamedItem("FLD69").Value
            FLD70 = node.Attributes.GetNamedItem("FLD70").Value
            FLD71 = node.Attributes.GetNamedItem("FLD71").Value
            FLD72 = node.Attributes.GetNamedItem("FLD72").Value
            FLD73 = node.Attributes.GetNamedItem("FLD73").Value
            FLD81 = node.Attributes.GetNamedItem("FLD81").Value
            FLD82 = node.Attributes.GetNamedItem("FLD82").Value
            FLD83 = node.Attributes.GetNamedItem("FLD83").Value
            FLD84 = node.Attributes.GetNamedItem("FLD84").Value
            FLD85 = node.Attributes.GetNamedItem("FLD85").Value
            FLD86 = node.Attributes.GetNamedItem("FLD86").Value
            FLD87 = node.Attributes.GetNamedItem("FLD87").Value
            FLD88 = node.Attributes.GetNamedItem("FLD88").Value
            FLD89 = node.Attributes.GetNamedItem("FLD89").Value
            FLD90 = node.Attributes.GetNamedItem("FLD90").Value
            FLD92 = node.Attributes.GetNamedItem("FLD92").Value
            FLD93 = node.Attributes.GetNamedItem("FLD93").Value
            FLD94 = node.Attributes.GetNamedItem("FLD94").Value
            FLD95 = node.Attributes.GetNamedItem("FLD95").Value
            FLD96 = node.Attributes.GetNamedItem("FLD96").Value
            FLD97 = node.Attributes.GetNamedItem("FLD97").Value
            FLD98 = node.Attributes.GetNamedItem("FLD98").Value
            FLD99 = node.Attributes.GetNamedItem("FLD99").Value
            FLD100 = node.Attributes.GetNamedItem("FLD100").Value
            FLD101 = node.Attributes.GetNamedItem("FLD101").Value
            FLD102 = node.Attributes.GetNamedItem("FLD102").Value
            FLD103 = node.Attributes.GetNamedItem("FLD103").Value
            FLD104 = node.Attributes.GetNamedItem("FLD104").Value
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
          node.SetAttribute("FLD12", FLD12)  
          node.SetAttribute("FLD13", FLD13)  
          node.SetAttribute("FLD14", FLD14)  
          node.SetAttribute("FLD15", FLD15)  
          node.SetAttribute("FLD16", FLD16)  
          node.SetAttribute("FLD17", FLD17)  
          node.SetAttribute("FLD18", FLD18)  
          node.SetAttribute("FLD19", FLD19)  
          node.SetAttribute("FLD20", FLD20)  
          node.SetAttribute("FLD21", FLD21)  
          node.SetAttribute("FLD22", FLD22)  
          node.SetAttribute("FLD23", FLD23)  
          node.SetAttribute("FLD24", FLD24)  
          node.SetAttribute("FLD25", FLD25)  
          node.SetAttribute("FLD26", FLD26)  
          node.SetAttribute("FLD27", FLD27)  
          node.SetAttribute("FLD28", FLD28)  
          node.SetAttribute("FLD29", FLD29)  
          node.SetAttribute("FLD30", FLD30)  
          node.SetAttribute("FLD31", FLD31)  
          node.SetAttribute("FLD32", FLD32)  
          node.SetAttribute("FLD33", FLD33)  
          node.SetAttribute("FLD34", FLD34)  
          node.SetAttribute("FLD35", FLD35)  
          node.SetAttribute("FLD36", FLD36)  
          node.SetAttribute("FLD37", FLD37)  
          node.SetAttribute("FLD40", FLD40)  
          node.SetAttribute("FLD41", FLD41)  
          node.SetAttribute("FLD42", FLD42)  
          node.SetAttribute("FLD43", FLD43)  
          node.SetAttribute("FLD45", FLD45)  
          node.SetAttribute("FLD46", FLD46)  
          node.SetAttribute("FLD47", FLD47)  
          node.SetAttribute("FLD48", FLD48)  
          node.SetAttribute("FLD49", FLD49)  
          node.SetAttribute("FLD50", FLD50)  
          node.SetAttribute("FLD51", FLD51)  
          node.SetAttribute("FLD52", FLD52)  
          node.SetAttribute("FLD53", FLD53)  
          node.SetAttribute("FLD54", FLD54)  
          node.SetAttribute("FLD55", FLD55)  
          node.SetAttribute("FLD56", FLD56)  
          node.SetAttribute("FLD57", FLD57)  
          node.SetAttribute("FLD58", FLD58)  
          node.SetAttribute("FLD59", FLD59)  
          node.SetAttribute("FLD60", FLD60)  
          node.SetAttribute("FLD61", FLD61)  
          node.SetAttribute("FLD62", FLD62)  
          node.SetAttribute("FLD63", FLD63)  
          node.SetAttribute("FLD64", FLD64)  
          node.SetAttribute("FLD65", FLD65)  
          node.SetAttribute("FLD66", FLD66)  
          node.SetAttribute("FLD67", FLD67)  
          node.SetAttribute("FLD68", FLD68)  
          node.SetAttribute("FLD69", FLD69)  
          node.SetAttribute("FLD70", FLD70)  
          node.SetAttribute("FLD71", FLD71)  
          node.SetAttribute("FLD72", FLD72)  
          node.SetAttribute("FLD73", FLD73)  
          node.SetAttribute("FLD81", FLD81)  
          node.SetAttribute("FLD82", FLD82)  
          node.SetAttribute("FLD83", FLD83)  
          node.SetAttribute("FLD84", FLD84)  
          node.SetAttribute("FLD85", FLD85)  
          node.SetAttribute("FLD86", FLD86)  
          node.SetAttribute("FLD87", FLD87)  
          node.SetAttribute("FLD88", FLD88)  
          node.SetAttribute("FLD89", FLD89)  
          node.SetAttribute("FLD90", FLD90)  
          node.SetAttribute("FLD92", FLD92)  
          node.SetAttribute("FLD93", FLD93)  
          node.SetAttribute("FLD94", FLD94)  
          node.SetAttribute("FLD95", FLD95)  
          node.SetAttribute("FLD96", FLD96)  
          node.SetAttribute("FLD97", FLD97)  
          node.SetAttribute("FLD98", FLD98)  
          node.SetAttribute("FLD99", FLD99)  
          node.SetAttribute("FLD100", FLD100)  
          node.SetAttribute("FLD101", FLD101)  
          node.SetAttribute("FLD102", FLD102)  
          node.SetAttribute("FLD103", FLD103)  
          node.SetAttribute("FLD104", FLD104)  
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
