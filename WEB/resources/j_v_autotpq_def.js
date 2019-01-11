
var groupingFeature_autotpq_def = Ext.create('Ext.grid.feature.Grouping',{
groupByText:  'Группировать по этому полю',
showGroupsText:  'Показать группировку'
});
var interval_autotpq_def;
Ext.define('grid_autotpq_def', {
    extend:  'Ext.grid.Panel',
    alias: 'widget.g_v_autotpq_def',
    requires: [
        'Ext.grid.*',
        'Ext.form.field.Text',
        'Ext.toolbar.TextItem'
    ],
    initComponent: function(){
        Ext.apply(this, {
        frame: false,
        store: store_v_autotpq_def,
        features: [groupingFeature_autotpq_def],
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
            {text: "Сессия", width:120, dataIndex: 'tpq_def_thesessionid', sortable: true}
            ,
            {text: "Тепловычислитель", width:120, dataIndex: 'tpq_def_thedevice', sortable: true}
            ,
            {text: "Тип архива", width:120, dataIndex: 'tpq_def_archtype', sortable: true}
            ,
            {text: "Время", width:120, dataIndex: 'tpq_def_archtime', sortable: true,renderer:myDateRenderer}
            ,
            {text: "Время  постановки запроса", width:120, dataIndex: 'tpq_def_querytime', sortable: true,renderer:myDateRenderer}
            ,
            {text: "Срочный запрос", width:120, dataIndex: 'tpq_def_isurgent', sortable: true}
            ,
            {text: "Количество повторений при ошибке", width:120, dataIndex: 'tpq_def_repeattimes', sortable: true}
            ,
            {text: "Интервал между повторами", width:120, dataIndex: 'tpq_def_repeatinterval', sortable: true}
        ]
        ,
        bbar: Ext.create('Ext.PagingToolbar', {
        store: store_v_autotpq_def,
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
listeners:{  focus: function()   { if(this.store.count(false)==0) this.store.load();  } ,render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Сессия'});} },
xtype:  'combobox',
store: cmbstore_the_session,
valueField:     'id',
displayField:   'brief',
typeAhead: true,
name:   'tpq_def_thesessionid_id',
itemId:   'tpq_def_thesessionid_id',
fieldLabel:  '',
emptyText:      'Сессия',
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
listeners:{  focus: function()   { if(this.store.count(false)==0) this.store.load();  } ,render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Тепловычислитель'});} },
xtype:  'combobox',
store: cmbstore_tplt_bdevices,
valueField:     'id',
displayField:   'brief',
typeAhead: true,
name:   'tpq_def_thedevice_id',
itemId:   'tpq_def_thedevice_id',
fieldLabel:  '',
emptyText:      'Тепловычислитель',
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
listeners:{  focus: function()   { if(this.store.count(false)==0) this.store.load();  } ,render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Тип архива'});} },
xtype:  'combobox',
store: cmbstore_tpld_paramtype,
valueField:     'id',
displayField:   'brief',
typeAhead: true,
name:   'tpq_def_archtype_id',
itemId:   'tpq_def_archtype_id',
fieldLabel:  '',
emptyText:      'Тип архива',
hideLabel:  true
}
,
{

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:  'tpq_def_archtime_ge',
itemId: 'tpq_def_archtime_ge',
fieldLabel: 'Время C',
emptyText:'не задано',
submitEmptyText: false,
listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Время C'});}}
}
,
{

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:  'tpq_def_archtime_le',
itemId: 'tpq_def_archtime_le',
fieldLabel: 'Время по',
emptyText:'не задано',
submitEmptyText: false,
listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Время по'});}}
}
,
{

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:  'tpq_def_querytime_ge',
itemId: 'tpq_def_querytime_ge',
fieldLabel: 'Время  постановки запроса C',
emptyText:'не задано',
submitEmptyText: false,
listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Время  постановки запроса C'});}}
}
,
{

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:  'tpq_def_querytime_le',
itemId: 'tpq_def_querytime_le',
fieldLabel: 'Время  постановки запроса по',
emptyText:'не задано',
submitEmptyText: false,
listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Время  постановки запроса по'});}}
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
name:   'tpq_def_isurgent_val',
itemId:   'tpq_def_isurgent_val',
fieldLabel:  '',
emptyText:      'Срочный запрос',
hideLabel:  true,
listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Срочный запрос'});}}
}
,
{

xtype:  'numberfield',
value:  '0',
name:   'tpq_def_repeattimes_ge',
itemId:   'tpq_def_repeattimes_ge',
fieldLabel:  'Количество повторений при ошибке >=',
emptyText:      'не задано',
submitEmptyText: false,
listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Количество повторений при ошибке >='});}}
}
,
{

xtype:  'numberfield',
value:  '0',
name:   'tpq_def_repeattimes_le',
itemId:   'tpq_def_repeattimes_le',
fieldLabel:  'Количество повторений при ошибке <=',
emptyText:      'не задано',
submitEmptyText: false,
listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Количество повторений при ошибке <='});}}
}
,
{

xtype:  'numberfield',
value:  '0',
name:   'tpq_def_repeatinterval_ge',
itemId:   'tpq_def_repeatinterval_ge',
fieldLabel:  'Интервал между повторами >=',
emptyText:      'не задано',
submitEmptyText: false,
listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Интервал между повторами >='});}}
}
,
{

xtype:  'numberfield',
value:  '0',
name:   'tpq_def_repeatinterval_le',
itemId:   'tpq_def_repeatinterval_le',
fieldLabel:  'Интервал между повторами <=',
emptyText:      'не задано',
submitEmptyText: false,
listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Интервал между повторами <='});}}
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
        			//interval_autotpq_def= setInterval(function() {  
        			//	store_v_autotpq_def.load();
        			//}, 60000);
        		}
        	,
        	destroy:function(){
        		//clearInterval(interval_autotpq_def);
        }
    },
    onDeleteConfirm:function(selection){
      if (selection) {
        Ext.Ajax.request({
            url:    rootURL+'index.php/c_v_autotpq_def/deleteRow',
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
   	    if(CheckOperation('TPQ.edit')!=0 && OTAllowDelete('TPQ')){
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
   	    if(CheckOperation('TPQ.edit')!=0 && OTAllowAdd('TPQ')){
            Ext.Ajax.request({
                url: rootURL+'index.php/c_v_autotpq_def/newRow',
                method:  'POST',
                params: { 
                },
                success: function(response){
                var text = response.responseText;
                var res =Ext.decode(text);
                var edit = Ext.create('iu.windowObjects');
                edit.prefix='c_v_autotpq_def';
                edit.setTitle('Создание документа:Запрос на обработку') ;
                var p=eval('TPQ_Panel_'+OTAddMode('TPQ')+'( res.data, false,null )') ;
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
   	    if(CheckOperation('TPQ.edit')!=0 ){
                var edit = Ext.create('iu.windowObjects');
                edit.prefix='c_v_autotpq_def';
                edit.setTitle('Редактирование документа: Запрос на обработку') ;
            var p=eval('TPQ_Panel_'+OTEditMode('TPQ')+'( selection.get(\'instanceid\'), false, selection )') ;
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
function TPQ_Jrnl(){ 

  var TPQ= Ext.create('Ext.form.Panel', {
       closable: true,
       id:     'tpq_jrnl',
       title: 'Запрос на обработку',
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
            itemId:'gr_autotpq_def',
            xtype:'g_v_autotpq_def',
            stateful: stateFulSystem,
            stateId:'j_v_autotpq_def',
            layout: 'fit',
            flex: 1,
            store: store_v_autotpq_def
    }] // tabpanel
    }); //Ext.Create
    return TPQ;
}
Ext.define('ObjectWindow_tpq', {
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
    title:  'Запрос на обработку',
    items:[ ]
	});