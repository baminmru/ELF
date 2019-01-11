
var groupingFeature_autotplt_bdevices = Ext.create('Ext.grid.feature.Grouping',{
groupByText:  'Группировать по этому полю',
showGroupsText:  'Показать группировку'
});
var interval_autotplt_bdevices;
Ext.define('grid_autotplt_bdevices', {
    extend:  'Ext.grid.Panel',
    alias: 'widget.g_v_autotplt_bdevices',
    requires: [
        'Ext.grid.*',
        'Ext.form.field.Text',
        'Ext.toolbar.TextItem'
    ],
    initComponent: function(){
        Ext.apply(this, {
        frame: false,
        store: store_v_autotplt_bdevices,
        features: [groupingFeature_autotplt_bdevices],
        defaultDockWeights : { top: 7, bottom: 5, left: 1, right: 3 },
        viewConfig: {               enableTextSelection: true        },
        dockedItems: [{
                xtype:  'toolbar',
                     items: [{
                    iconCls:  'icon-application_form_add',
                    text:   'Создать',
                    scope:  this,
                    handler : this.onAddClick
                    }, {
                    iconCls:  'icon-application_form_edit',
                    text:   'Изменить',
                    itemId:  'edit',
                    disabled: true,
                    scope:  this,
                    handler : this.onEditClick
                    }, {
                    iconCls:  'icon-application_form_delete',
                    text:   'Удалить',
                    disabled: true,
                    itemId:  'delete',
                    scope:  this,
                    handler : this.onDeleteClick
                    }, {
                    iconCls:  'icon-table_refresh',
                    text:   'Обновить',
                    itemId:  'bRefresh',
                    scope:  this,
                    handler : this.onRefreshClick
                   } , {
                    iconCls:  'icon-page_excel',
                    text:   'Экспорт',
                    itemId:  'bExport',
                    scope:  this,
                    handler: this.onExportClick
                }]
            }],
        columns: [
            {text: "Узел", width:120, dataIndex: 'tplt_bdevices_thenode', sortable: true}
            ,
            {text: "Название", width:120, dataIndex: 'tplt_bdevices_name', sortable: true}
            ,
            {text: "Телефон", width:120, dataIndex: 'tplt_bdevices_thephone', sortable: true}
            ,
            {text: "Адрес", width:120, dataIndex: 'tplt_bdevices_addr', sortable: true}
            ,
            {text: "Устройство", width:120, dataIndex: 'tplt_bdevices_devtype', sortable: true}
            ,
            {text: "Снабжающая орг.", width:120, dataIndex: 'tplt_bdevices_shab', sortable: true}
            ,
            {text: "Группа", width:120, dataIndex: 'tplt_bdevices_devgrp', sortable: true}
            ,
            {text: "Схема подключения", width:120, dataIndex: 'tplt_bdevices_theschema', sortable: true}
            ,
            {text: "Сервер", width:120, dataIndex: 'tplt_bdevices_theserver', sortable: true}
            ,
            {text: "Заблокированно до", width:120, dataIndex: 'tplt_bdevices_nplock', sortable: true,renderer:myDateRenderer}
            ,
            {text: "Подключен", width:120, dataIndex: 'tplt_bdevices_connected', sortable: true}
        ]
        ,
        bbar: Ext.create('Ext.PagingToolbar', {
        store: store_v_autotplt_bdevices,
        displayInfo: true,
        displayMsg:  'Показаны строки с {0} по {1} из {2}',
        emptyMsg: 'нет данных'
        
        })

, rbar:
                [
                {
                    xtype:  'form',
                    title:  'Фильтры',
                    iconCls:  'icon-find',
                    flex:1,
					collapsible:true,
                    collapseDirection:  'right',
					animCollapse: false, 
					titleCollapse:true,
					bodyPadding:5,
					width:200,
					minWidth:200,
					autoScroll:true,
                    buttonAlign:  'center',
					layout: {
                    type:   'vbox',
                    align:  'stretch'
				},
                defaultType:  'textfield',
				items: [
{

trigger1Cls:        'x-form-clear-trigger', 
trigger2Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
hideTrigger2:false, 
onTrigger1Click : function(){
		this.collapse();
		this.clearValue();
},
onTrigger2Click : function(){ 
		if(this.isExpanded) {
			this.collapse(); 
		}else{ 
			if(this.store.count(false)==0) this.store.load();
			this.expand();
		}
},
editable: true,
enableRegEx: true,
queryMode:'local',
listeners:{  focus: function()   { if(this.store.count(false)==0) this.store.load();  } ,render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Узел'});} },
xtype:  'combobox',
store: cmbstore_tpn_def,
valueField:     'id',
displayField:   'brief',
typeAhead: true,
name:   'tplt_bdevices_thenode_id',
itemId:   'tplt_bdevices_thenode_id',
fieldLabel:  '',
emptyText:      'Узел',
hideLabel:  true
}
,
{

value:  '',
name:   'tplt_bdevices_name',
itemId:   'tplt_bdevices_name',
fieldLabel:  '',
emptyText:      'Название',
hideLabel:  true,
listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Название'});}}
}
,
{

value:  '',
name:   'tplt_bdevices_thephone',
itemId:   'tplt_bdevices_thephone',
fieldLabel:  '',
emptyText:      'Телефон',
hideLabel:  true,
listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Телефон'});}}
}
,
{

xtype:  'textfield',
value:  '',
name:   'tplt_bdevices_addr',
itemId:   'tplt_bdevices_addr',
fieldLabel:  '',
emptyText:      'Адрес',
hideLabel:  true,
listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Адрес'});}}
}
,
{

trigger1Cls:        'x-form-clear-trigger', 
trigger2Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
hideTrigger2:false, 
onTrigger1Click : function(){
		this.collapse();
		this.clearValue();
},
onTrigger2Click : function(){ 
		if(this.isExpanded) {
			this.collapse(); 
		}else{ 
			if(this.store.count(false)==0) this.store.load();
			this.expand();
		}
},
editable: true,
enableRegEx: true,
queryMode:'local',
listeners:{  focus: function()   { if(this.store.count(false)==0) this.store.load();  } ,render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Устройство'});} },
xtype:  'combobox',
store: cmbstore_tpld_devtype,
valueField:     'id',
displayField:   'brief',
typeAhead: true,
name:   'tplt_bdevices_devtype_id',
itemId:   'tplt_bdevices_devtype_id',
fieldLabel:  '',
emptyText:      'Устройство',
hideLabel:  true
}
,
{

trigger1Cls:        'x-form-clear-trigger', 
trigger2Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
hideTrigger2:false, 
onTrigger1Click : function(){
		this.collapse();
		this.clearValue();
},
onTrigger2Click : function(){ 
		if(this.isExpanded) {
			this.collapse(); 
		}else{ 
			if(this.store.count(false)==0) this.store.load();
			this.expand();
		}
},
editable: true,
enableRegEx: true,
queryMode:'local',
listeners:{  focus: function()   { if(this.store.count(false)==0) this.store.load();  } ,render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Снабжающая орг.'});} },
xtype:  'combobox',
store: cmbstore_tpld_snab,
valueField:     'id',
displayField:   'brief',
typeAhead: true,
name:   'tplt_bdevices_shab_id',
itemId:   'tplt_bdevices_shab_id',
fieldLabel:  '',
emptyText:      'Снабжающая орг.',
hideLabel:  true
}
,
{

trigger1Cls:        'x-form-clear-trigger', 
trigger2Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
hideTrigger2:false, 
onTrigger1Click : function(){
		this.collapse();
		this.clearValue();
},
onTrigger2Click : function(){ 
		if(this.isExpanded) {
			this.collapse(); 
		}else{ 
			if(this.store.count(false)==0) this.store.load();
			this.expand();
		}
},
editable: true,
enableRegEx: true,
queryMode:'local',
listeners:{  focus: function()   { if(this.store.count(false)==0) this.store.load();  } ,render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Группа'});} },
xtype:  'combobox',
store: cmbstore_tpld_grp,
valueField:     'id',
displayField:   'brief',
typeAhead: true,
name:   'tplt_bdevices_devgrp_id',
itemId:   'tplt_bdevices_devgrp_id',
fieldLabel:  '',
emptyText:      'Группа',
hideLabel:  true
}
,
{

trigger1Cls:        'x-form-clear-trigger', 
trigger2Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
hideTrigger2:false, 
onTrigger1Click : function(){
		this.collapse();
		this.clearValue();
},
onTrigger2Click : function(){ 
		if(this.isExpanded) {
			this.collapse(); 
		}else{ 
			if(this.store.count(false)==0) this.store.load();
			this.expand();
		}
},
editable: true,
enableRegEx: true,
queryMode:'local',
listeners:{  focus: function()   { if(this.store.count(false)==0) this.store.load();  } ,render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Схема подключения'});} },
xtype:  'combobox',
store: cmbstore_tpls_info,
valueField:     'id',
displayField:   'brief',
typeAhead: true,
name:   'tplt_bdevices_theschema_id',
itemId:   'tplt_bdevices_theschema_id',
fieldLabel:  '',
emptyText:      'Схема подключения',
hideLabel:  true
}
,
{

trigger1Cls:        'x-form-clear-trigger', 
trigger2Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
hideTrigger2:false, 
onTrigger1Click : function(){
		this.collapse();
		this.clearValue();
},
onTrigger2Click : function(){ 
		if(this.isExpanded) {
			this.collapse(); 
		}else{ 
			if(this.store.count(false)==0) this.store.load();
			this.expand();
		}
},
editable: true,
enableRegEx: true,
queryMode:'local',
listeners:{  focus: function()   { if(this.store.count(false)==0) this.store.load();  } ,render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Сервер'});} },
xtype:  'combobox',
store: cmbstore_tpsrv_info,
valueField:     'id',
displayField:   'brief',
typeAhead: true,
name:   'tplt_bdevices_theserver_id',
itemId:   'tplt_bdevices_theserver_id',
fieldLabel:  '',
emptyText:      'Сервер',
hideLabel:  true
}
,
{

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:  'tplt_bdevices_nplock_ge',
itemId: 'tplt_bdevices_nplock_ge',
fieldLabel: 'Заблокированно до C',
emptyText:'не задано',
submitEmptyText: false,
listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Заблокированно до C'});}}
}
,
{

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:  'tplt_bdevices_nplock_le',
itemId: 'tplt_bdevices_nplock_le',
fieldLabel: 'Заблокированно до по',
emptyText:'не задано',
submitEmptyText: false,
listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Заблокированно до по'});}}
}
,
{

xtype:          'combobox',
editable: false,
trigger1Cls:        'x-form-clear-trigger', 
trigger2Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
hideTrigger2:false, 
onTrigger1Click : function(){
		this.collapse();
		this.clearValue();
},
onTrigger2Click : function(){ 
		if(this.isExpanded) {
			this.collapse(); 
		}else{ 
			this.expand();
		}
},
store: enum_Boolean,
valueField:     'value',
displayField:   'name',
typeAhead: true,
queryMode:      'local',
emptyText:      '',
name:   'tplt_bdevices_connected_val',
itemId:   'tplt_bdevices_connected_val',
fieldLabel:  '',
emptyText:      'Подключен',
hideLabel:  true,
listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Подключен'});}}
}
					],
                    buttons: 
                    [
                        {
                            text: 'Найти',
							iconCls:'icon-find',
                            formBind: true, 
                            disabled: false,
                            grid: this,
                            handler: function() {
                                var user_input =this.up('form').getForm().getValues(false,true);
                                var filters = new Array();
								if(this.grid.default_filter != null){
									for (var i=0; i< this.grid.default_filter.length;i++) {
										var kv=this.grid.default_filter[i];
										filters.push({property: kv.key, value: kv.value});
									}
								}
                                for (var key in user_input) {
                                    filters.push({property: key, value: user_input[key]});
                                }
                                if (this.grid.store.filters.length>0) 
                                    this.grid.store.filters.clear();
                                if (filters.length>0) 
                                    this.grid.store.filter(filters); 
                                else 
								   this.grid.store.load();
                            }
                        }, {
							text: 'Сбросить',
							iconCls:'icon-cancel',
                            grid: this,
                            handler: function() {
                                this.up('form').getForm().reset();
								var filters = new Array();
                                if(this.grid.default_filter!=null){
									for (var i=0; i< this.grid.default_filter.length;i++) {
										var kv=this.grid.default_filter[i];
										filters.push({property: kv.key, value: kv.value});
									}
								}
                                if (this.grid.store.filters.length>0) 
                                    this.grid.store.filters.clear();
                                if (filters.length>0) 
                                    this.grid.store.filter(filters); 
                                else 
								   this.grid.store.load();
                            }
                        }
                    ]
                }
            ]//rbar
        }
        );
        this.callParent();
        this.getSelectionModel().on('selectionchange', this.onSelectChange, this);
        this.store.load()
       },
        onSelectChange: function(selModel, selections){
        this.down('#delete').setDisabled(selections.length === 0);
        this.down('#edit').setDisabled(selections.length === 0);
    },
    listeners: {
        itemdblclick: function() { 
    	    this.onEditClick();
        }
        ,
        	added:function(){
        			//interval_autotplt_bdevices= setInterval(function() {  
        			//	store_v_autotplt_bdevices.load();
        			//}, 60000);
        		}
        	,
        	destroy:function(){
        		//clearInterval(interval_autotplt_bdevices);
        }
    },
    onDeleteConfirm:function(selection){
      if (selection) {
        Ext.Ajax.request({
            url:    rootURL+'index.php/c_v_autotplt_bdevices/deleteRow',
            method:  'POST',
    		params: { 
    				instanceid: selection.get('instanceid')
    				}
    	});
    	this.store.remove(selection);
      }
    },
    onDeleteClick: function(){
      var selection = this.getView().getSelectionModel().getSelection()[0];
      if (selection) {
   	    if(CheckOperation('TPLT.edit')!=0 && OTAllowDelete('TPLT')){
        Ext.Msg.show({
            title:  'Удалить?',
            msg:    'Удалить строку из базы данных?',
        	buttons: Ext.Msg.YESNO,
        	icon:   Ext.MessageBox.QUESTION,
        	fn: function(btn,text,opt){
        		if(btn=='yes'){
        			opt.caller.onDeleteConfirm(opt.selectedRow);
        	    }
        	},
            caller: this,
            selectedRow: selection
        });
        }else{
        		Ext.MessageBox.show({
                title:  'Контроль прав.',
                msg:    'Удаление объектов не разрешено!',
                buttons: Ext.MessageBox.OK,
               icon:   Ext.MessageBox.WARNING
        		});
        }
      }
    },
    onAddClick: function(){
   	    if(CheckOperation('TPLT.edit')!=0 && OTAllowAdd('TPLT')){
            Ext.Ajax.request({
                url: rootURL+'index.php/c_v_autotplt_bdevices/newRow',
                method:  'POST',
                params: { 
                },
                success: function(response){
                var text = response.responseText;
                var res =Ext.decode(text);
                var edit = Ext.create('iu.windowObjects');
                edit.prefix='c_v_autotplt_bdevices';
                edit.setTitle('Создание документа:Устройство') ;
                var p=eval('TPLT_Panel_'+OTAddMode('TPLT')+'( res.data, false,null )') ;
                edit.add(p);
                edit.show();
                }
            });
            this.store.load();
        }else{
        		Ext.MessageBox.show({
                title:  'Контроль прав.',
                msg:    'Создание объектов не разрешено!',
                buttons: Ext.MessageBox.OK,
               icon:   Ext.MessageBox.WARNING
        		});
        }
    },
    onEditClick: function(){
        var selection = this.getView().getSelectionModel().getSelection()[0];
        if (selection) {
   	    if(CheckOperation('TPLT.edit')!=0 ){
                var edit = Ext.create('iu.windowObjects');
                edit.prefix='c_v_autotplt_bdevices';
                edit.setTitle('Редактирование документа: Устройство') ;
            var p=eval('TPLT_Panel_'+OTEditMode('TPLT')+'( selection.get(\'instanceid\'), false, selection )') ;
            edit.add(p);
            edit.show();
        }else{
        		Ext.MessageBox.show({
                title:  'Контроль прав.',
                msg:    'Изменение объектов не разрешено!',
                buttons: Ext.MessageBox.OK,
               icon:   Ext.MessageBox.WARNING
        		});
        }
        }
    },
    onRefreshClick: function(){
             this.store.load();
    }
    ,
     onExportClick: function(){ 
         	var config= {title:this.title, columns:this.columns };
    	var workbook = new Workbook(config);
    workbook.addWorksheet(this.store, config );
    var x= workbook.render();
    window.open( 'data:application/vnd.ms-excel;base64,' + Base64.encode(x),'_blank');
     }
    }
    );
Ext.require([
'Ext.form.*'
]);
function TPLT_Jrnl(){ 

  var TPLT= Ext.create('Ext.form.Panel', {
       closable: true,
       id:     'tplt_jrnl',
       title: 'Устройство',
      layout: 'fit',
      flex: 1,
      fieldDefaults: {
         labelAlign:             'top',
          msgTarget:             'side'
        },
        defaults: {
        anchor:'100%'
        },

        items: [{
            itemId:'gr_autotplt_bdevices',
            xtype:'g_v_autotplt_bdevices',
            stateful: stateFulSystem,
            stateId:'j_v_autotplt_bdevices',
            layout: 'fit',
            flex: 1,
            store: store_v_autotplt_bdevices
    }] // tabpanel
    }); //Ext.Create
    return TPLT;
}
Ext.define('ObjectWindow_tplt', {
    extend:  'Ext.window.Window',
    maxHeight: 620,
    minHeight: 620,
    minWidth: 800,
    maxWidth: 1024,
    constrainHeader :true,
    layout:  'fit',
    autoShow: true,
    closeAction: 'destroy',
    modal: true,
    iconCls:  'icon-application_form',
    title:  'Устройство',
    items:[ ]
	});