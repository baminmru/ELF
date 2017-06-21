
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics

  Imports LATIR2GuiManager
Public Class viewTPLD_PARAM
    Inherits System.Windows.Forms.UserControl
    Implements LATIR2GUIManager.IViewPanel

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose (disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents gv As LATIR2GUIControls.GridView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.gv = New LATIR2GUIControls.GridView
        Me.SuspendLayout()
        '
        'gv
        '
        Me.gv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gv.Location = New System.Drawing.Point(0, 0)
        Me.gv.name = "gv"
        Me.gv.Size = New System.Drawing.Size(424, 216)
        Me.gv.TabIndex = 0
        '
        'viewTPLD_PARAM
        '
        Me.Controls.Add (Me.gv)
        Me.name = "viewTPLD_PARAM"
        Me.Size = New System.Drawing.Size(424, 216)
        Me.ResumeLayout (False)

    End Sub

#End Region
    Public item As TPLD.TPLD.Application
    Private mReadOnly as boolean
    Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Sub Attach(ByVal docItem As LATIR2.Document.Doc_Base, ByVal gm As LATIR2GuiManager.LATIRGuiManager, byval ReadOnlyView as boolean )  Implements LATIR2GUIManager.IViewPanel.Attach
        mReadOnly = ReadOnlyView
        item = CType(docItem, TPLD.TPLD.Application)
        GuiManager = gm
        Init()
    End Sub


''' <summary>
'''Load table settings
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Sub Init()
        Dim ts As DataGridTableStyle
        Dim cs As DataGridTextBoxColumn
        Dim dt As DataTable
        dt = item.TPLD_PARAM.GetDataTable()
        dt.TableName = "TPLD_PARAM"

        ts = New DataGridTableStyle
        ts.MappingName = "TPLD_PARAM"
        ts.ReadOnly = True
        ts.RowHeaderWidth = 30


        cs = New DataGridTextBoxColumn
         cs.ReadOnly = True
        cs.HeaderText = "Название "
        cs.MappingName = "Name"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        cs = New DataGridTextBoxColumn
         cs.ReadOnly = True
        cs.HeaderText = "Поле"
        cs.MappingName = "ParamField"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        cs = New DataGridTextBoxColumn
         cs.ReadOnly = True
        cs.HeaderText = "Отображать как"
        cs.MappingName = "ShowAs"
        cs.NullText = ""
        ts.GridColumnStyles.Add (cs)

        gv.InitFields (ts)
        gv.SetData (dt)
    End Sub




''' <summary>
'''Обслуживание редактирования Edit action
''' </summary>
''' <remarks>
'''
''' </remarks>
    Private Sub gv_OnEdit(ByRef OK As Boolean, ByVal ID As System.Guid) Handles gv.OnGridEdit
        Dim ed As TPLD.TPLD.TPLD_PARAM
        ed = item.FindRowObject("TPLD_PARAM", ID)
        Dim gui As Doc_GUIBase

        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
        If gui.ShowPartEditForm("", CType(ed, LATIR2.Document.DocRow_Base), mReadOnly ) = True Then
            Dim dt As DataTable
            dt = item.TPLD_PARAM.GetDataTable()
            dt.TableName = "TPLD_PARAM"
            gv.SetData (dt)
        End If

    End Sub



''' <summary>
'''Обслуживание удаления Delete action
''' </summary>
''' <remarks>
'''
''' </remarks>
    Private Sub gv_OnDel(ByRef OK As Boolean, ByVal ID As System.Guid) Handles gv.OnGridDel
      If not mReadOnly Then
        Dim ed As TPLD.TPLD.TPLD_PARAM
        ed = item.FindRowObject("TPLD_PARAM", ID)
        If MsgBox("Удалить <" & ed.Brief & "> ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Удаление") = MsgBoxResult.Yes Then
            OK = ed.Parent.Delete(ed.ID.ToString)
            If OK Then
                Dim dt As DataTable
                dt = item.TPLD_PARAM.GetDataTable()
                dt.TableName = "TPLD_PARAM"
                gv.SetData (dt)
            End If
        End If
      End If
    End Sub



''' <summary>
'''Обслуживание создания записи Create action
''' </summary>
''' <remarks>
'''
''' </remarks>
    Private Sub gv_OnAdd(ByRef OK As Boolean, ByVal ID As System.Guid) Handles gv.OnGridAdd
      If not mReadOnly Then
        Dim ed As TPLD.TPLD.TPLD_PARAM
        If ID.Equals(System.guid.Empty) Then
              ed = Item.TPLD_PARAM.Add
          Else
              ed = Item.TPLD_PARAM.Add(ID.ToString())
          End If
        Dim gui As Doc_GUIBase
        Dim dt As DataTable
        gui = GuiManager.GetTypeGUI(ed.Application.TypeName)
        If gui.ShowPartEditForm("", CType(ed,LATIR2.Document.DocRow_Base) ) = True Then
            dt = item.TPLD_PARAM.GetDataTable()
            dt.TableName = "TPLD_PARAM"
            gv.SetData (dt)
        Else
            item.TPLD_PARAM.Refresh()
        End If
      End If
    End Sub



''' <summary>
'''Обслуживание кнопки (обновить) refresh action
''' </summary>
''' <remarks>
'''
''' </remarks>
    Private Sub gv_OnRefresh() Handles gv.OnGridRefresh
        Dim dt As DataTable
        item.TPLD_PARAM.Refresh()
        dt = item.TPLD_PARAM.GetDataTable()
        dt.TableName = "TPLD_PARAM"
        gv.SetData (dt)
    End Sub
 Public Function Save(ByVal Sielent As Boolean, ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Save
     Return true
 End Function
 Public Function IsOK() As Boolean Implements LATIR2GUIManager.IViewPanel.IsOK
     Return true
 End Function
 Public Function IsChanged() As Boolean Implements LATIR2GUIManager.IViewPanel.IsChanged
     Return false
 End Function
 Public Function Verify(ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Verify
     Return true
 End Function
End Class