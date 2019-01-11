
var actionbpc = Ext.create('Ext.Action', {
    itemId:             'actionbpc',
    text:               'Клиент',
    iconCls:            'icon-brick',
			 disabled:defaultMenuDisabled,
			 hidden:defaultMenuHidden,
             handler: function(){
			var j=Ext.getCmp('bpc_jrnl');
			if(j==null){
				j=bpc_Jrnl();
				j.iconCls='icon-brick';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
             }
});
var actionbpdi = Ext.create('Ext.Action', {
    itemId:             'actionbpdi',
    text:               'Интерфейс',
    iconCls:            'icon-application_side_tree',
			 disabled:defaultMenuDisabled,
			 hidden:defaultMenuHidden,
             handler: function(){
			var j=Ext.getCmp('bpdi_jrnl');
			if(j==null){
				j=bpdi_Jrnl();
				j.iconCls='icon-application_side_tree';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
             }
});
var actionbpdr = Ext.create('Ext.Action', {
    itemId:             'actionbpdr',
    text:               'Роль сотрудника',
    iconCls:            'icon-chart_org_inverted',
			 disabled:defaultMenuDisabled,
			 hidden:defaultMenuHidden,
             handler: function(){
			var j=Ext.getCmp('bpdr_jrnl');
			if(j==null){
				j=bpdr_Jrnl();
				j.iconCls='icon-chart_org_inverted';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
             }
});
var actionbprcfg = Ext.create('Ext.Action', {
    itemId:             'actionbprcfg',
    text:               'Настройка роли',
    iconCls:            'icon-folder_user',
			 disabled:defaultMenuDisabled,
			 hidden:defaultMenuHidden,
             handler: function(){
			var j=Ext.getCmp('bprcfg_jrnl');
			if(j==null){
				j=bprcfg_Jrnl();
				j.iconCls='icon-folder_user';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
             }
});
var actionbpu = Ext.create('Ext.Action', {
    itemId:             'actionbpu',
    text:               'Сотрудник',
    iconCls:            'icon-user',
			 disabled:defaultMenuDisabled,
			 hidden:defaultMenuHidden,
             handler: function(){
			var j=Ext.getCmp('bpu_jrnl');
			if(j==null){
				j=bpu_Jrnl();
				j.iconCls='icon-user';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
             }
});
var actionTPLC = Ext.create('Ext.Action', {
    itemId:             'actionTPLC',
    text:               'Данные',
    iconCls:            'icon-brick',
			 disabled:defaultMenuDisabled,
			 hidden:defaultMenuHidden,
             handler: function(){
			var j=Ext.getCmp('tplc_jrnl');
			if(j==null){
				j=TPLC_Jrnl();
				j.iconCls='icon-brick';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
             }
});
var actionTPLD = Ext.create('Ext.Action', {
    itemId:             'actionTPLD',
    text:               'Справочник',
    iconCls:            'icon-brick',
			 disabled:defaultMenuDisabled,
			 hidden:defaultMenuHidden,
             handler: function(){
			var j=Ext.getCmp('tpld_jrnl');
			if(j==null){
				j=TPLD_Jrnl();
				j.iconCls='icon-brick';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
             }
});
var actionTPLS = Ext.create('Ext.Action', {
    itemId:             'actionTPLS',
    text:               'Схема подключения',
    iconCls:            'icon-brick',
			 disabled:defaultMenuDisabled,
			 hidden:defaultMenuHidden,
             handler: function(){
			var j=Ext.getCmp('tpls_jrnl');
			if(j==null){
				j=TPLS_Jrnl();
				j.iconCls='icon-brick';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
             }
});
var actionTPLT = Ext.create('Ext.Action', {
    itemId:             'actionTPLT',
    text:               'Устройство',
    iconCls:            'icon-brick',
			 disabled:defaultMenuDisabled,
			 hidden:defaultMenuHidden,
             handler: function(){
			var j=Ext.getCmp('tplt_jrnl');
			if(j==null){
				j=TPLT_Jrnl();
				j.iconCls='icon-brick';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
             }
});
var actionTPN = Ext.create('Ext.Action', {
    itemId:             'actionTPN',
    text:               'Узел',
    iconCls:            'icon-brick',
			 disabled:defaultMenuDisabled,
			 hidden:defaultMenuHidden,
             handler: function(){
			var j=Ext.getCmp('tpn_jrnl');
			if(j==null){
				j=TPN_Jrnl();
				j.iconCls='icon-brick';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
             }
});
var actionTPQ = Ext.create('Ext.Action', {
    itemId:             'actionTPQ',
    text:               'Запрос на обработку',
    iconCls:            'icon-brick',
			 disabled:defaultMenuDisabled,
			 hidden:defaultMenuHidden,
             handler: function(){
			var j=Ext.getCmp('tpq_jrnl');
			if(j==null){
				j=TPQ_Jrnl();
				j.iconCls='icon-brick';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
             }
});
var actionTPSRV = Ext.create('Ext.Action', {
    itemId:             'actionTPSRV',
    text:               'Сервер',
    iconCls:            'icon-brick',
			 disabled:defaultMenuDisabled,
			 hidden:defaultMenuHidden,
             handler: function(){
			var j=Ext.getCmp('tpsrv_jrnl');
			if(j==null){
				j=TPSRV_Jrnl();
				j.iconCls='icon-brick';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
             }
});
var actionbpdi = Ext.create('Ext.Action', {
        itemId:  'actionbpdi',
        text:   'Интерфейс',
        iconCls:  'icon-application_side_tree',
			 disabled:defaultMenuDisabled,
			 hidden:defaultMenuHidden,
			handler: function(){
			var j=Ext.getCmp('bpdi');
			if(j==null){
				j=eval('bpdi_Panel_'+OTEditMode('bpdi')+'(\'{92F6DFAF-E444-43A7-BFCD-362C37A3503F}\', true)');
        j.iconCls= 'icon-application_side_tree';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
        }
    });
var actionbpdr = Ext.create('Ext.Action', {
        itemId:  'actionbpdr',
        text:   'Роль сотрудника',
        iconCls:  'icon-chart_org_inverted',
			 disabled:defaultMenuDisabled,
			 hidden:defaultMenuHidden,
			handler: function(){
			var j=Ext.getCmp('bpdr');
			if(j==null){
				j=eval('bpdr_Panel_'+OTEditMode('bpdr')+'(\'{96796F0F-F33F-499F-8250-9E590CE6BDCB}\', true)');
        j.iconCls= 'icon-chart_org_inverted';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
        }
    });
var actionMTZMetaModel = Ext.create('Ext.Action', {
        itemId:  'actionMTZMetaModel',
        text:   'Спец.: Метамодель системы',
        iconCls:  'icon-brick',
			 disabled:defaultMenuDisabled,
			 hidden:defaultMenuHidden,
			handler: function(){
			var j=Ext.getCmp('mtzmetamodel');
			if(j==null){
				j=eval('MTZMetaModel_Panel_'+OTEditMode('MTZMetaModel')+'(\'{88DEEBA4-69B1-454A-992A-FAE3CEBFBCA1}\', true)');
        j.iconCls=  'icon-brick';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
        }
    });
var actionMTZSystem = Ext.create('Ext.Action', {
        itemId:  'actionMTZSystem',
        text:   'Спец.: Системные данные',
        iconCls:  'icon-brick',
			 disabled:defaultMenuDisabled,
			 hidden:defaultMenuHidden,
			handler: function(){
			var j=Ext.getCmp('mtzsystem');
			if(j==null){
				j=eval('MTZSystem_Panel_'+OTEditMode('MTZSystem')+'(\'{C5A874A1-1D01-43F5-AA2B-5431031FD45C}\', true)');
        j.iconCls=  'icon-brick';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
        }
    });
var actionMTZUsers = Ext.create('Ext.Action', {
        itemId:  'actionMTZUsers',
        text:   'Справочник: пользователи',
        iconCls:  'icon-brick',
			 disabled:defaultMenuDisabled,
			 hidden:defaultMenuHidden,
			handler: function(){
			var j=Ext.getCmp('mtzusers');
			if(j==null){
				j=eval('MTZUsers_Panel_'+OTEditMode('MTZUsers')+'(\'{E0FB5E85-050E-4322-8505-9E0CA132E901}\', true)');
        j.iconCls=  'icon-brick';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
        }
    });
var actionTPLD = Ext.create('Ext.Action', {
        itemId:  'actionTPLD',
        text:   'Справочник',
        iconCls:  'icon-brick',
			 disabled:defaultMenuDisabled,
			 hidden:defaultMenuHidden,
			handler: function(){
			var j=Ext.getCmp('tpld');
			if(j==null){
				j=eval('TPLD_Panel_'+OTEditMode('TPLD')+'(\'{24401A4A-16AF-4CFA-9B94-A6CD60E09EE6}\', true)');
        j.iconCls=  'icon-brick';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
        }
    });