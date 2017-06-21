
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
'''Реализация строки раздела Суммарные показатели
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPLC_T
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
'''Локальная переменная для поля Тепловая энергия канал 1
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Q1  as double


''' <summary>
'''Локальная переменная для поля Тепловая энергия канал 2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Q2  as double


''' <summary>
'''Локальная переменная для поля Температура по каналу 1
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_T1  as double


''' <summary>
'''Локальная переменная для поля Температура по каналу 2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_T2  as double


''' <summary>
'''Локальная переменная для поля Разность Температур по каналу 1 и 2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DT12  as double


''' <summary>
'''Локальная переменная для поля Температура по каналу 3
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_T3  as double


''' <summary>
'''Локальная переменная для поля Температура по каналу 4
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_T4  as double


''' <summary>
'''Локальная переменная для поля Температура по каналу 5
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_T5  as double


''' <summary>
'''Локальная переменная для поля Разность Температур по каналу 4 и 5
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DT45  as double


''' <summary>
'''Локальная переменная для поля Температура по каналу 6
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_T6  as double


''' <summary>
'''Локальная переменная для поля Объемный расход воды по каналу 1
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_V1  as double


''' <summary>
'''Локальная переменная для поля Объемный расход воды по каналу 2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_V2  as double


''' <summary>
'''Локальная переменная для поля Разность объемов канал 1  (расход ГВС)
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DV12  as double


''' <summary>
'''Локальная переменная для поля Объемный расход воды по каналу 3
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_V3  as double


''' <summary>
'''Локальная переменная для поля Объемный расход воды по каналу 4
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_V4  as double


''' <summary>
'''Локальная переменная для поля Объемный расход воды по каналу 5
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_V5  as double


''' <summary>
'''Локальная переменная для поля Разность объемов канал 2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DV45  as double


''' <summary>
'''Локальная переменная для поля Объемный расход воды по каналу 6
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_V6  as double


''' <summary>
'''Локальная переменная для поля Масса воды по каналу 1
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_M1  as double


''' <summary>
'''Локальная переменная для поля Масса воды по каналу 2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_M2  as double


''' <summary>
'''Локальная переменная для поля Разность масс канал 1  (расход ГВС)
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DM12  as double


''' <summary>
'''Локальная переменная для поля Масса воды по каналу 3
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_M3  as double


''' <summary>
'''Локальная переменная для поля Масса воды по каналу 4
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_M4  as double


''' <summary>
'''Локальная переменная для поля Масса воды по каналу 5
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_M5  as double


''' <summary>
'''Локальная переменная для поля Разность масс канал 2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DM45  as double


''' <summary>
'''Локальная переменная для поля Масса воды по каналу 6
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_M6  as double


''' <summary>
'''Локальная переменная для поля Давление в трубопроводе 1
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_P1  as double


''' <summary>
'''Локальная переменная для поля Давление в трубопроводе 2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_P2  as double


''' <summary>
'''Локальная переменная для поля Давление в трубопроводе 3
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_P3  as double


''' <summary>
'''Локальная переменная для поля Давление в трубопроводе 4
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_P4  as double


''' <summary>
'''Локальная переменная для поля Давление в трубопроводе 5
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_P5  as double


''' <summary>
'''Локальная переменная для поля Давление в трубопроводе 6
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_P6  as double


''' <summary>
'''Локальная переменная для поля Текущее значение расхода в трубопроводе 1
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_G1  as double


''' <summary>
'''Локальная переменная для поля Текущее значение расхода в трубопроводе 2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_G2  as double


''' <summary>
'''Локальная переменная для поля Текущее значение расхода в трубопроводе 3
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_G3  as double


''' <summary>
'''Локальная переменная для поля Текущее значение расхода в трубопроводе 4
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_G4  as double


''' <summary>
'''Локальная переменная для поля Текущее значение расхода в трубопроводе 5
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_G5  as double


''' <summary>
'''Локальная переменная для поля Текущее значение расхода в трубопроводе 6
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_G6  as double


''' <summary>
'''Локальная переменная для поля Температура холодной воды
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TCOOL  as double


''' <summary>
'''Локальная переменная для поля Температура холодного конца канал 1
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TCE1  as double


''' <summary>
'''Локальная переменная для поля Температура холодного конца канал 2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TCE2  as double


''' <summary>
'''Локальная переменная для поля Тотальное время счета TB1
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TSUM1  as double


''' <summary>
'''Локальная переменная для поля Тотальное время счета TB2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TSUM2  as double


''' <summary>
'''Локальная переменная для поля Тепловая энергия канал 1 нарастающим итогом
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Q1H  as double


''' <summary>
'''Локальная переменная для поля Тепловая энергия канал 2 нарастающим итогом
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Q2H  as double


''' <summary>
'''Локальная переменная для поля Объемный расход воды по каналу 1  нарастающим итогом
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_V1H  as double


''' <summary>
'''Локальная переменная для поля Объемный расход воды по каналу 2  нарастающим итогом
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_V2H  as double


''' <summary>
'''Локальная переменная для поля Объемный расход воды по каналу 4  нарастающим итогом
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_V4H  as double


''' <summary>
'''Локальная переменная для поля Объемный расход воды по каналу 5  нарастающим итогом
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_V5H  as double


''' <summary>
'''Локальная переменная для поля Время аварии
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ERRTIME  as double


''' <summary>
'''Локальная переменная для поля Время аварии нарастающим итогом
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ERRTIMEH  as double


''' <summary>
'''Локальная переменная для поля Нештатные ситуации общ
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_HC  as String


''' <summary>
'''Локальная переменная для поля Схема потребления
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_SP  as double


''' <summary>
'''Локальная переменная для поля Схема потребления TB1
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_SP_TB1  as double


''' <summary>
'''Локальная переменная для поля Схема потребления TB2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_SP_TB2  as double


''' <summary>
'''Локальная переменная для поля datetimeCOUNTER
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_datetimeCOUNTER  as DATE


''' <summary>
'''Локальная переменная для поля G1-G2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DG12  as double


''' <summary>
'''Локальная переменная для поля G4-G5
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DG45  as double


''' <summary>
'''Локальная переменная для поля P1-P2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DP12  as double


''' <summary>
'''Локальная переменная для поля P4-P5
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DP45  as double


''' <summary>
'''Локальная переменная для поля Единицы измерения расхода
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_UNITSR  as String


''' <summary>
'''Локальная переменная для поля Тепловая энергия канал 3
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Q3  as double


''' <summary>
'''Локальная переменная для поля Тепловая энергия канал 4
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Q4  as double


''' <summary>
'''Локальная переменная для поля Атмосферное давление
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_PATM  as double


''' <summary>
'''Локальная переменная для поля Тепловая энергия канал 5
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Q5  as double


''' <summary>
'''Локальная переменная для поля Тепловая энергия потребитель 1
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DQ12  as double


''' <summary>
'''Локальная переменная для поля Тепловая энергия потребитель 2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DQ45  as double


''' <summary>
'''Локальная переменная для поля Давление холодной воды
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_PXB  as double


''' <summary>
'''Локальная переменная для поля Расход энергии потребитель 1
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DQ  as double


''' <summary>
'''Локальная переменная для поля Нештатная ситуация 1 (ТВ1 или внешняя)
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_HC_1  as String


''' <summary>
'''Локальная переменная для поля Нештатная ситуация 2 (ТВ2 или внутренняя)
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_HC_2  as String


''' <summary>
'''Локальная переменная для поля Температура горячей воды
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_THOT  as double


''' <summary>
'''Локальная переменная для поля DANS1
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DANS1  as double


''' <summary>
'''Локальная переменная для поля DANS2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DANS2  as double


''' <summary>
'''Локальная переменная для поля DANS3
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DANS3  as double


''' <summary>
'''Локальная переменная для поля DANS4
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DANS4  as double


''' <summary>
'''Локальная переменная для поля DANS5
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DANS5  as double


''' <summary>
'''Локальная переменная для поля DANS6
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DANS6  as double


''' <summary>
'''Локальная переменная для поля Проверка архивных данных на НС (0 - не производилась, 1 - произведена)
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_CHECK_A  as double


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
'''Локальная переменная для поля Температура воздуха канал 1
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TAIR1  as double


''' <summary>
'''Локальная переменная для поля Температура воздуха канал 2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TAIR2  as double


''' <summary>
'''Локальная переменная для поля Код нештатной ситуации тепловычислителя
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_HC_CODE  as String



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_DCALL=   
            ' m_DCOUNTER=   
            ' m_Q1=   
            ' m_Q2=   
            ' m_T1=   
            ' m_T2=   
            ' m_DT12=   
            ' m_T3=   
            ' m_T4=   
            ' m_T5=   
            ' m_DT45=   
            ' m_T6=   
            ' m_V1=   
            ' m_V2=   
            ' m_DV12=   
            ' m_V3=   
            ' m_V4=   
            ' m_V5=   
            ' m_DV45=   
            ' m_V6=   
            ' m_M1=   
            ' m_M2=   
            ' m_DM12=   
            ' m_M3=   
            ' m_M4=   
            ' m_M5=   
            ' m_DM45=   
            ' m_M6=   
            ' m_P1=   
            ' m_P2=   
            ' m_P3=   
            ' m_P4=   
            ' m_P5=   
            ' m_P6=   
            ' m_G1=   
            ' m_G2=   
            ' m_G3=   
            ' m_G4=   
            ' m_G5=   
            ' m_G6=   
            ' m_TCOOL=   
            ' m_TCE1=   
            ' m_TCE2=   
            ' m_TSUM1=   
            ' m_TSUM2=   
            ' m_Q1H=   
            ' m_Q2H=   
            ' m_V1H=   
            ' m_V2H=   
            ' m_V4H=   
            ' m_V5H=   
            ' m_ERRTIME=   
            ' m_ERRTIMEH=   
            ' m_HC=   
            ' m_SP=   
            ' m_SP_TB1=   
            ' m_SP_TB2=   
            ' m_datetimeCOUNTER=   
            ' m_DG12=   
            ' m_DG45=   
            ' m_DP12=   
            ' m_DP45=   
            ' m_UNITSR=   
            ' m_Q3=   
            ' m_Q4=   
            ' m_PATM=   
            ' m_Q5=   
            ' m_DQ12=   
            ' m_DQ45=   
            ' m_PXB=   
            ' m_DQ=   
            ' m_HC_1=   
            ' m_HC_2=   
            ' m_THOT=   
            ' m_DANS1=   
            ' m_DANS2=   
            ' m_DANS3=   
            ' m_DANS4=   
            ' m_DANS5=   
            ' m_DANS6=   
            ' m_CHECK_A=   
            ' m_OKTIME=   
            ' m_WORKTIME=   
            ' m_TAIR1=   
            ' m_TAIR2=   
            ' m_HC_CODE=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 86
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
                    Value = Q1
                Case 4
                    Value = Q2
                Case 5
                    Value = T1
                Case 6
                    Value = T2
                Case 7
                    Value = DT12
                Case 8
                    Value = T3
                Case 9
                    Value = T4
                Case 10
                    Value = T5
                Case 11
                    Value = DT45
                Case 12
                    Value = T6
                Case 13
                    Value = V1
                Case 14
                    Value = V2
                Case 15
                    Value = DV12
                Case 16
                    Value = V3
                Case 17
                    Value = V4
                Case 18
                    Value = V5
                Case 19
                    Value = DV45
                Case 20
                    Value = V6
                Case 21
                    Value = M1
                Case 22
                    Value = M2
                Case 23
                    Value = DM12
                Case 24
                    Value = M3
                Case 25
                    Value = M4
                Case 26
                    Value = M5
                Case 27
                    Value = DM45
                Case 28
                    Value = M6
                Case 29
                    Value = P1
                Case 30
                    Value = P2
                Case 31
                    Value = P3
                Case 32
                    Value = P4
                Case 33
                    Value = P5
                Case 34
                    Value = P6
                Case 35
                    Value = G1
                Case 36
                    Value = G2
                Case 37
                    Value = G3
                Case 38
                    Value = G4
                Case 39
                    Value = G5
                Case 40
                    Value = G6
                Case 41
                    Value = TCOOL
                Case 42
                    Value = TCE1
                Case 43
                    Value = TCE2
                Case 44
                    Value = TSUM1
                Case 45
                    Value = TSUM2
                Case 46
                    Value = Q1H
                Case 47
                    Value = Q2H
                Case 48
                    Value = V1H
                Case 49
                    Value = V2H
                Case 50
                    Value = V4H
                Case 51
                    Value = V5H
                Case 52
                    Value = ERRTIME
                Case 53
                    Value = ERRTIMEH
                Case 54
                    Value = HC
                Case 55
                    Value = SP
                Case 56
                    Value = SP_TB1
                Case 57
                    Value = SP_TB2
                Case 58
                    Value = datetimeCOUNTER
                Case 59
                    Value = DG12
                Case 60
                    Value = DG45
                Case 61
                    Value = DP12
                Case 62
                    Value = DP45
                Case 63
                    Value = UNITSR
                Case 64
                    Value = Q3
                Case 65
                    Value = Q4
                Case 66
                    Value = PATM
                Case 67
                    Value = Q5
                Case 68
                    Value = DQ12
                Case 69
                    Value = DQ45
                Case 70
                    Value = PXB
                Case 71
                    Value = DQ
                Case 72
                    Value = HC_1
                Case 73
                    Value = HC_2
                Case 74
                    Value = THOT
                Case 75
                    Value = DANS1
                Case 76
                    Value = DANS2
                Case 77
                    Value = DANS3
                Case 78
                    Value = DANS4
                Case 79
                    Value = DANS5
                Case 80
                    Value = DANS6
                Case 81
                    Value = CHECK_A
                Case 82
                    Value = OKTIME
                Case 83
                    Value = WORKTIME
                Case 84
                    Value = TAIR1
                Case 85
                    Value = TAIR2
                Case 86
                    Value = HC_CODE
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
                    Q1 = value
                Case 4
                    Q2 = value
                Case 5
                    T1 = value
                Case 6
                    T2 = value
                Case 7
                    DT12 = value
                Case 8
                    T3 = value
                Case 9
                    T4 = value
                Case 10
                    T5 = value
                Case 11
                    DT45 = value
                Case 12
                    T6 = value
                Case 13
                    V1 = value
                Case 14
                    V2 = value
                Case 15
                    DV12 = value
                Case 16
                    V3 = value
                Case 17
                    V4 = value
                Case 18
                    V5 = value
                Case 19
                    DV45 = value
                Case 20
                    V6 = value
                Case 21
                    M1 = value
                Case 22
                    M2 = value
                Case 23
                    DM12 = value
                Case 24
                    M3 = value
                Case 25
                    M4 = value
                Case 26
                    M5 = value
                Case 27
                    DM45 = value
                Case 28
                    M6 = value
                Case 29
                    P1 = value
                Case 30
                    P2 = value
                Case 31
                    P3 = value
                Case 32
                    P4 = value
                Case 33
                    P5 = value
                Case 34
                    P6 = value
                Case 35
                    G1 = value
                Case 36
                    G2 = value
                Case 37
                    G3 = value
                Case 38
                    G4 = value
                Case 39
                    G5 = value
                Case 40
                    G6 = value
                Case 41
                    TCOOL = value
                Case 42
                    TCE1 = value
                Case 43
                    TCE2 = value
                Case 44
                    TSUM1 = value
                Case 45
                    TSUM2 = value
                Case 46
                    Q1H = value
                Case 47
                    Q2H = value
                Case 48
                    V1H = value
                Case 49
                    V2H = value
                Case 50
                    V4H = value
                Case 51
                    V5H = value
                Case 52
                    ERRTIME = value
                Case 53
                    ERRTIMEH = value
                Case 54
                    HC = value
                Case 55
                    SP = value
                Case 56
                    SP_TB1 = value
                Case 57
                    SP_TB2 = value
                Case 58
                    datetimeCOUNTER = value
                Case 59
                    DG12 = value
                Case 60
                    DG45 = value
                Case 61
                    DP12 = value
                Case 62
                    DP45 = value
                Case 63
                    UNITSR = value
                Case 64
                    Q3 = value
                Case 65
                    Q4 = value
                Case 66
                    PATM = value
                Case 67
                    Q5 = value
                Case 68
                    DQ12 = value
                Case 69
                    DQ45 = value
                Case 70
                    PXB = value
                Case 71
                    DQ = value
                Case 72
                    HC_1 = value
                Case 73
                    HC_2 = value
                Case 74
                    THOT = value
                Case 75
                    DANS1 = value
                Case 76
                    DANS2 = value
                Case 77
                    DANS3 = value
                Case 78
                    DANS4 = value
                Case 79
                    DANS5 = value
                Case 80
                    DANS6 = value
                Case 81
                    CHECK_A = value
                Case 82
                    OKTIME = value
                Case 83
                    WORKTIME = value
                Case 84
                    TAIR1 = value
                Case 85
                    TAIR2 = value
                Case 86
                    HC_CODE = value
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
                    Return "Q1"
                Case 4
                    Return "Q2"
                Case 5
                    Return "T1"
                Case 6
                    Return "T2"
                Case 7
                    Return "DT12"
                Case 8
                    Return "T3"
                Case 9
                    Return "T4"
                Case 10
                    Return "T5"
                Case 11
                    Return "DT45"
                Case 12
                    Return "T6"
                Case 13
                    Return "V1"
                Case 14
                    Return "V2"
                Case 15
                    Return "DV12"
                Case 16
                    Return "V3"
                Case 17
                    Return "V4"
                Case 18
                    Return "V5"
                Case 19
                    Return "DV45"
                Case 20
                    Return "V6"
                Case 21
                    Return "M1"
                Case 22
                    Return "M2"
                Case 23
                    Return "DM12"
                Case 24
                    Return "M3"
                Case 25
                    Return "M4"
                Case 26
                    Return "M5"
                Case 27
                    Return "DM45"
                Case 28
                    Return "M6"
                Case 29
                    Return "P1"
                Case 30
                    Return "P2"
                Case 31
                    Return "P3"
                Case 32
                    Return "P4"
                Case 33
                    Return "P5"
                Case 34
                    Return "P6"
                Case 35
                    Return "G1"
                Case 36
                    Return "G2"
                Case 37
                    Return "G3"
                Case 38
                    Return "G4"
                Case 39
                    Return "G5"
                Case 40
                    Return "G6"
                Case 41
                    Return "TCOOL"
                Case 42
                    Return "TCE1"
                Case 43
                    Return "TCE2"
                Case 44
                    Return "TSUM1"
                Case 45
                    Return "TSUM2"
                Case 46
                    Return "Q1H"
                Case 47
                    Return "Q2H"
                Case 48
                    Return "V1H"
                Case 49
                    Return "V2H"
                Case 50
                    Return "V4H"
                Case 51
                    Return "V5H"
                Case 52
                    Return "ERRTIME"
                Case 53
                    Return "ERRTIMEH"
                Case 54
                    Return "HC"
                Case 55
                    Return "SP"
                Case 56
                    Return "SP_TB1"
                Case 57
                    Return "SP_TB2"
                Case 58
                    Return "datetimeCOUNTER"
                Case 59
                    Return "DG12"
                Case 60
                    Return "DG45"
                Case 61
                    Return "DP12"
                Case 62
                    Return "DP45"
                Case 63
                    Return "UNITSR"
                Case 64
                    Return "Q3"
                Case 65
                    Return "Q4"
                Case 66
                    Return "PATM"
                Case 67
                    Return "Q5"
                Case 68
                    Return "DQ12"
                Case 69
                    Return "DQ45"
                Case 70
                    Return "PXB"
                Case 71
                    Return "DQ"
                Case 72
                    Return "HC_1"
                Case 73
                    Return "HC_2"
                Case 74
                    Return "THOT"
                Case 75
                    Return "DANS1"
                Case 76
                    Return "DANS2"
                Case 77
                    Return "DANS3"
                Case 78
                    Return "DANS4"
                Case 79
                    Return "DANS5"
                Case 80
                    Return "DANS6"
                Case 81
                    Return "CHECK_A"
                Case 82
                    Return "OKTIME"
                Case 83
                    Return "WORKTIME"
                Case 84
                    Return "TAIR1"
                Case 85
                    Return "TAIR2"
                Case 86
                    Return "HC_CODE"
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
             dr("Q1") =Q1
             dr("Q2") =Q2
             dr("T1") =T1
             dr("T2") =T2
             dr("DT12") =DT12
             dr("T3") =T3
             dr("T4") =T4
             dr("T5") =T5
             dr("DT45") =DT45
             dr("T6") =T6
             dr("V1") =V1
             dr("V2") =V2
             dr("DV12") =DV12
             dr("V3") =V3
             dr("V4") =V4
             dr("V5") =V5
             dr("DV45") =DV45
             dr("V6") =V6
             dr("M1") =M1
             dr("M2") =M2
             dr("DM12") =DM12
             dr("M3") =M3
             dr("M4") =M4
             dr("M5") =M5
             dr("DM45") =DM45
             dr("M6") =M6
             dr("P1") =P1
             dr("P2") =P2
             dr("P3") =P3
             dr("P4") =P4
             dr("P5") =P5
             dr("P6") =P6
             dr("G1") =G1
             dr("G2") =G2
             dr("G3") =G3
             dr("G4") =G4
             dr("G5") =G5
             dr("G6") =G6
             dr("TCOOL") =TCOOL
             dr("TCE1") =TCE1
             dr("TCE2") =TCE2
             dr("TSUM1") =TSUM1
             dr("TSUM2") =TSUM2
             dr("Q1H") =Q1H
             dr("Q2H") =Q2H
             dr("V1H") =V1H
             dr("V2H") =V2H
             dr("V4H") =V4H
             dr("V5H") =V5H
             dr("ERRTIME") =ERRTIME
             dr("ERRTIMEH") =ERRTIMEH
             dr("HC") =HC
             dr("SP") =SP
             dr("SP_TB1") =SP_TB1
             dr("SP_TB2") =SP_TB2
             dr("datetimeCOUNTER") =datetimeCOUNTER
             dr("DG12") =DG12
             dr("DG45") =DG45
             dr("DP12") =DP12
             dr("DP45") =DP45
             dr("UNITSR") =UNITSR
             dr("Q3") =Q3
             dr("Q4") =Q4
             dr("PATM") =PATM
             dr("Q5") =Q5
             dr("DQ12") =DQ12
             dr("DQ45") =DQ45
             dr("PXB") =PXB
             dr("DQ") =DQ
             dr("HC_1") =HC_1
             dr("HC_2") =HC_2
             dr("THOT") =THOT
             dr("DANS1") =DANS1
             dr("DANS2") =DANS2
             dr("DANS3") =DANS3
             dr("DANS4") =DANS4
             dr("DANS5") =DANS5
             dr("DANS6") =DANS6
             dr("CHECK_A") =CHECK_A
             dr("OKTIME") =OKTIME
             dr("WORKTIME") =WORKTIME
             dr("TAIR1") =TAIR1
             dr("TAIR2") =TAIR2
             dr("HC_CODE") =HC_CODE
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
          nv.Add("Q1", Q1, dbtype.double)
          nv.Add("Q2", Q2, dbtype.double)
          nv.Add("T1", T1, dbtype.double)
          nv.Add("T2", T2, dbtype.double)
          nv.Add("DT12", DT12, dbtype.double)
          nv.Add("T3", T3, dbtype.double)
          nv.Add("T4", T4, dbtype.double)
          nv.Add("T5", T5, dbtype.double)
          nv.Add("DT45", DT45, dbtype.double)
          nv.Add("T6", T6, dbtype.double)
          nv.Add("V1", V1, dbtype.double)
          nv.Add("V2", V2, dbtype.double)
          nv.Add("DV12", DV12, dbtype.double)
          nv.Add("V3", V3, dbtype.double)
          nv.Add("V4", V4, dbtype.double)
          nv.Add("V5", V5, dbtype.double)
          nv.Add("DV45", DV45, dbtype.double)
          nv.Add("V6", V6, dbtype.double)
          nv.Add("M1", M1, dbtype.double)
          nv.Add("M2", M2, dbtype.double)
          nv.Add("DM12", DM12, dbtype.double)
          nv.Add("M3", M3, dbtype.double)
          nv.Add("M4", M4, dbtype.double)
          nv.Add("M5", M5, dbtype.double)
          nv.Add("DM45", DM45, dbtype.double)
          nv.Add("M6", M6, dbtype.double)
          nv.Add("P1", P1, dbtype.double)
          nv.Add("P2", P2, dbtype.double)
          nv.Add("P3", P3, dbtype.double)
          nv.Add("P4", P4, dbtype.double)
          nv.Add("P5", P5, dbtype.double)
          nv.Add("P6", P6, dbtype.double)
          nv.Add("G1", G1, dbtype.double)
          nv.Add("G2", G2, dbtype.double)
          nv.Add("G3", G3, dbtype.double)
          nv.Add("G4", G4, dbtype.double)
          nv.Add("G5", G5, dbtype.double)
          nv.Add("G6", G6, dbtype.double)
          nv.Add("TCOOL", TCOOL, dbtype.double)
          nv.Add("TCE1", TCE1, dbtype.double)
          nv.Add("TCE2", TCE2, dbtype.double)
          nv.Add("TSUM1", TSUM1, dbtype.double)
          nv.Add("TSUM2", TSUM2, dbtype.double)
          nv.Add("Q1H", Q1H, dbtype.double)
          nv.Add("Q2H", Q2H, dbtype.double)
          nv.Add("V1H", V1H, dbtype.double)
          nv.Add("V2H", V2H, dbtype.double)
          nv.Add("V4H", V4H, dbtype.double)
          nv.Add("V5H", V5H, dbtype.double)
          nv.Add("ERRTIME", ERRTIME, dbtype.double)
          nv.Add("ERRTIMEH", ERRTIMEH, dbtype.double)
          nv.Add("HC", HC, dbtype.string)
          nv.Add("SP", SP, dbtype.double)
          nv.Add("SP_TB1", SP_TB1, dbtype.double)
          nv.Add("SP_TB2", SP_TB2, dbtype.double)
          if datetimeCOUNTER=System.DateTime.MinValue then
            nv.Add("datetimeCOUNTER", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("datetimeCOUNTER", datetimeCOUNTER, dbtype.DATETIME)
          end if 
          nv.Add("DG12", DG12, dbtype.double)
          nv.Add("DG45", DG45, dbtype.double)
          nv.Add("DP12", DP12, dbtype.double)
          nv.Add("DP45", DP45, dbtype.double)
          nv.Add("UNITSR", UNITSR, dbtype.string)
          nv.Add("Q3", Q3, dbtype.double)
          nv.Add("Q4", Q4, dbtype.double)
          nv.Add("PATM", PATM, dbtype.double)
          nv.Add("Q5", Q5, dbtype.double)
          nv.Add("DQ12", DQ12, dbtype.double)
          nv.Add("DQ45", DQ45, dbtype.double)
          nv.Add("PXB", PXB, dbtype.double)
          nv.Add("DQ", DQ, dbtype.double)
          nv.Add("HC_1", HC_1, dbtype.string)
          nv.Add("HC_2", HC_2, dbtype.string)
          nv.Add("THOT", THOT, dbtype.double)
          nv.Add("DANS1", DANS1, dbtype.double)
          nv.Add("DANS2", DANS2, dbtype.double)
          nv.Add("DANS3", DANS3, dbtype.double)
          nv.Add("DANS4", DANS4, dbtype.double)
          nv.Add("DANS5", DANS5, dbtype.double)
          nv.Add("DANS6", DANS6, dbtype.double)
          nv.Add("CHECK_A", CHECK_A, dbtype.double)
          nv.Add("OKTIME", OKTIME, dbtype.double)
          nv.Add("WORKTIME", WORKTIME, dbtype.double)
          nv.Add("TAIR1", TAIR1, dbtype.double)
          nv.Add("TAIR2", TAIR2, dbtype.double)
          nv.Add("HC_CODE", HC_CODE, dbtype.string)
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
          If reader.Table.Columns.Contains("Q1") Then m_Q1=reader.item("Q1")
          If reader.Table.Columns.Contains("Q2") Then m_Q2=reader.item("Q2")
          If reader.Table.Columns.Contains("T1") Then m_T1=reader.item("T1")
          If reader.Table.Columns.Contains("T2") Then m_T2=reader.item("T2")
          If reader.Table.Columns.Contains("DT12") Then m_DT12=reader.item("DT12")
          If reader.Table.Columns.Contains("T3") Then m_T3=reader.item("T3")
          If reader.Table.Columns.Contains("T4") Then m_T4=reader.item("T4")
          If reader.Table.Columns.Contains("T5") Then m_T5=reader.item("T5")
          If reader.Table.Columns.Contains("DT45") Then m_DT45=reader.item("DT45")
          If reader.Table.Columns.Contains("T6") Then m_T6=reader.item("T6")
          If reader.Table.Columns.Contains("V1") Then m_V1=reader.item("V1")
          If reader.Table.Columns.Contains("V2") Then m_V2=reader.item("V2")
          If reader.Table.Columns.Contains("DV12") Then m_DV12=reader.item("DV12")
          If reader.Table.Columns.Contains("V3") Then m_V3=reader.item("V3")
          If reader.Table.Columns.Contains("V4") Then m_V4=reader.item("V4")
          If reader.Table.Columns.Contains("V5") Then m_V5=reader.item("V5")
          If reader.Table.Columns.Contains("DV45") Then m_DV45=reader.item("DV45")
          If reader.Table.Columns.Contains("V6") Then m_V6=reader.item("V6")
          If reader.Table.Columns.Contains("M1") Then m_M1=reader.item("M1")
          If reader.Table.Columns.Contains("M2") Then m_M2=reader.item("M2")
          If reader.Table.Columns.Contains("DM12") Then m_DM12=reader.item("DM12")
          If reader.Table.Columns.Contains("M3") Then m_M3=reader.item("M3")
          If reader.Table.Columns.Contains("M4") Then m_M4=reader.item("M4")
          If reader.Table.Columns.Contains("M5") Then m_M5=reader.item("M5")
          If reader.Table.Columns.Contains("DM45") Then m_DM45=reader.item("DM45")
          If reader.Table.Columns.Contains("M6") Then m_M6=reader.item("M6")
          If reader.Table.Columns.Contains("P1") Then m_P1=reader.item("P1")
          If reader.Table.Columns.Contains("P2") Then m_P2=reader.item("P2")
          If reader.Table.Columns.Contains("P3") Then m_P3=reader.item("P3")
          If reader.Table.Columns.Contains("P4") Then m_P4=reader.item("P4")
          If reader.Table.Columns.Contains("P5") Then m_P5=reader.item("P5")
          If reader.Table.Columns.Contains("P6") Then m_P6=reader.item("P6")
          If reader.Table.Columns.Contains("G1") Then m_G1=reader.item("G1")
          If reader.Table.Columns.Contains("G2") Then m_G2=reader.item("G2")
          If reader.Table.Columns.Contains("G3") Then m_G3=reader.item("G3")
          If reader.Table.Columns.Contains("G4") Then m_G4=reader.item("G4")
          If reader.Table.Columns.Contains("G5") Then m_G5=reader.item("G5")
          If reader.Table.Columns.Contains("G6") Then m_G6=reader.item("G6")
          If reader.Table.Columns.Contains("TCOOL") Then m_TCOOL=reader.item("TCOOL")
          If reader.Table.Columns.Contains("TCE1") Then m_TCE1=reader.item("TCE1")
          If reader.Table.Columns.Contains("TCE2") Then m_TCE2=reader.item("TCE2")
          If reader.Table.Columns.Contains("TSUM1") Then m_TSUM1=reader.item("TSUM1")
          If reader.Table.Columns.Contains("TSUM2") Then m_TSUM2=reader.item("TSUM2")
          If reader.Table.Columns.Contains("Q1H") Then m_Q1H=reader.item("Q1H")
          If reader.Table.Columns.Contains("Q2H") Then m_Q2H=reader.item("Q2H")
          If reader.Table.Columns.Contains("V1H") Then m_V1H=reader.item("V1H")
          If reader.Table.Columns.Contains("V2H") Then m_V2H=reader.item("V2H")
          If reader.Table.Columns.Contains("V4H") Then m_V4H=reader.item("V4H")
          If reader.Table.Columns.Contains("V5H") Then m_V5H=reader.item("V5H")
          If reader.Table.Columns.Contains("ERRTIME") Then m_ERRTIME=reader.item("ERRTIME")
          If reader.Table.Columns.Contains("ERRTIMEH") Then m_ERRTIMEH=reader.item("ERRTIMEH")
          If reader.Table.Columns.Contains("HC") Then m_HC=reader.item("HC").ToString()
          If reader.Table.Columns.Contains("SP") Then m_SP=reader.item("SP")
          If reader.Table.Columns.Contains("SP_TB1") Then m_SP_TB1=reader.item("SP_TB1")
          If reader.Table.Columns.Contains("SP_TB2") Then m_SP_TB2=reader.item("SP_TB2")
      If reader.Table.Columns.Contains("datetimeCOUNTER") Then
          if isdbnull(reader.item("datetimeCOUNTER")) then
            If reader.Table.Columns.Contains("datetimeCOUNTER") Then m_datetimeCOUNTER = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("datetimeCOUNTER") Then m_datetimeCOUNTER=reader.item("datetimeCOUNTER")
          end if 
      end if 
          If reader.Table.Columns.Contains("DG12") Then m_DG12=reader.item("DG12")
          If reader.Table.Columns.Contains("DG45") Then m_DG45=reader.item("DG45")
          If reader.Table.Columns.Contains("DP12") Then m_DP12=reader.item("DP12")
          If reader.Table.Columns.Contains("DP45") Then m_DP45=reader.item("DP45")
          If reader.Table.Columns.Contains("UNITSR") Then m_UNITSR=reader.item("UNITSR").ToString()
          If reader.Table.Columns.Contains("Q3") Then m_Q3=reader.item("Q3")
          If reader.Table.Columns.Contains("Q4") Then m_Q4=reader.item("Q4")
          If reader.Table.Columns.Contains("PATM") Then m_PATM=reader.item("PATM")
          If reader.Table.Columns.Contains("Q5") Then m_Q5=reader.item("Q5")
          If reader.Table.Columns.Contains("DQ12") Then m_DQ12=reader.item("DQ12")
          If reader.Table.Columns.Contains("DQ45") Then m_DQ45=reader.item("DQ45")
          If reader.Table.Columns.Contains("PXB") Then m_PXB=reader.item("PXB")
          If reader.Table.Columns.Contains("DQ") Then m_DQ=reader.item("DQ")
          If reader.Table.Columns.Contains("HC_1") Then m_HC_1=reader.item("HC_1").ToString()
          If reader.Table.Columns.Contains("HC_2") Then m_HC_2=reader.item("HC_2").ToString()
          If reader.Table.Columns.Contains("THOT") Then m_THOT=reader.item("THOT")
          If reader.Table.Columns.Contains("DANS1") Then m_DANS1=reader.item("DANS1")
          If reader.Table.Columns.Contains("DANS2") Then m_DANS2=reader.item("DANS2")
          If reader.Table.Columns.Contains("DANS3") Then m_DANS3=reader.item("DANS3")
          If reader.Table.Columns.Contains("DANS4") Then m_DANS4=reader.item("DANS4")
          If reader.Table.Columns.Contains("DANS5") Then m_DANS5=reader.item("DANS5")
          If reader.Table.Columns.Contains("DANS6") Then m_DANS6=reader.item("DANS6")
          If reader.Table.Columns.Contains("CHECK_A") Then m_CHECK_A=reader.item("CHECK_A")
          If reader.Table.Columns.Contains("OKTIME") Then m_OKTIME=reader.item("OKTIME")
          If reader.Table.Columns.Contains("WORKTIME") Then m_WORKTIME=reader.item("WORKTIME")
          If reader.Table.Columns.Contains("TAIR1") Then m_TAIR1=reader.item("TAIR1")
          If reader.Table.Columns.Contains("TAIR2") Then m_TAIR2=reader.item("TAIR2")
          If reader.Table.Columns.Contains("HC_CODE") Then m_HC_CODE=reader.item("HC_CODE").ToString()
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
'''Доступ к полю Тепловая энергия канал 1
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Q1() As double
            Get
                LoadFromDatabase()
                Q1 = m_Q1
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_Q1 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Тепловая энергия канал 2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Q2() As double
            Get
                LoadFromDatabase()
                Q2 = m_Q2
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_Q2 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Температура по каналу 1
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property T1() As double
            Get
                LoadFromDatabase()
                T1 = m_T1
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_T1 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Температура по каналу 2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property T2() As double
            Get
                LoadFromDatabase()
                T2 = m_T2
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_T2 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Разность Температур по каналу 1 и 2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DT12() As double
            Get
                LoadFromDatabase()
                DT12 = m_DT12
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_DT12 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Температура по каналу 3
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property T3() As double
            Get
                LoadFromDatabase()
                T3 = m_T3
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_T3 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Температура по каналу 4
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property T4() As double
            Get
                LoadFromDatabase()
                T4 = m_T4
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_T4 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Температура по каналу 5
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property T5() As double
            Get
                LoadFromDatabase()
                T5 = m_T5
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_T5 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Разность Температур по каналу 4 и 5
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DT45() As double
            Get
                LoadFromDatabase()
                DT45 = m_DT45
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_DT45 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Температура по каналу 6
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property T6() As double
            Get
                LoadFromDatabase()
                T6 = m_T6
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_T6 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Объемный расход воды по каналу 1
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property V1() As double
            Get
                LoadFromDatabase()
                V1 = m_V1
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_V1 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Объемный расход воды по каналу 2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property V2() As double
            Get
                LoadFromDatabase()
                V2 = m_V2
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_V2 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Разность объемов канал 1  (расход ГВС)
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DV12() As double
            Get
                LoadFromDatabase()
                DV12 = m_DV12
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_DV12 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Объемный расход воды по каналу 3
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property V3() As double
            Get
                LoadFromDatabase()
                V3 = m_V3
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_V3 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Объемный расход воды по каналу 4
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property V4() As double
            Get
                LoadFromDatabase()
                V4 = m_V4
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_V4 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Объемный расход воды по каналу 5
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property V5() As double
            Get
                LoadFromDatabase()
                V5 = m_V5
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_V5 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Разность объемов канал 2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DV45() As double
            Get
                LoadFromDatabase()
                DV45 = m_DV45
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_DV45 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Объемный расход воды по каналу 6
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property V6() As double
            Get
                LoadFromDatabase()
                V6 = m_V6
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_V6 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Масса воды по каналу 1
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property M1() As double
            Get
                LoadFromDatabase()
                M1 = m_M1
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_M1 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Масса воды по каналу 2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property M2() As double
            Get
                LoadFromDatabase()
                M2 = m_M2
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_M2 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Разность масс канал 1  (расход ГВС)
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DM12() As double
            Get
                LoadFromDatabase()
                DM12 = m_DM12
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_DM12 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Масса воды по каналу 3
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property M3() As double
            Get
                LoadFromDatabase()
                M3 = m_M3
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_M3 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Масса воды по каналу 4
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property M4() As double
            Get
                LoadFromDatabase()
                M4 = m_M4
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_M4 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Масса воды по каналу 5
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property M5() As double
            Get
                LoadFromDatabase()
                M5 = m_M5
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_M5 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Разность масс канал 2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DM45() As double
            Get
                LoadFromDatabase()
                DM45 = m_DM45
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_DM45 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Масса воды по каналу 6
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property M6() As double
            Get
                LoadFromDatabase()
                M6 = m_M6
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_M6 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Давление в трубопроводе 1
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property P1() As double
            Get
                LoadFromDatabase()
                P1 = m_P1
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_P1 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Давление в трубопроводе 2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property P2() As double
            Get
                LoadFromDatabase()
                P2 = m_P2
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_P2 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Давление в трубопроводе 3
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property P3() As double
            Get
                LoadFromDatabase()
                P3 = m_P3
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_P3 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Давление в трубопроводе 4
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property P4() As double
            Get
                LoadFromDatabase()
                P4 = m_P4
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_P4 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Давление в трубопроводе 5
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property P5() As double
            Get
                LoadFromDatabase()
                P5 = m_P5
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_P5 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Давление в трубопроводе 6
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property P6() As double
            Get
                LoadFromDatabase()
                P6 = m_P6
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_P6 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Текущее значение расхода в трубопроводе 1
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property G1() As double
            Get
                LoadFromDatabase()
                G1 = m_G1
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_G1 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Текущее значение расхода в трубопроводе 2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property G2() As double
            Get
                LoadFromDatabase()
                G2 = m_G2
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_G2 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Текущее значение расхода в трубопроводе 3
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property G3() As double
            Get
                LoadFromDatabase()
                G3 = m_G3
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_G3 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Текущее значение расхода в трубопроводе 4
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property G4() As double
            Get
                LoadFromDatabase()
                G4 = m_G4
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_G4 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Текущее значение расхода в трубопроводе 5
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property G5() As double
            Get
                LoadFromDatabase()
                G5 = m_G5
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_G5 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Текущее значение расхода в трубопроводе 6
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property G6() As double
            Get
                LoadFromDatabase()
                G6 = m_G6
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_G6 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Температура холодной воды
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TCOOL() As double
            Get
                LoadFromDatabase()
                TCOOL = m_TCOOL
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_TCOOL = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Температура холодного конца канал 1
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TCE1() As double
            Get
                LoadFromDatabase()
                TCE1 = m_TCE1
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_TCE1 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Температура холодного конца канал 2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TCE2() As double
            Get
                LoadFromDatabase()
                TCE2 = m_TCE2
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_TCE2 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Тотальное время счета TB1
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TSUM1() As double
            Get
                LoadFromDatabase()
                TSUM1 = m_TSUM1
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_TSUM1 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Тотальное время счета TB2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TSUM2() As double
            Get
                LoadFromDatabase()
                TSUM2 = m_TSUM2
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_TSUM2 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Тепловая энергия канал 1 нарастающим итогом
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Q1H() As double
            Get
                LoadFromDatabase()
                Q1H = m_Q1H
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_Q1H = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Тепловая энергия канал 2 нарастающим итогом
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Q2H() As double
            Get
                LoadFromDatabase()
                Q2H = m_Q2H
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_Q2H = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Объемный расход воды по каналу 1  нарастающим итогом
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property V1H() As double
            Get
                LoadFromDatabase()
                V1H = m_V1H
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_V1H = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Объемный расход воды по каналу 2  нарастающим итогом
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property V2H() As double
            Get
                LoadFromDatabase()
                V2H = m_V2H
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_V2H = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Объемный расход воды по каналу 4  нарастающим итогом
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property V4H() As double
            Get
                LoadFromDatabase()
                V4H = m_V4H
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_V4H = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Объемный расход воды по каналу 5  нарастающим итогом
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property V5H() As double
            Get
                LoadFromDatabase()
                V5H = m_V5H
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_V5H = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Время аварии
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ERRTIME() As double
            Get
                LoadFromDatabase()
                ERRTIME = m_ERRTIME
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_ERRTIME = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Время аварии нарастающим итогом
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ERRTIMEH() As double
            Get
                LoadFromDatabase()
                ERRTIMEH = m_ERRTIMEH
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_ERRTIMEH = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Нештатные ситуации общ
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property HC() As String
            Get
                LoadFromDatabase()
                HC = m_HC
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_HC = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Схема потребления
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property SP() As double
            Get
                LoadFromDatabase()
                SP = m_SP
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_SP = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Схема потребления TB1
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property SP_TB1() As double
            Get
                LoadFromDatabase()
                SP_TB1 = m_SP_TB1
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_SP_TB1 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Схема потребления TB2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property SP_TB2() As double
            Get
                LoadFromDatabase()
                SP_TB2 = m_SP_TB2
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_SP_TB2 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю datetimeCOUNTER
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property datetimeCOUNTER() As DATE
            Get
                LoadFromDatabase()
                datetimeCOUNTER = m_datetimeCOUNTER
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_datetimeCOUNTER = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю G1-G2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DG12() As double
            Get
                LoadFromDatabase()
                DG12 = m_DG12
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_DG12 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю G4-G5
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DG45() As double
            Get
                LoadFromDatabase()
                DG45 = m_DG45
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_DG45 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю P1-P2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DP12() As double
            Get
                LoadFromDatabase()
                DP12 = m_DP12
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_DP12 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю P4-P5
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DP45() As double
            Get
                LoadFromDatabase()
                DP45 = m_DP45
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_DP45 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Единицы измерения расхода
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property UNITSR() As String
            Get
                LoadFromDatabase()
                UNITSR = m_UNITSR
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_UNITSR = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Тепловая энергия канал 3
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Q3() As double
            Get
                LoadFromDatabase()
                Q3 = m_Q3
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_Q3 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Тепловая энергия канал 4
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Q4() As double
            Get
                LoadFromDatabase()
                Q4 = m_Q4
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_Q4 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Атмосферное давление
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property PATM() As double
            Get
                LoadFromDatabase()
                PATM = m_PATM
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_PATM = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Тепловая энергия канал 5
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Q5() As double
            Get
                LoadFromDatabase()
                Q5 = m_Q5
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_Q5 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Тепловая энергия потребитель 1
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DQ12() As double
            Get
                LoadFromDatabase()
                DQ12 = m_DQ12
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_DQ12 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Тепловая энергия потребитель 2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DQ45() As double
            Get
                LoadFromDatabase()
                DQ45 = m_DQ45
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_DQ45 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Давление холодной воды
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property PXB() As double
            Get
                LoadFromDatabase()
                PXB = m_PXB
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_PXB = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Расход энергии потребитель 1
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DQ() As double
            Get
                LoadFromDatabase()
                DQ = m_DQ
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_DQ = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Нештатная ситуация 1 (ТВ1 или внешняя)
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property HC_1() As String
            Get
                LoadFromDatabase()
                HC_1 = m_HC_1
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_HC_1 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Нештатная ситуация 2 (ТВ2 или внутренняя)
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property HC_2() As String
            Get
                LoadFromDatabase()
                HC_2 = m_HC_2
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_HC_2 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Температура горячей воды
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property THOT() As double
            Get
                LoadFromDatabase()
                THOT = m_THOT
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_THOT = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю DANS1
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DANS1() As double
            Get
                LoadFromDatabase()
                DANS1 = m_DANS1
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_DANS1 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю DANS2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DANS2() As double
            Get
                LoadFromDatabase()
                DANS2 = m_DANS2
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_DANS2 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю DANS3
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DANS3() As double
            Get
                LoadFromDatabase()
                DANS3 = m_DANS3
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_DANS3 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю DANS4
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DANS4() As double
            Get
                LoadFromDatabase()
                DANS4 = m_DANS4
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_DANS4 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю DANS5
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DANS5() As double
            Get
                LoadFromDatabase()
                DANS5 = m_DANS5
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_DANS5 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю DANS6
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DANS6() As double
            Get
                LoadFromDatabase()
                DANS6 = m_DANS6
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_DANS6 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Проверка архивных данных на НС (0 - не производилась, 1 - произведена)
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property CHECK_A() As double
            Get
                LoadFromDatabase()
                CHECK_A = m_CHECK_A
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_CHECK_A = Value
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
'''Доступ к полю Температура воздуха канал 1
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TAIR1() As double
            Get
                LoadFromDatabase()
                TAIR1 = m_TAIR1
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_TAIR1 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Температура воздуха канал 2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TAIR2() As double
            Get
                LoadFromDatabase()
                TAIR2 = m_TAIR2
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_TAIR2 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Код нештатной ситуации тепловычислителя
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property HC_CODE() As String
            Get
                LoadFromDatabase()
                HC_CODE = m_HC_CODE
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_HC_CODE = Value
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
            Q1 = node.Attributes.GetNamedItem("Q1").Value
            Q2 = node.Attributes.GetNamedItem("Q2").Value
            T1 = node.Attributes.GetNamedItem("T1").Value
            T2 = node.Attributes.GetNamedItem("T2").Value
            DT12 = node.Attributes.GetNamedItem("DT12").Value
            T3 = node.Attributes.GetNamedItem("T3").Value
            T4 = node.Attributes.GetNamedItem("T4").Value
            T5 = node.Attributes.GetNamedItem("T5").Value
            DT45 = node.Attributes.GetNamedItem("DT45").Value
            T6 = node.Attributes.GetNamedItem("T6").Value
            V1 = node.Attributes.GetNamedItem("V1").Value
            V2 = node.Attributes.GetNamedItem("V2").Value
            DV12 = node.Attributes.GetNamedItem("DV12").Value
            V3 = node.Attributes.GetNamedItem("V3").Value
            V4 = node.Attributes.GetNamedItem("V4").Value
            V5 = node.Attributes.GetNamedItem("V5").Value
            DV45 = node.Attributes.GetNamedItem("DV45").Value
            V6 = node.Attributes.GetNamedItem("V6").Value
            M1 = node.Attributes.GetNamedItem("M1").Value
            M2 = node.Attributes.GetNamedItem("M2").Value
            DM12 = node.Attributes.GetNamedItem("DM12").Value
            M3 = node.Attributes.GetNamedItem("M3").Value
            M4 = node.Attributes.GetNamedItem("M4").Value
            M5 = node.Attributes.GetNamedItem("M5").Value
            DM45 = node.Attributes.GetNamedItem("DM45").Value
            M6 = node.Attributes.GetNamedItem("M6").Value
            P1 = node.Attributes.GetNamedItem("P1").Value
            P2 = node.Attributes.GetNamedItem("P2").Value
            P3 = node.Attributes.GetNamedItem("P3").Value
            P4 = node.Attributes.GetNamedItem("P4").Value
            P5 = node.Attributes.GetNamedItem("P5").Value
            P6 = node.Attributes.GetNamedItem("P6").Value
            G1 = node.Attributes.GetNamedItem("G1").Value
            G2 = node.Attributes.GetNamedItem("G2").Value
            G3 = node.Attributes.GetNamedItem("G3").Value
            G4 = node.Attributes.GetNamedItem("G4").Value
            G5 = node.Attributes.GetNamedItem("G5").Value
            G6 = node.Attributes.GetNamedItem("G6").Value
            TCOOL = node.Attributes.GetNamedItem("TCOOL").Value
            TCE1 = node.Attributes.GetNamedItem("TCE1").Value
            TCE2 = node.Attributes.GetNamedItem("TCE2").Value
            TSUM1 = node.Attributes.GetNamedItem("TSUM1").Value
            TSUM2 = node.Attributes.GetNamedItem("TSUM2").Value
            Q1H = node.Attributes.GetNamedItem("Q1H").Value
            Q2H = node.Attributes.GetNamedItem("Q2H").Value
            V1H = node.Attributes.GetNamedItem("V1H").Value
            V2H = node.Attributes.GetNamedItem("V2H").Value
            V4H = node.Attributes.GetNamedItem("V4H").Value
            V5H = node.Attributes.GetNamedItem("V5H").Value
            ERRTIME = node.Attributes.GetNamedItem("ERRTIME").Value
            ERRTIMEH = node.Attributes.GetNamedItem("ERRTIMEH").Value
            HC = node.Attributes.GetNamedItem("HC").Value
            SP = node.Attributes.GetNamedItem("SP").Value
            SP_TB1 = node.Attributes.GetNamedItem("SP_TB1").Value
            SP_TB2 = node.Attributes.GetNamedItem("SP_TB2").Value
            m_datetimeCOUNTER = System.DateTime.MinValue
            datetimeCOUNTER = m_datetimeCOUNTER.AddTicks( node.Attributes.GetNamedItem("datetimeCOUNTER").Value)
            DG12 = node.Attributes.GetNamedItem("DG12").Value
            DG45 = node.Attributes.GetNamedItem("DG45").Value
            DP12 = node.Attributes.GetNamedItem("DP12").Value
            DP45 = node.Attributes.GetNamedItem("DP45").Value
            UNITSR = node.Attributes.GetNamedItem("UNITSR").Value
            Q3 = node.Attributes.GetNamedItem("Q3").Value
            Q4 = node.Attributes.GetNamedItem("Q4").Value
            PATM = node.Attributes.GetNamedItem("PATM").Value
            Q5 = node.Attributes.GetNamedItem("Q5").Value
            DQ12 = node.Attributes.GetNamedItem("DQ12").Value
            DQ45 = node.Attributes.GetNamedItem("DQ45").Value
            PXB = node.Attributes.GetNamedItem("PXB").Value
            DQ = node.Attributes.GetNamedItem("DQ").Value
            HC_1 = node.Attributes.GetNamedItem("HC_1").Value
            HC_2 = node.Attributes.GetNamedItem("HC_2").Value
            THOT = node.Attributes.GetNamedItem("THOT").Value
            DANS1 = node.Attributes.GetNamedItem("DANS1").Value
            DANS2 = node.Attributes.GetNamedItem("DANS2").Value
            DANS3 = node.Attributes.GetNamedItem("DANS3").Value
            DANS4 = node.Attributes.GetNamedItem("DANS4").Value
            DANS5 = node.Attributes.GetNamedItem("DANS5").Value
            DANS6 = node.Attributes.GetNamedItem("DANS6").Value
            CHECK_A = node.Attributes.GetNamedItem("CHECK_A").Value
            OKTIME = node.Attributes.GetNamedItem("OKTIME").Value
            WORKTIME = node.Attributes.GetNamedItem("WORKTIME").Value
            TAIR1 = node.Attributes.GetNamedItem("TAIR1").Value
            TAIR2 = node.Attributes.GetNamedItem("TAIR2").Value
            HC_CODE = node.Attributes.GetNamedItem("HC_CODE").Value
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
          node.SetAttribute("Q1", Q1)  
          node.SetAttribute("Q2", Q2)  
          node.SetAttribute("T1", T1)  
          node.SetAttribute("T2", T2)  
          node.SetAttribute("DT12", DT12)  
          node.SetAttribute("T3", T3)  
          node.SetAttribute("T4", T4)  
          node.SetAttribute("T5", T5)  
          node.SetAttribute("DT45", DT45)  
          node.SetAttribute("T6", T6)  
          node.SetAttribute("V1", V1)  
          node.SetAttribute("V2", V2)  
          node.SetAttribute("DV12", DV12)  
          node.SetAttribute("V3", V3)  
          node.SetAttribute("V4", V4)  
          node.SetAttribute("V5", V5)  
          node.SetAttribute("DV45", DV45)  
          node.SetAttribute("V6", V6)  
          node.SetAttribute("M1", M1)  
          node.SetAttribute("M2", M2)  
          node.SetAttribute("DM12", DM12)  
          node.SetAttribute("M3", M3)  
          node.SetAttribute("M4", M4)  
          node.SetAttribute("M5", M5)  
          node.SetAttribute("DM45", DM45)  
          node.SetAttribute("M6", M6)  
          node.SetAttribute("P1", P1)  
          node.SetAttribute("P2", P2)  
          node.SetAttribute("P3", P3)  
          node.SetAttribute("P4", P4)  
          node.SetAttribute("P5", P5)  
          node.SetAttribute("P6", P6)  
          node.SetAttribute("G1", G1)  
          node.SetAttribute("G2", G2)  
          node.SetAttribute("G3", G3)  
          node.SetAttribute("G4", G4)  
          node.SetAttribute("G5", G5)  
          node.SetAttribute("G6", G6)  
          node.SetAttribute("TCOOL", TCOOL)  
          node.SetAttribute("TCE1", TCE1)  
          node.SetAttribute("TCE2", TCE2)  
          node.SetAttribute("TSUM1", TSUM1)  
          node.SetAttribute("TSUM2", TSUM2)  
          node.SetAttribute("Q1H", Q1H)  
          node.SetAttribute("Q2H", Q2H)  
          node.SetAttribute("V1H", V1H)  
          node.SetAttribute("V2H", V2H)  
          node.SetAttribute("V4H", V4H)  
          node.SetAttribute("V5H", V5H)  
          node.SetAttribute("ERRTIME", ERRTIME)  
          node.SetAttribute("ERRTIMEH", ERRTIMEH)  
          node.SetAttribute("HC", HC)  
          node.SetAttribute("SP", SP)  
          node.SetAttribute("SP_TB1", SP_TB1)  
          node.SetAttribute("SP_TB2", SP_TB2)  
         ' if datetimeCOUNTER = System.DateTime.MinValue then datetimeCOUNTER=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("datetimeCOUNTER", datetimeCOUNTER.Ticks)  
          node.SetAttribute("DG12", DG12)  
          node.SetAttribute("DG45", DG45)  
          node.SetAttribute("DP12", DP12)  
          node.SetAttribute("DP45", DP45)  
          node.SetAttribute("UNITSR", UNITSR)  
          node.SetAttribute("Q3", Q3)  
          node.SetAttribute("Q4", Q4)  
          node.SetAttribute("PATM", PATM)  
          node.SetAttribute("Q5", Q5)  
          node.SetAttribute("DQ12", DQ12)  
          node.SetAttribute("DQ45", DQ45)  
          node.SetAttribute("PXB", PXB)  
          node.SetAttribute("DQ", DQ)  
          node.SetAttribute("HC_1", HC_1)  
          node.SetAttribute("HC_2", HC_2)  
          node.SetAttribute("THOT", THOT)  
          node.SetAttribute("DANS1", DANS1)  
          node.SetAttribute("DANS2", DANS2)  
          node.SetAttribute("DANS3", DANS3)  
          node.SetAttribute("DANS4", DANS4)  
          node.SetAttribute("DANS5", DANS5)  
          node.SetAttribute("DANS6", DANS6)  
          node.SetAttribute("CHECK_A", CHECK_A)  
          node.SetAttribute("OKTIME", OKTIME)  
          node.SetAttribute("WORKTIME", WORKTIME)  
          node.SetAttribute("TAIR1", TAIR1)  
          node.SetAttribute("TAIR2", TAIR2)  
          node.SetAttribute("HC_CODE", HC_CODE)  
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
