
Option Explicit On

Imports System.xml
Imports LATIR2
Imports LATIR2.Document
Imports System.Diagnostics

Namespace TPLD




''' <summary>
'''Перечисление Тип раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumStructType'Тип раздела
  StructType_Stroka_atributov=0' Строка атрибутов
  StructType_Kollekciy=1' Коллекция
  StructType_Derevo=2' Дерево
end enum 


''' <summary>
'''Перечисление Вариант расшифровки параметра функции
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumWFFuncParam'Вариант расшифровки параметра функции
  WFFuncParam_Rol_=8' Роль
  WFFuncParam_Viragenie=2' Выражение
  WFFuncParam_Dokument=5' Документ
  WFFuncParam_Pole=7' Поле
  WFFuncParam_Tip_dokumenta=9' Тип документа
  WFFuncParam_Znacenie=0' Значение
  WFFuncParam_Razdel=6' Раздел
  WFFuncParam_Dokument_processa=4' Документ процесса
  WFFuncParam_Papka=3' Папка
  WFFuncParam_Znacenie_iz_parametra=1' Значение из параметра
end enum 


''' <summary>
'''Перечисление Вариант отчета
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumReportType'Вариант отчета
  ReportType_Eksport_po_Excel_sablonu=4' Экспорт по Excel шаблону
  ReportType_Tablica=0' Таблица
  ReportType_Eksport_po_WORD_sablonu=3' Экспорт по WORD шаблону
  ReportType_Dvumernay_matrica=1' Двумерная матрица
  ReportType_Tol_ko_rascet=2' Только расчет
end enum 


''' <summary>
'''Перечисление Образование
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumEducation'Образование
  Education_Ne_vagno=-1' Не важно
  Education_Srednee=1' Среднее
  Education_Vissee=4' Высшее
  Education_Nepolnoe_vissee=3' Неполное высшее
  Education_Nepolnoe_srednee=0' Неполное среднее
  Education_Neskol_ko_vissih=5' Несколько высших
  Education_Srednee_special_noe=2' Среднее специальное
end enum 


''' <summary>
'''Перечисление Вариант трактовки типа поля
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumTypeStyle'Вариант трактовки типа поля
  TypeStyle_Ssilka=4' Ссылка
  TypeStyle_Viragenie=1' Выражение
  TypeStyle_Element_oformleniy=5' Элемент оформления
  TypeStyle_Interval=3' Интервал
  TypeStyle_Perecislenie=2' Перечисление
  TypeStyle_Skalyrniy_tip=0' Скалярный тип
end enum 


''' <summary>
'''Перечисление Вариант репликации докуента
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumReplicationType'Вариант репликации докуента
  ReplicationType_Postrocno=1' Построчно
  ReplicationType_Ves__dokument=0' Весь документ
  ReplicationType_Lokal_niy=2' Локальный
end enum 


''' <summary>
'''Перечисление Правило нумерации
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumNumerationRule'Правило нумерации
  NumerationRule_Po_kvartalu=2' По кварталу
  NumerationRule_Po_mesycu=3' По месяцу
  NumerationRule_Edinay_zona=0' Единая зона
  NumerationRule_Po_dnu=4' По дню
  NumerationRule_Po_godu=1' По году
  NumerationRule_Proizvol_nie_zoni=10' Произвольные зоны
end enum 


''' <summary>
'''Перечисление Состояния процесса
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumWFProcessState'Состояния процесса
  WFProcessState_Pause=3' Pause
  WFProcessState_Active=2' Active
  WFProcessState_Done=4' Done
  WFProcessState_Prepare=1' Prepare
  WFProcessState_Initial=0' Initial
  WFProcessState_Processed=5' Processed
end enum 


''' <summary>
'''Перечисление Вариант действия при выборе пункта меню
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumMenuActionType'Вариант действия при выборе пункта меню
  MenuActionType_Zapustit__ARM=4' Запустить АРМ
  MenuActionType_Vipolnit__metod=2' Выполнить метод
  MenuActionType_Otkrit__otcet=5' Открыть отчет
  MenuActionType_Nicego_ne_delat_=0' Ничего не делать
  MenuActionType_Otkrit__dokument=1' Открыть документ
  MenuActionType_Otkrit__gurnal=3' Открыть журнал
end enum 


''' <summary>
'''Перечисление Варианты ярлыков, которые может размещать процесс
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumWFShortcutType'Варианты ярлыков, которые может размещать процесс
  WFShortcutType_Document=0' Document
  WFShortcutType_Process=2' Process
  WFShortcutType_Function=1' Function
end enum 


''' <summary>
'''Перечисление Выравнивание
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumVHAlignment'Выравнивание
  VHAlignment_Right_Top=6' Right Top
  VHAlignment_Right_Center=7' Right Center
  VHAlignment_Right_Bottom=8' Right Bottom
  VHAlignment_Center_Top=3' Center Top
  VHAlignment_Left_Top=0' Left Top
  VHAlignment_Center_Center=4' Center Center
  VHAlignment_Left_Center=1' Left Center
  VHAlignment_Center_Bottom=5' Center Bottom
  VHAlignment_Left_Bottom=2' Left Bottom
end enum 


''' <summary>
'''Перечисление Валюта платежа
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumCurrencyType'Валюта платежа
  CurrencyType_Evro=2' Евро
  CurrencyType_Rubl_=0' Рубль
  CurrencyType_Dollar=1' Доллар
end enum 


''' <summary>
'''Перечисление Тип каталога
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumInfoStoreType'Тип каталога
  InfoStoreType_Gruppovoy=2' Групповой
  InfoStoreType_cls__Obsiy=0'  Общий
  InfoStoreType_Personal_niy=1' Персональный
end enum 


''' <summary>
'''Перечисление Платформа разработки
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumDevelopmentBase'Платформа разработки
  DevelopmentBase_OTHER=3' OTHER
  DevelopmentBase_DOTNET=1' DOTNET
  DevelopmentBase_JAVA=2' JAVA
  DevelopmentBase_VB6=0' VB6
end enum 


''' <summary>
'''Перечисление Квартал
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumQuarter'Квартал
  Quarter_I=1' I
  Quarter_IV=4' IV
  Quarter_QMARK=0' ?
  Quarter_II=2' II
  Quarter_III=3' III
end enum 


''' <summary>
'''Перечисление Месяцы
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumMonths'Месяцы
  Months_May=5' Май
  Months_Sentybr_=9' Сентябрь
  Months_Iun_=6' Июнь
  Months_Dekabr_=12' Декабрь
  Months_Ynvar_=1' Январь
  Months_Avgust=8' Август
  Months_Fevral_=2' Февраль
  Months_Aprel_=4' Апрель
  Months_Iul_=7' Июль
  Months_Oktybr_=10' Октябрь
  Months_Mart=3' Март
  Months_Noybr_=11' Ноябрь
end enum 


''' <summary>
'''Перечисление Вариант сортиовки данных колонки
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumColumnSortType'Вариант сортиовки данных колонки
  ColumnSortType_As_String=0' As String
  ColumnSortType_As_Numeric=1' As Numeric
  ColumnSortType_As_Date=2' As Date
end enum 


''' <summary>
'''Перечисление Да / Нет
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumBoolean'Да / Нет
  Boolean_Da=-1' Да
  Boolean_Net=0' Нет
end enum 


''' <summary>
'''Перечисление Для связи журналов друг с другом
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumJournalLinkType'Для связи журналов друг с другом
  JournalLinkType_Net=0' Нет
  JournalLinkType_Svyzka_ParentStructRowID__OPNv_peredlah_ob_ektaCLS=4' Связка ParentStructRowID  (в передлах объекта)
  JournalLinkType_Svyzka_InstanceID_OPNv_peredlah_ob_ektaCLS=3' Связка InstanceID (в передлах объекта)
  JournalLinkType_Ssilka_na_ob_ekt=1' Ссылка на объект
  JournalLinkType_Ssilka_na_stroku=2' Ссылка на строку
end enum 


''' <summary>
'''Перечисление Вариант уровня приложения, куда может генерироваться код
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumTargetType'Вариант уровня приложения, куда может генерироваться код
  TargetType_SUBD=0' СУБД
  TargetType_Dokumentaciy=3' Документация
  TargetType_MODEL_=1' МОДЕЛЬ
  TargetType_Prilogenie=2' Приложение
  TargetType_ARM=4' АРМ
end enum 


''' <summary>
'''Перечисление Четность
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumParityType'Четность
  ParityType_Space=4' Space
  ParityType_Mark=3' Mark
  ParityType_Odd=2' Odd
  ParityType_None=0' None
  ParityType_Even=1' Even
end enum 


''' <summary>
'''Перечисление Формат индикатора
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumMesureFormat'Формат индикатора
  MesureFormat_Cislo=0' Число
  MesureFormat_Data=1' Дата
  MesureFormat_Ob_ekt=4' Объект
  MesureFormat_Spravocnik=2' Справочник
  MesureFormat_Tekst=5' Текст
end enum 


''' <summary>
'''Перечисление Тип экспорта
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumExportType'Тип экспорта
  ExportType_Sayt_i_MB=3' Сайт и МБ
  ExportType_Sayt=1' Сайт
  ExportType_Net=0' Нет
end enum 


''' <summary>
'''Перечисление Тип шага процесса
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumWFStepClass'Тип шага процесса
  WFStepClass_PeriodicFunction=3' PeriodicFunction
  WFStepClass_SimpleFunction=0' SimpleFunction
  WFStepClass_StopFunction=2' StopFunction
  WFStepClass_StartFunction=1' StartFunction
end enum 


''' <summary>
'''Перечисление День недели
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumDayInWeek'День недели
  DayInWeek_Cetverg=4' Четверг
  DayInWeek_Subbota=6' Суббота
  DayInWeek_Ponedel_nik=1' Понедельник
  DayInWeek_Voskresen_e=7' Воскресенье
  DayInWeek_Vtornik=2' Вторник
  DayInWeek_Pytnica=5' Пятница
  DayInWeek_Sreda=3' Среда
end enum 


''' <summary>
'''Перечисление GeneratorStyle
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumGeneratorStyle'GeneratorStyle
  GeneratorStyle_Odin_tip=0' Один тип
  GeneratorStyle_Vse_tipi_srazu=1' Все типы сразу
end enum 


''' <summary>
'''Перечисление Тип плательщика
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumPlatType'Тип плательщика
  PlatType_Polucatel_=1' Получатель
  PlatType_Otpravitel_=0' Отправитель
  PlatType_Drugoy=2' Другой
end enum 


''' <summary>
'''Перечисление Состояние заявки
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enummsgState'Состояние заявки
  msgState_Soobseno_abonentu=1' Сообщено абоненту
  msgState_Promegutocniy_otvet=3' Промежуточный ответ
  msgState_Sostoynie_zayvki=0' Состояние заявки
  msgState_Abonent_ne_otvetil=2' Абонент не ответил
end enum 


''' <summary>
'''Перечисление действие при открытии строки журнала
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumOnJournalRowClick'действие при открытии строки журнала
  OnJournalRowClick_Otkrit__dokument=2' Открыть документ
  OnJournalRowClick_Nicego_ne_delat_=0' Ничего не делать
  OnJournalRowClick_Otkrit__stroku=1' Открыть строку
end enum 


''' <summary>
'''Перечисление PartType
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumPartType'PartType
  PartType_Kollekciy=1' Коллекция
  PartType_Derevo=2' Дерево
  PartType_Stroka=0' Строка
  PartType_Rassirenie_s_dannimi=4' Расширение с данными
  PartType_Rassirenie=3' Расширение
end enum 


''' <summary>
'''Перечисление ReferenceType
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumReferenceType'ReferenceType
  ReferenceType_Na_istocnik_dannih=3' На источник данных
  ReferenceType_Skalyrnoe_pole_OPN_ne_ssilkaCLS=0' Скалярное поле ( не ссылка)
  ReferenceType_Na_stroku_razdela=2' На строку раздела
  ReferenceType_Na_ob_ekt_=1' На объект 
end enum 


''' <summary>
'''Перечисление 
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumstateNomen'
  stateNomen_Dostavleno=4' Доставлено
  stateNomen_Prinyto=2' Принято
  stateNomen_V_processe=3' В процессе
  stateNomen_Pereadresaciy=6' Переадресация
  stateNomen_Oformlyetsy=0' Оформляется
  stateNomen_Vozvrat=5' Возврат
end enum 


''' <summary>
'''Перечисление Варианты условий
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumConditionType'Варианты условий
  ConditionType_LS=6' <
  ConditionType_GTEQ=4' >=
  ConditionType_LSEQ=7' <=
  ConditionType_none=0' none
  ConditionType_EQ=1' =
  ConditionType_like=8' like
  ConditionType_GT=3' >
  ConditionType_LSGT=2' <>
end enum 


''' <summary>
'''Перечисление Тип папки
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumFolderType'Тип папки
  FolderType_Udalennie=3' Удаленные
  FolderType_Vhodysie=1' Входящие
  FolderType_Otlogennie=9' Отложенные
  FolderType_Gurnal=4' Журнал
  FolderType_Ishodysie=2' Исходящие
  FolderType_Cernoviki=7' Черновики
  FolderType_Otpravlennie=6' Отправленные
  FolderType_V_rabote=8' В работе
  FolderType_Kalendar_=5' Календарь
  FolderType_Zaversennie=10' Завершенные
  FolderType_cls__=0' cls__
end enum 


''' <summary>
'''Перечисление Результат
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enummsgResult'Результат
  msgResult_Vipolneno=2' Выполнено
  msgResult_V_rabote=1' В работе
  msgResult_Rezul_tat=0' Результат
end enum 


''' <summary>
'''Перечисление Поведение при добавлении строки раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumPartAddBehaivor'Поведение при добавлении строки раздела
  PartAddBehaivor_AddForm=0' AddForm
  PartAddBehaivor_RunAction=2' RunAction
  PartAddBehaivor_RefreshOnly=1' RefreshOnly
end enum 


''' <summary>
'''Перечисление Тип расширения
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumExtentionType'Тип расширения
  ExtentionType_VerifyRowExt=6' VerifyRowExt
  ExtentionType_CodeGenerator=7' CodeGenerator
  ExtentionType_DefaultExt=5' DefaultExt
  ExtentionType_StatusExt=0' StatusExt
  ExtentionType_JrnlRunExt=4' JrnlRunExt
  ExtentionType_CustomExt=2' CustomExt
  ExtentionType_ARMGenerator=8' ARMGenerator
  ExtentionType_OnFormExt=1' OnFormExt
  ExtentionType_JrnlAddExt=3' JrnlAddExt
end enum 


''' <summary>
'''Перечисление Мужской / Женский
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumSex'Мужской / Женский
  Sex_Ne_susestvenno=0' Не существенно
  Sex_Mugskoy=1' Мужской
  Sex_Genskiy=-1' Женский
end enum 


''' <summary>
'''Перечисление Да / Нет (0 или 1)
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumYesNo'Да / Нет (0 или 1)
  YesNo_Da=1' Да
  YesNo_Net=0' Нет
end enum 


''' <summary>
'''Перечисление Вариант агрегации по полю
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumAggregationType'Вариант агрегации по полю
  AggregationType_SUM=3' SUM
  AggregationType_AVG=1' AVG
  AggregationType_CUSTOM=6' CUSTOM
  AggregationType_none=0' none
  AggregationType_COUNT=2' COUNT
  AggregationType_MAX=5' MAX
  AggregationType_MIN=4' MIN
end enum 


''' <summary>
'''Перечисление Состояние функции в бизнес процессе
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumWFFuncState'Состояние функции в бизнес процессе
  WFFuncState_Processed=8' Processed
  WFFuncState_InWork=3' InWork
  WFFuncState_Pause=4' Pause
  WFFuncState_InControl=6' InControl
  WFFuncState_Active=2' Active
  WFFuncState_Ready=5' Ready
  WFFuncState_Done=7' Done
  WFFuncState_Prepare=1' Prepare
  WFFuncState_Initial=0' Initial
end enum 


''' <summary>
'''Перечисление Занятость
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumEmployment'Занятость
  Employment_Casticnay=1' Частичная
  Employment_Ne_vagno=-1' Не важно
  Employment_Polnay=0' Полная
end enum 


''' <summary>
'''Перечисление Да / Нет / Не определено
''' </summary>
''' <remarks>
'''
''' </remarks>
public enum enumTriState'Да / Нет / Не определено
  TriState_Ne_susestvenno=-1' Не существенно
  TriState_Da=1' Да
  TriState_Net=0' Нет
end enum 



''' <summary>
'''Реализация документа 
''' </summary>
''' <remarks>
'''Справочник
''' </remarks>
    Public Class Application
        Inherits LATIR2.Document.Doc_Base




''' <summary>
'''Название типа документа
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function MyTypeName() As String
            MyTypeName = "TPLD"
        End Function



''' <summary>
''' Внутренняя переменная для раздела Тип подключения
''' </summary>
''' <remarks>
'''
''' </remarks>
  Private m_TPLD_CONNECTTYPE As TPLD_CONNECTTYPE_col


''' <summary>
'''Свойство для доступа к строкам раздела Тип подключения
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public ReadOnly Property TPLD_CONNECTTYPE() As TPLD_CONNECTTYPE_col
            Get
                If m_TPLD_CONNECTTYPE Is Nothing Then
                    m_TPLD_CONNECTTYPE = New TPLD_CONNECTTYPE_col
                    m_TPLD_CONNECTTYPE.Application = Me
                    m_TPLD_CONNECTTYPE.Parent = Me
                    m_TPLD_CONNECTTYPE.Refresh()
                End If
                TPLD_CONNECTTYPE = m_TPLD_CONNECTTYPE
            End Get
        End Property


''' <summary>
''' Внутренняя переменная для раздела Класс устройства
''' </summary>
''' <remarks>
'''
''' </remarks>
  Private m_TPLD_DEVCLASS As TPLD_DEVCLASS_col


''' <summary>
'''Свойство для доступа к строкам раздела Класс устройства
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public ReadOnly Property TPLD_DEVCLASS() As TPLD_DEVCLASS_col
            Get
                If m_TPLD_DEVCLASS Is Nothing Then
                    m_TPLD_DEVCLASS = New TPLD_DEVCLASS_col
                    m_TPLD_DEVCLASS.Application = Me
                    m_TPLD_DEVCLASS.Parent = Me
                    m_TPLD_DEVCLASS.Refresh()
                End If
                TPLD_DEVCLASS = m_TPLD_DEVCLASS
            End Get
        End Property


''' <summary>
''' Внутренняя переменная для раздела Филиал организации
''' </summary>
''' <remarks>
'''
''' </remarks>
  Private m_TPLD_F As TPLD_F_col


''' <summary>
'''Свойство для доступа к строкам раздела Филиал организации
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public ReadOnly Property TPLD_F() As TPLD_F_col
            Get
                If m_TPLD_F Is Nothing Then
                    m_TPLD_F = New TPLD_F_col
                    m_TPLD_F.Application = Me
                    m_TPLD_F.Parent = Me
                    m_TPLD_F.Refresh()
                End If
                TPLD_F = m_TPLD_F
            End Get
        End Property


''' <summary>
''' Внутренняя переменная для раздела Снабжающая организация
''' </summary>
''' <remarks>
'''
''' </remarks>
  Private m_TPLD_SNAB As TPLD_SNAB_col


''' <summary>
'''Свойство для доступа к строкам раздела Снабжающая организация
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public ReadOnly Property TPLD_SNAB() As TPLD_SNAB_col
            Get
                If m_TPLD_SNAB Is Nothing Then
                    m_TPLD_SNAB = New TPLD_SNAB_col
                    m_TPLD_SNAB.Application = Me
                    m_TPLD_SNAB.Parent = Me
                    m_TPLD_SNAB.Refresh()
                End If
                TPLD_SNAB = m_TPLD_SNAB
            End Get
        End Property


''' <summary>
''' Внутренняя переменная для раздела Тип архива
''' </summary>
''' <remarks>
'''
''' </remarks>
  Private m_TPLD_PARAMTYPE As TPLD_PARAMTYPE_col


''' <summary>
'''Свойство для доступа к строкам раздела Тип архива
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public ReadOnly Property TPLD_PARAMTYPE() As TPLD_PARAMTYPE_col
            Get
                If m_TPLD_PARAMTYPE Is Nothing Then
                    m_TPLD_PARAMTYPE = New TPLD_PARAMTYPE_col
                    m_TPLD_PARAMTYPE.Application = Me
                    m_TPLD_PARAMTYPE.Parent = Me
                    m_TPLD_PARAMTYPE.Refresh()
                End If
                TPLD_PARAMTYPE = m_TPLD_PARAMTYPE
            End Get
        End Property


''' <summary>
''' Внутренняя переменная для раздела Группа
''' </summary>
''' <remarks>
'''
''' </remarks>
  Private m_TPLD_GRP As TPLD_GRP_col


''' <summary>
'''Свойство для доступа к строкам раздела Группа
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public ReadOnly Property TPLD_GRP() As TPLD_GRP_col
            Get
                If m_TPLD_GRP Is Nothing Then
                    m_TPLD_GRP = New TPLD_GRP_col
                    m_TPLD_GRP.Application = Me
                    m_TPLD_GRP.Parent = Me
                    m_TPLD_GRP.Refresh()
                End If
                TPLD_GRP = m_TPLD_GRP
            End Get
        End Property


''' <summary>
''' Внутренняя переменная для раздела Поставщик
''' </summary>
''' <remarks>
'''
''' </remarks>
  Private m_TPLD_SNABTOP As TPLD_SNABTOP_col


''' <summary>
'''Свойство для доступа к строкам раздела Поставщик
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public ReadOnly Property TPLD_SNABTOP() As TPLD_SNABTOP_col
            Get
                If m_TPLD_SNABTOP Is Nothing Then
                    m_TPLD_SNABTOP = New TPLD_SNABTOP_col
                    m_TPLD_SNABTOP.Application = Me
                    m_TPLD_SNABTOP.Parent = Me
                    m_TPLD_SNABTOP.Refresh()
                End If
                TPLD_SNABTOP = m_TPLD_SNABTOP
            End Get
        End Property


''' <summary>
''' Внутренняя переменная для раздела Параметры
''' </summary>
''' <remarks>
'''
''' </remarks>
  Private m_TPLD_PARAM As TPLD_PARAM_col


''' <summary>
'''Свойство для доступа к строкам раздела Параметры
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public ReadOnly Property TPLD_PARAM() As TPLD_PARAM_col
            Get
                If m_TPLD_PARAM Is Nothing Then
                    m_TPLD_PARAM = New TPLD_PARAM_col
                    m_TPLD_PARAM.Application = Me
                    m_TPLD_PARAM.Parent = Me
                    m_TPLD_PARAM.Refresh()
                End If
                TPLD_PARAM = m_TPLD_PARAM
            End Get
        End Property


''' <summary>
''' Внутренняя переменная для раздела Тип устройства
''' </summary>
''' <remarks>
'''
''' </remarks>
  Private m_TPLD_DEVTYPE As TPLD_DEVTYPE_col


''' <summary>
'''Свойство для доступа к строкам раздела Тип устройства
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public ReadOnly Property TPLD_DEVTYPE() As TPLD_DEVTYPE_col
            Get
                If m_TPLD_DEVTYPE Is Nothing Then
                    m_TPLD_DEVTYPE = New TPLD_DEVTYPE_col
                    m_TPLD_DEVTYPE.Application = Me
                    m_TPLD_DEVTYPE.Parent = Me
                    m_TPLD_DEVTYPE.Refresh()
                End If
                TPLD_DEVTYPE = m_TPLD_DEVTYPE
            End Get
        End Property


''' <summary>
'''Количество разделов в объекте
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides ReadOnly Property CountOfParts() As Long
            Get
                CountOfParts = 9
            End Get
        End Property



''' <summary>
'''Получить раздел по номеру
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function GetDocCollection_Base(ByVal Index As Long) As DocCollection_Base
            Select Case Index
         Case 1
            return TPLD_SNABTOP
         Case 2
            return TPLD_PARAM
         Case 3
            return TPLD_SNAB
         Case 4
            return TPLD_F
         Case 5
            return TPLD_CONNECTTYPE
         Case 6
            return TPLD_DEVCLASS
         Case 7
            return TPLD_DEVTYPE
         Case 8
            return TPLD_GRP
         Case 9
            return TPLD_PARAMTYPE
            End Select
            return nothing
        End Function

        Public Overrides Sub Dispose()
            TPLD_SNABTOP.Dispose()
            TPLD_PARAM.Dispose()
            TPLD_SNAB.Dispose()
            TPLD_F.Dispose()
            TPLD_CONNECTTYPE.Dispose()
            TPLD_DEVCLASS.Dispose()
            TPLD_DEVTYPE.Dispose()
            TPLD_GRP.Dispose()
            TPLD_PARAMTYPE.Dispose()
        End Sub



''' <summary>
'''Поиск элемента в коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function FindInCollections(ByVal Table As String, ByVal InstID As String) As LATIR2.Document.DocRow_Base
        FindInCollections = Nothing
            dim mFindInCollections As LATIR2.Document.DocRow_Base
            mFindInCollections = TPLD_SNABTOP.FindObject(Table, InstID)
            if not mFindInCollections is nothing then return mFindInCollections
            mFindInCollections = TPLD_PARAM.FindObject(Table, InstID)
            if not mFindInCollections is nothing then return mFindInCollections
            mFindInCollections = TPLD_SNAB.FindObject(Table, InstID)
            if not mFindInCollections is nothing then return mFindInCollections
            mFindInCollections = TPLD_F.FindObject(Table, InstID)
            if not mFindInCollections is nothing then return mFindInCollections
            mFindInCollections = TPLD_CONNECTTYPE.FindObject(Table, InstID)
            if not mFindInCollections is nothing then return mFindInCollections
            mFindInCollections = TPLD_DEVCLASS.FindObject(Table, InstID)
            if not mFindInCollections is nothing then return mFindInCollections
            mFindInCollections = TPLD_DEVTYPE.FindObject(Table, InstID)
            if not mFindInCollections is nothing then return mFindInCollections
            mFindInCollections = TPLD_GRP.FindObject(Table, InstID)
            if not mFindInCollections is nothing then return mFindInCollections
            mFindInCollections = TPLD_PARAMTYPE.FindObject(Table, InstID)
            if not mFindInCollections is nothing then return mFindInCollections
        End Function



''' <summary>
'''Загрузка данных из XML  файла
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Sub XMLLoadCollections(ByVal node As System.Xml.XmlNode, Optional ByVal LoadMode As Integer = 0)
            Dim e_list As XmlNodeList
           try
            e_list = node.SelectNodes("TPLD_SNABTOP_COL")
            TPLD_SNABTOP.XMLLoad(e_list, LoadMode)
            e_list = node.SelectNodes("TPLD_PARAM_COL")
            TPLD_PARAM.XMLLoad(e_list, LoadMode)
            e_list = node.SelectNodes("TPLD_SNAB_COL")
            TPLD_SNAB.XMLLoad(e_list, LoadMode)
            e_list = node.SelectNodes("TPLD_F_COL")
            TPLD_F.XMLLoad(e_list, LoadMode)
            e_list = node.SelectNodes("TPLD_CONNECTTYPE_COL")
            TPLD_CONNECTTYPE.XMLLoad(e_list, LoadMode)
            e_list = node.SelectNodes("TPLD_DEVCLASS_COL")
            TPLD_DEVCLASS.XMLLoad(e_list, LoadMode)
            e_list = node.SelectNodes("TPLD_DEVTYPE_COL")
            TPLD_DEVTYPE.XMLLoad(e_list, LoadMode)
            e_list = node.SelectNodes("TPLD_GRP_COL")
            TPLD_GRP.XMLLoad(e_list, LoadMode)
            e_list = node.SelectNodes("TPLD_PARAMTYPE_COL")
            TPLD_PARAMTYPE.XMLLoad(e_list, LoadMode)
catch ex as System.Exception
 Debug.Print( ex.Message + " >> " + ex.StackTrace)
end try
        End Sub



''' <summary>
'''Сохранение данных в XML  файле
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub XMLSaveCollections(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)
            TPLD_SNABTOP.XMLSave(node, Xdom)
            TPLD_PARAM.XMLSave(node, Xdom)
            TPLD_SNAB.XMLSave(node, Xdom)
            TPLD_F.XMLSave(node, Xdom)
            TPLD_CONNECTTYPE.XMLSave(node, Xdom)
            TPLD_DEVCLASS.XMLSave(node, Xdom)
            TPLD_DEVTYPE.XMLSave(node, Xdom)
            TPLD_GRP.XMLSave(node, Xdom)
            TPLD_PARAMTYPE.XMLSave(node, Xdom)
        End Sub



''' <summary>
'''Сохранение изменений в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Overrides Sub BatchUpdate()
    TPLD_SNABTOP.BatchUpdate
    TPLD_PARAM.BatchUpdate
    TPLD_SNAB.BatchUpdate
    TPLD_F.BatchUpdate
    TPLD_CONNECTTYPE.BatchUpdate
    TPLD_DEVCLASS.BatchUpdate
    TPLD_DEVTYPE.BatchUpdate
    TPLD_GRP.BatchUpdate
    TPLD_PARAMTYPE.BatchUpdate
End Sub
    End Class
End Namespace
