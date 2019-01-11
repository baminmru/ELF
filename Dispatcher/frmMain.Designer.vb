<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim UltraTaskPaneToolbar1 As Infragistics.Win.UltraWinToolbars.UltraTaskPaneToolbar = New Infragistics.Win.UltraWinToolbars.UltraTaskPaneToolbar("tool1")
        Dim TaskPaneTool1 As Infragistics.Win.UltraWinToolbars.TaskPaneTool = New Infragistics.Win.UltraWinToolbars.TaskPaneTool("p1")
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuManualQuery = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSchema = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDic = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuServerSetup = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAnalizeLosot = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.UltraTabbedMdiManager1 = New Infragistics.Win.UltraWinTabbedMdi.UltraTabbedMdiManager(Me.components)
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        Me.tree = New Infragistics.Win.UltraWinTree.UltraTree()
        Me.cmdTest = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonConfig = New System.Windows.Forms.Button()
        Me._frmMain_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.UltraToolbarsManager1 = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me._frmMain_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._frmMain_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._frmMain_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        CType(Me.UltraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel1.ClientArea.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        CType(Me.tree, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraToolbarsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.HelpMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(655, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.mnuManualQuery, Me.mnuSchema, Me.ToolStripSeparator4, Me.mnuDic, Me.mnuServerSetup, Me.mnuAnalizeLosot, Me.PrintSetupToolStripMenuItem, Me.ToolStripSeparator5, Me.ExitToolStripMenuItem})
        Me.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(48, 20)
        Me.FileMenu.Text = "&Файл"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(257, 6)
        '
        'mnuManualQuery
        '
        Me.mnuManualQuery.Name = "mnuManualQuery"
        Me.mnuManualQuery.Size = New System.Drawing.Size(260, 22)
        Me.mnuManualQuery.Text = "Данные"
        '
        'mnuSchema
        '
        Me.mnuSchema.Name = "mnuSchema"
        Me.mnuSchema.Size = New System.Drawing.Size(260, 22)
        Me.mnuSchema.Text = "Схема подключения"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(257, 6)
        '
        'mnuDic
        '
        Me.mnuDic.Name = "mnuDic"
        Me.mnuDic.Size = New System.Drawing.Size(260, 22)
        Me.mnuDic.Text = "Справочник"
        '
        'mnuServerSetup
        '
        Me.mnuServerSetup.Name = "mnuServerSetup"
        Me.mnuServerSetup.Size = New System.Drawing.Size(260, 22)
        Me.mnuServerSetup.Text = " Настройка сервера опроса"
        '
        'mnuAnalizeLosot
        '
        Me.mnuAnalizeLosot.Name = "mnuAnalizeLosot"
        Me.mnuAnalizeLosot.Size = New System.Drawing.Size(260, 22)
        Me.mnuAnalizeLosot.Text = "Проверить пропущенные архивы"
        '
        'PrintSetupToolStripMenuItem
        '
        Me.PrintSetupToolStripMenuItem.Name = "PrintSetupToolStripMenuItem"
        Me.PrintSetupToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.PrintSetupToolStripMenuItem.Text = "Print Setup"
        Me.PrintSetupToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(257, 6)
        Me.ToolStripSeparator5.Visible = False
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.ExitToolStripMenuItem.Text = "В&ыход"
        '
        'HelpMenu
        '
        Me.HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator8, Me.AboutToolStripMenuItem})
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.Size = New System.Drawing.Size(44, 20)
        Me.HelpMenu.Text = "&Help"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(116, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.AboutToolStripMenuItem.Text = "&About ..."
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 476)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(655, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel.Text = "Status"
        '
        'UltraTabbedMdiManager1
        '
        Me.UltraTabbedMdiManager1.MdiParent = Me
        '
        'UltraPanel1
        '
        Me.UltraPanel1.Anchor = System.Windows.Forms.AnchorStyles.None
        '
        'UltraPanel1.ClientArea
        '
        Me.UltraPanel1.ClientArea.Controls.Add(Me.tree)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.cmdTest)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label1)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.ButtonConfig)
        Me.UltraPanel1.Location = New System.Drawing.Point(0, 49)
        Me.UltraPanel1.Name = "UltraPanel1"
        Me.UltraPanel1.Size = New System.Drawing.Size(225, 427)
        Me.UltraPanel1.TabIndex = 14
        '
        'tree
        '
        Me.tree.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tree.Location = New System.Drawing.Point(12, 34)
        Me.tree.Name = "tree"
        Me.tree.NodeConnectorStyle = Infragistics.Win.UltraWinTree.NodeConnectorStyle.None
        Me.tree.Size = New System.Drawing.Size(197, 352)
        Me.tree.TabIndex = 17
        '
        'cmdTest
        '
        Me.cmdTest.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdTest.Location = New System.Drawing.Point(147, 392)
        Me.cmdTest.Name = "cmdTest"
        Me.cmdTest.Size = New System.Drawing.Size(62, 23)
        Me.cmdTest.TabIndex = 16
        Me.cmdTest.Text = "Тест"
        Me.cmdTest.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Спиксок узлов"
        '
        'ButtonConfig
        '
        Me.ButtonConfig.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonConfig.Cursor = System.Windows.Forms.Cursors.Default
        Me.ButtonConfig.Location = New System.Drawing.Point(12, 392)
        Me.ButtonConfig.Name = "ButtonConfig"
        Me.ButtonConfig.Size = New System.Drawing.Size(82, 23)
        Me.ButtonConfig.TabIndex = 14
        Me.ButtonConfig.Text = "Настройка"
        Me.ButtonConfig.UseVisualStyleBackColor = True
        '
        '_frmMain_Toolbars_Dock_Area_Left
        '
        Me._frmMain_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmMain_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(215, Byte), Integer))
        Me._frmMain_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._frmMain_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmMain_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 24)
        Me._frmMain_Toolbars_Dock_Area_Left.Name = "_frmMain_Toolbars_Dock_Area_Left"
        Me._frmMain_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(204, 452)
        Me._frmMain_Toolbars_Dock_Area_Left.ToolbarsManager = Me.UltraToolbarsManager1
        '
        'UltraToolbarsManager1
        '
        Me.UltraToolbarsManager1.DesignerFlags = 1
        Me.UltraToolbarsManager1.DockWithinContainer = Me
        Me.UltraToolbarsManager1.DockWithinContainerBaseType = GetType(System.Windows.Forms.Form)
        Me.UltraToolbarsManager1.ShowFullMenusDelay = 500
        Me.UltraToolbarsManager1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.VisualStudio2005
        UltraTaskPaneToolbar1.DockedColumn = 0
        UltraTaskPaneToolbar1.DockedContentExtent = 200
        UltraTaskPaneToolbar1.DockedContentExtentMin = 150
        UltraTaskPaneToolbar1.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        UltraTaskPaneToolbar1.DockedRow = 0
        UltraTaskPaneToolbar1.FloatingContentSize = New System.Drawing.Size(200, 300)
        UltraTaskPaneToolbar1.FloatingContentSizeMin = New System.Drawing.Size(200, 300)
        UltraTaskPaneToolbar1.Settings.AllowCustomize = Infragistics.Win.DefaultableBoolean.[False]
        UltraTaskPaneToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.[False]
        UltraTaskPaneToolbar1.Text = "Узлы"
        Me.UltraToolbarsManager1.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraTaskPaneToolbar1})
        TaskPaneTool1.ControlName = "UltraPanel1"
        TaskPaneTool1.HeaderCaption = "Узлы"
        TaskPaneTool1.SharedPropsInternal.Caption = "TaskPaneTool1"
        Me.UltraToolbarsManager1.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {TaskPaneTool1})
        '
        '_frmMain_Toolbars_Dock_Area_Right
        '
        Me._frmMain_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmMain_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(215, Byte), Integer))
        Me._frmMain_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._frmMain_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmMain_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(655, 24)
        Me._frmMain_Toolbars_Dock_Area_Right.Name = "_frmMain_Toolbars_Dock_Area_Right"
        Me._frmMain_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 452)
        Me._frmMain_Toolbars_Dock_Area_Right.ToolbarsManager = Me.UltraToolbarsManager1
        '
        '_frmMain_Toolbars_Dock_Area_Top
        '
        Me._frmMain_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmMain_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(215, Byte), Integer))
        Me._frmMain_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._frmMain_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmMain_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._frmMain_Toolbars_Dock_Area_Top.Name = "_frmMain_Toolbars_Dock_Area_Top"
        Me._frmMain_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(655, 0)
        Me._frmMain_Toolbars_Dock_Area_Top.ToolbarsManager = Me.UltraToolbarsManager1
        '
        '_frmMain_Toolbars_Dock_Area_Bottom
        '
        Me._frmMain_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmMain_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(215, Byte), Integer))
        Me._frmMain_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._frmMain_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmMain_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 476)
        Me._frmMain_Toolbars_Dock_Area_Bottom.Name = "_frmMain_Toolbars_Dock_Area_Bottom"
        Me._frmMain_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(655, 0)
        Me._frmMain_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.UltraToolbarsManager1
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 498)
        Me.Controls.Add(Me.UltraPanel1)
        Me.Controls.Add(Me._frmMain_Toolbars_Dock_Area_Left)
        Me.Controls.Add(Me._frmMain_Toolbars_Dock_Area_Right)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me._frmMain_Toolbars_Dock_Area_Top)
        Me.Controls.Add(Me._frmMain_Toolbars_Dock_Area_Bottom)
        Me.Controls.Add(Me.StatusStrip)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "frmMain"
        Me.Text = "АБОЛЪ. Диспетчер"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.UltraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraPanel1.ClientArea.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.PerformLayout()
        Me.UltraPanel1.ResumeLayout(False)
        CType(Me.tree, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraToolbarsManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents UltraTabbedMdiManager1 As Infragistics.Win.UltraWinTabbedMdi.UltraTabbedMdiManager
    Friend WithEvents mnuManualQuery As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraPanel1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents tree As Infragistics.Win.UltraWinTree.UltraTree
    Friend WithEvents cmdTest As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonConfig As System.Windows.Forms.Button
    Friend WithEvents _frmMain_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents UltraToolbarsManager1 As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents _frmMain_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _frmMain_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _frmMain_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents mnuSchema As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDic As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuServerSetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAnalizeLosot As System.Windows.Forms.ToolStripMenuItem

End Class
