
var groupingFeature_autoiu_u_def = Ext.create('Ext.grid.feature.Grouping',{
groupByText:  'Группировать по этому полю',
showGroupsText:  'Показать группировку'
});
var interval_autoiu_u_def;
Ext.define('grid_autoiu_u_def', {
    extend:  'Ext.grid.Panel',
    alias: 'widget.g_v_autoiu_u_def',
    requires: [
        'Ext.grid.*',
        'Ext.form.field.Text',
        'Ext.toolbar.TextItem'
    ],
    initComponent: function(){
        Ext.apply(this, {
        frame: false,
        store: store_v_autoiu_u_def,
        features: [groupingFeature_autoiu_u_def],
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
            {text: "Клиент", width:120, dataIndex: 'iu_u_def_theclient', sortable: true}
            ,
            {text: "Фамилия", width:120, dataIndex: 'iu_u_def_lastname', sortable: true}
            ,
            {text: "Имя", width:120, dataIndex: 'iu_u_def_name', sortable: true}
            ,
            {text: "Отчество", width:120, dataIndex: 'iu_u_def_surname', sortable: true}
            ,
            {text: "Роль в производстве", width:120, dataIndex: 'iu_u_def_currole', sortable: true}
            ,
            {text: "Оповещать по почте", width:120, dataIndex: 'iu_u_def_sendtomail', sortable: true}
            ,
            {text: "Удаленная работа", width:120, dataIndex: 'iu_u_def_freelancer', sortable: true}
            ,
            {text: "e-mail", width:120, dataIndex: 'iu_u_def_email', sortable: true}
            ,
            {text: "Телефон", width:120, dataIndex: 'iu_u_def_thephone', sortable: true}
            ,
            {text: "Имя для входа", width:120, dataIndex: 'iu_u_def_login', sortable: true}
        ]
        ,
        bbar: Ext.create('Ext.PagingToolbar', {
        store: store_v_autoiu_u_def,
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
listeners:{  focus: function()   { if(this.store.count(false)==0) this.store.load();  } ,render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Клиент'});} },
xtype:  'combobox',
store: cmbstore_bpc_info,
valueField:     'id',
displayField:   'brief',
typeAhead: true,
name:   'iu_u_def_theclient_id',
itemId:   'iu_u_def_theclient_id',
fieldLabel:  '',
emptyText:      'Клиент',
hideLabel:  true
}
,
{

value:  '',
name:   'iu_u_def_lastname',
itemId:   'iu_u_def_lastname',
fieldLabel:  '',
emptyText:      'Фамилия',
hideLabel:  true,
listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Фамилия'});}}
}
,
{

value:  '',
name:   'iu_u_def_name',
itemId:   'iu_u_def_name',
fieldLabel:  '',
emptyText:      'Имя',
hideLabel:  true,
listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Имя'});}}
}
,
{

value:  '',
name:   'iu_u_def_surname',
itemId:   'iu_u_def_surname',
fieldLabel:  '',
emptyText:      'Отчество',
hideLabel:  true,
listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Отчество'});}}
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
listeners:{  focus: function()   { if(this.store.count(false)==0) this.store.load();  } ,render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Роль в производстве'});} },
xtype:  'combobox',
store: cmbstore_iu_crole,
valueField:     'id',
displayField:   'brief',
typeAhead: true,
name:   'iu_u_def_currole_id',
itemId:   'iu_u_def_currole_id',
fieldLabel:  '',
emptyText:      'Роль в производстве',
hideLabel:  true
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
name:   'iu_u_def_sendtomail_val',
itemId:   'iu_u_def_sendtomail_val',
fieldLabel:  '',
emptyText:      'Оповещать по почте',
hideLabel:  true,
listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Оповещать по почте'});}}
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
name:   'iu_u_def_freelancer_val',
itemId:   'iu_u_def_freelancer_val',
fieldLabel:  '',
emptyText:      'Удаленная работа',
hideLabel:  true,
listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Удаленная работа'});}}
}
,
{

value:  '',
name:   'iu_u_def_email',
itemId:   'iu_u_def_email',
fieldLabel:  '',
emptyText:      'e-mail',
hideLabel:  true,
listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'e-mail'});}}
}
,
{

value:  '',
name:   'iu_u_def_thephone',
itemId:   'iu_u_def_thephone',
fieldLabel:  '',
emptyText:      'Телефон',
hideLabel:  true,
listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Телефон'});}}
}
,
{

value:  '',
name:   'iu_u_def_login',
itemId:   'iu_u_def_login',
fieldLabel:  '',
emptyText:      'Имя для входа',
hideLabel:  true,
listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Имя для входа'});}}
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
        			//interval_autoiu_u_def= setInterval(function() {  
        			//	store_v_autoiu_u_def.load();
        			//}, 60000);
        		}
        	,
        	destroy:function(){
        		//clearInterval(interval_autoiu_u_def);
        }
    },
    onDeleteConfirm:function(selection){
      if (selection) {
        Ext.Ajax.request({
            url:    rootURL+'index.php/c_v_autoiu_u_def/deleteRow',
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
   	    if(CheckOperation('bpu.edit')!=0 && OTAllowDelete('bpu')){
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
   	    if(CheckOperation('bpu.edit')!=0 && OTAllowAdd('bpu')){
            Ext.Ajax.request({
                url: rootURL+'index.php/c_v_autoiu_u_def/newRow',
                method:  'POST',
                params: { 
                },
                success: function(response){
                var text = response.responseText;
                var res =Ext.decode(text);
                var edit = Ext.create('iu.windowObjects');
                edit.prefix='c_v_autoiu_u_def';
                edit.setTitle('Создание документа:Сотрудник') ;
                var p=eval('bpu_Panel_'+OTAddMode('bpu')+'( res.data, false,null )') ;
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
   	    if(CheckOperation('bpu.edit')!=0 ){
                var edit = Ext.create('iu.windowObjects');
                edit.prefix='c_v_autoiu_u_def';
                edit.setTitle('Редактирование документа: Сотрудник') ;
            var p=eval('bpu_Panel_'+OTEditMode('bpu')+'( selection.get(\'instanceid\'), false, selection )') ;
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
function bpu_Jrnl(){ 

  var bpu= Ext.create('Ext.form.Panel', {
       closable: true,
       id:     'bpu_jrnl',
       title: 'Сотрудник',
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
            itemId:'gr_autoiu_u_def',
            xtype:'g_v_autoiu_u_def',
            stateful: stateFulSystem,
            stateId:'j_v_autoiu_u_def',
            layout: 'fit',
            flex: 1,
            store: store_v_autoiu_u_def
    }] // tabpanel
    }); //Ext.Create
    return bpu;
}
Ext.define('ObjectWindow_bpu', {
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
    iconCls:  'icon-user',
    title:  'Сотрудник',
    items:[ ]
	});