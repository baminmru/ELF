
Ext.require([
'Ext.form.*'
]);

function DefineInterface_tpu_device_(id,mystore){

var groupingFeature_tpu_views = Ext.create('Ext.grid.feature.Grouping',{
groupByText:  'Группировать по этому полю',
showGroupsText:  'Показать группировку'
});
var grid_tpu_views;
    function ChildOnDeleteConfirm(selection){
      if (selection) {
        Ext.Ajax.request({
            url:    rootURL+'index.php/c_tpu_views/deleteRow',
            method:  'POST',
    		params: { 
    				tpu_viewsid: selection.get('tpu_viewsid')
    				}
    	});
    	grid_tpu_views.store.remove(selection);
      }
    };
     function ChildOnDeleteClick(){
    if( grid_tpu_views.parentid=='{00000000-0000-0000-0000-000000000000}') {return;}
      var selection = grid_tpu_views.getView().getSelectionModel().getSelection()[0];
      if (selection) {
   	  if(CheckOperation('TPU.edit')!=0){
        Ext.Msg.show({
            title:  'Удалить?',
            msg:    'Удалить строку из базы данных?',
        	buttons: Ext.Msg.YESNO,
            icon:   Ext.window.MessageBox.QUESTION,
        	fn: function(btn,text,opt){
        		if(btn=='yes'){
        			ChildOnDeleteConfirm(opt.selectedRow);
        	    }
        	},
            caller: grid_tpu_views,
            selectedRow: selection
        });
        }else{
        		Ext.MessageBox.show({
                title:  'Контроль прав.',
                msg:    'Удаление строк не разрешено!',
                buttons: Ext.MessageBox.OK,
               icon:   Ext.MessageBox.WARNING
        		});
        }
      }
    };
    function ChildOnAddClick(){
    if( grid_tpu_views.parentid=='{00000000-0000-0000-0000-000000000000}') {return;}
   	if(CheckOperation('TPU.edit')!=0){
                var edit = Ext.create('EditWindow_tpu_views');
                grid_tpu_views.store.insert(0, new model_tpu_views());
                record= grid_tpu_views.store.getAt(0);
                record.set('parentid',grid_tpu_views.parentid);
                edit.getComponent(0).setActiveRecord(record,grid_tpu_views.instanceid,grid_tpu_views.parentid);
                edit.show();
        }else{
        		Ext.MessageBox.show({
                title:  'Контроль прав.',
                msg:    'Создание строк не разрешено!',
                buttons: Ext.MessageBox.OK,
               icon:   Ext.MessageBox.WARNING
        		});
        }
    };
     function ChildOnRefreshClick(){
        if( grid_tpu_views.parentid=='{00000000-0000-0000-0000-000000000000}') {return;}
            grid_tpu_views.store.load({params:{parentid: grid_tpu_views.parentid}});
    };
    function ChildOnEditClick(){
    if( grid_tpu_views.parentid=='{00000000-0000-0000-0000-000000000000}') {return;}
        var selection = grid_tpu_views.getView().getSelectionModel().getSelection()[0];
        if (selection) {
   	     if(CheckOperation('TPU.edit')!=0){
            var edit = Ext.create('EditWindow_tpu_views');
            edit.getComponent(0).setActiveRecord(selection,grid_tpu_views.instanceid,grid_tpu_views.parentid);
            edit.show();
        }else{
        		Ext.MessageBox.show({
                title:  'Контроль прав.',
                msg:    'Изменение строк не разрешено!',
                buttons: Ext.MessageBox.OK,
               icon:   Ext.MessageBox.WARNING
        		});
        }
        }
    };
   grid_tpu_views=
    new Ext.grid.Panel({
        itemId:  'grd_tpu_views',
        minHeight: 200,
        maxHeight: 1200,
        iconCls:  'icon-grid',
        frame: true,
        parentid: '{00000000-0000-0000-0000-000000000000}',
        title: 'Поля шаблона',
        scroll:'both',
        store: {
        model:'model_tpu_views',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpu_views/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            },
            listeners: {
                exception: function(proxy, response, operation){
                }
            }
        }
    },
        features: [groupingFeature_tpu_views],
          dockedItems: [{
                xtype:  'toolbar',
                items: [
                {
                    iconCls:  'icon-application_form_add',
                    text:   'Создать',
                    scope:  this,
                    handler : ChildOnAddClick
                    }, {
                    iconCls:  'icon-application_form_edit',
                    text:   'Изменить',
                    scope:  this,
                    disabled: true,
                    itemId:  'edit',
                    handler : ChildOnEditClick
                    }, {
                    iconCls:  'icon-application_form_delete',
                    text:   'Удалить',
                    disabled: true,
                    itemId:  'delete',
                    scope:  this,
                    handler : ChildOnDeleteClick
                    }, {
                    iconCls:  'icon-table_refresh',
                    text:   'Обновить',
                    itemId:  'bRefresh',
                    scope:  this,
                    handler : ChildOnRefreshClick
                }]
            }],
        columns: [
{text: "Формат отображения", width: 200, dataIndex: 'theformat_grid', sortable: true}
            ,
{text: "Параметр", width: 200, dataIndex: 'param_grid', sortable: true}
            ,
{text: "Номер по порядку", width:60, dataIndex: 'sequence', sortable: true}
            ,
{text: "Ширина", width:60, dataIndex: 'thewidth', sortable: true}
            ,
{text: "Скрыть", width:80, dataIndex: 'hideparam_grid', sortable: true}
        ],
    listeners: {
        itemdblclick: function() { 
    	    ChildOnEditClick();
        },
          itemclick: function(view , record){
         grid_tpu_views.down('#delete').setDisabled(false);
          grid_tpu_views.down('#edit').setDisabled(false);
    },
    select: function( selmodel, record,  index,  eOpts ){
        grid_tpu_views.down('#delete').setDisabled(false);
        grid_tpu_views.down('#edit').setDisabled(false);
    }, 
    selectionchange: function(selModel, selections){
    	 grid_tpu_views.down('#delete').setDisabled(selections.length === 0);
    	 grid_tpu_views.down('#edit').setDisabled(selections.length === 0);
    }
    }
    }
    );
var groupingFeature_tpu_device = Ext.create('Ext.grid.feature.Grouping',{
groupByText:  'Группировать по этому полю',
showGroupsText:  'Показать группировку'
});
var p1;
    function onDeleteConfirm(selection){
      if (selection) {
        Ext.Ajax.request({
            url:    rootURL+'index.php/c_tpu_device/deleteRow',
            method:  'POST',
    		params: { 
    				tpu_deviceid: selection.get('tpu_deviceid')
    				}
    	});
    	p1.store.remove(selection);
      }
    };
    function onDeleteClick(){
      var selection = p1.getView().getSelectionModel().getSelection()[0];
      if (selection) {
   	  if(CheckOperation('TPU.edit')!=0){
        Ext.Msg.show({
            title:  'Удалить?',
            msg:    'Удалить строку из базы данных?',
        	buttons: Ext.Msg.YESNO,
            icon:   Ext.window.MessageBox.QUESTION,
        	fn: function(btn,text,opt){
        		if(btn=='yes'){
        			onDeleteConfirm(opt.selectedRow);
        	    }
        	},
            caller: this,
            selectedRow: selection
        });
        }else{
        		Ext.MessageBox.show({
                title:  'Контроль прав.',
                msg:    'Удаление строк не разрешено!',
                buttons: Ext.MessageBox.OK,
               icon:   Ext.MessageBox.WARNING
        		});
        }
      }
    };
    function onAddClick(){
   	if(CheckOperation('TPU.edit')!=0){
                var edit = Ext.create('EditWindow_tpu_device');
                p1.store.insert(0, new model_tpu_device());
                record= p1.store.getAt(0);
                record.set('instanceid',p1.instanceid);
                edit.getComponent(0).setActiveRecord(record,p1.instanceid);
                edit.show();
        }else{
        		Ext.MessageBox.show({
                title:  'Контроль прав.',
                msg:    'Создание строк не разрешено!',
                buttons: Ext.MessageBox.OK,
               icon:   Ext.MessageBox.WARNING
        		});
        }
    };
    function onRefreshClick(){
            p1.store.load({params:{instanceid: p1.instanceid}});
    };
    function onEditClick(){
        var selection = p1.getView().getSelectionModel().getSelection()[0];
        if (selection) {
   	    if(CheckOperation('TPU.edit')!=0){
            var edit = Ext.create('EditWindow_tpu_device');
            edit.getComponent(0).setActiveRecord(selection,selection.get('instanceid'));
            edit.show();
        }else{
        		Ext.MessageBox.show({
                title:  'Контроль прав.',
                msg:    'Изменение строк не разрешено!',
                buttons: Ext.MessageBox.OK,
               icon:   Ext.MessageBox.WARNING
        		});
        }
        }
    };
 p1=   new Ext.grid.Panel({
        itemId: id,
        store:  mystore,
        frame: true,
        instanceid: '',
        scroll:'both',
        autoScroll:true,
        width:600,
        features: [groupingFeature_tpu_device],
          dockedItems: [{
                xtype:  'toolbar',
                items: [
                {
                    iconCls:  'icon-application_form_add',
                    text:   'Создать',
                    scope:  this,
                    handler : onAddClick
                    }, {
                    iconCls:  'icon-application_form_edit',
                    text:   'Изменить',
                    scope:  this,
                    disabled: true,
                    itemId:  'edit',
                    handler : onEditClick
                    }, {
                    iconCls:  'icon-application_form_delete',
                    text:   'Удалить',
                    disabled: true,
                    itemId:  'delete',
                    scope:  this,
                    handler : onDeleteClick
                    }, {
                    iconCls:  'icon-table_refresh',
                    text:   'Обновить',
                    itemId:  'bRefresh',
                    scope:  this,
                    handler : onRefreshClick
                }]
            }],
        columns: [
{text: "Тепловычислитель", width:200, dataIndex: 'thedevice_grid', sortable: true}
            ,
{text: "Тип архива", width:200, dataIndex: 'archtype_grid', sortable: true}
            ,
{text: "Название шаблона", width: 200, dataIndex: 'templatename', sortable: true }
            ,
{text: "Лист отчета", width: 200, dataIndex: 'sheetname', sortable: true }
        ]
,
	bbar:grid_tpu_views, 
    listeners: {
        resize: function ( tree, width, height, oldWidth, oldHeight, eOpts ){
        		grid_tpu_views.setHeight( height * 0.5 );
        },
        render : function(grid){
                grid.store.on('load', function(store, records, options){
                        if(store.count() > 0) grid.getSelectionModel().select(0);      
                }); 
         },
        itemdblclick: function() { 
    	    onEditClick();
        }
        ,itemclick: function(view,record) { 
           p1.down('#delete').setDisabled(false);
           p1.down('#edit').setDisabled(false);
           grid_tpu_views.instanceid=p1.instanceid;
           grid_tpu_views.parentid=record.get('tpu_deviceid');
           grid_tpu_views.store.load({params:{ parentid:record.get('tpu_deviceid')} })
        },
        selectionchange: function(selModel, selections){
        p1.down('#delete').setDisabled(selections.length === 0);
        p1.down('#edit').setDisabled(selections.length === 0);
        var selection = selections[0];
        if (selection) {
           p1.down('#grd_tpu_views').instanceid=p1.instanceid;
           p1.down('#grd_tpu_views').parentid=selection.get('tpu_deviceid');
           p1.down('#grd_tpu_views').store.load({params:{ parentid:selection.get('tpu_deviceid')} })
        }
       }
    }
    }
    );
return p1;
};
function DefineForms_tpu_device_(){


Ext.define('Form_tpu_device', {
extend:  'Ext.form.Panel',
alias: 'widget.f_tpu_device',
initComponent: function(){
    this.addEvents('create');
    Ext.apply(this,{
        activeRecord: null,
        defaultType:  'textfield',
        x: 0, 
        fieldDefaults: {
         labelAlign:  'top' //,
        },
        items: [
        { 
        xtype:'panel', 
        closable:false,
        title:'',
        preventHeader:true,
        id:'tpu_device-0',
        layout:'absolute', 
        border:false, 
        items: [
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 0, 

xtype:  'combobox',
trigger1Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
onTrigger1Click : function(){ 
		if(this.isExpanded) {
			this.collapse(); 
		}else{ 
			if(this.store.count(false)==0) this.store.load();
			this.expand();
		}
},
editable: false,
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('thedevice', records[0].get('id'));}  },
store: cmbstore_tplt_bdevices,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'thedevice_grid',
itemId:   'thedevice_grid',
fieldLabel:  'Тепловычислитель',
labelClsExtra:'x-item-mandatory',
allowBlank:false
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 46, 

xtype:  'combobox',
trigger1Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
onTrigger1Click : function(){ 
		if(this.isExpanded) {
			this.collapse(); 
		}else{ 
			if(this.store.count(false)==0) this.store.load();
			this.expand();
		}
},
editable: false,
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('archtype', records[0].get('id'));}  },
store: cmbstore_tpld_paramtype,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'archtype_grid',
itemId:   'archtype_grid',
fieldLabel:  'Тип архива',
labelClsExtra:'x-item-mandatory',
allowBlank:false
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 92, 

xtype:  'textfield',
value:  '',
name:   'templatename',
itemId:   'templatename',
fieldLabel:  'Название шаблона',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 138, 

xtype:  'textfield',
value:  '',
name:   'sheetname',
itemId:   'sheetname',
fieldLabel:  'Лист отчета',
allowBlank:true
       ,labelWidth: 120
}
       ], width: 770,
       height: 214 
        }
          ],//items = part panel
        instanceid:'',
        dockedItems: [{
            xtype:  'toolbar',
            dock:   'bottom',
            ui:     'footer',
                items: ['->', {
                    iconCls:  'icon-accept',
                    itemId:  'save',
                    text:   'Сохранить',
                    disabled: true,
                    scope:  this,
                    handler : this.onSave
                }
               , {
                    iconCls:  'icon-cancel',
                    text:   'Закрыть',
                    scope:  this,
                    handler : this.onReset
                }
              ]
            }] // dockedItems
        }); //Ext.apply
        this.callParent();
    }, //initComponent 
    setActiveRecord: function(record,instid){
        this.activeRecord = record;
        this.instanceid = instid;
        if (record) {
            this.down('#save').enable();
            this.getForm().loadRecord(record);
        } else {
            this.down('#save').disable();
            this.getForm().reset();
        }
    },
    onSave: function(){
        var active = this.activeRecord,
            form = this.getForm();
        if (!active) {
            return;
        }
        if (form.isValid()) {
            form.updateRecord(active);
            // combobox patch
            // var form_values = form.getValues(); var field_name = '';  for(field_name in form_values){active.set(field_name, form_values[field_name]);}
        	StatusDB('Сохранение данных');
            Ext.Ajax.request({
                url: rootURL+'index.php/c_tpu_device/setRow',
                method:  'POST',
                params: { 
                    instanceid: this.instanceid
                    ,tpu_deviceid: active.get('tpu_deviceid')
                    ,thedevice: active.get('thedevice') 
                    ,archtype: active.get('archtype') 
                    ,templatename: active.get('templatename') 
                    ,sheetname: active.get('sheetname') 
                }
                , success: function(response){
                var text = response.responseText;
                var res =Ext.decode(text);
	            if(res.success==false){
	       	        Ext.MessageBox.show({
	       		        title:  'Ошибка',
	       		        msg:    res.msg,
	       		        buttons: Ext.MessageBox.OK,
	       		        icon:   Ext.MessageBox.ERROR
	       	            });
        		    StatusErr( 'Ошибка. '+res.msg);
	            }else{
                    if(active.get('tpu_deviceid')==''){
               			active.set('tpu_deviceid',res.data['tpu_deviceid']);
                    }
        		    StatusReady('Изменения сохранены');
                form.owner.ownerCt.close();
                }
              }
            });
        }else{
        		Ext.MessageBox.show({
                title:  'Ошибка',
                msg:    'Не все обязательные поля заполнены!',
                buttons: Ext.MessageBox.OK,
                icon:   Ext.MessageBox.ERROR
        		});
        }
    },
    onReset: function(){
        if(this.activeRecord.get('tpu_deviceid')==''){
                this.activeRecord.store.reload();
        }
        this.setActiveRecord(null,null);
        this.ownerCt.close();
    }
}); // 'Ext.Define

Ext.define('EditWindow_tpu_device', {
    extend:  'Ext.window.Window',
    maxHeight: 319,
    maxWidth: 900,
    autoScroll:true,
    minWidth: 750,
    width: 800,
    minHeight:289,
    height:289,
    constrainHeader :true,
    layout:  'absolute',
    autoShow: true,
    modal: true,
    closable: false,
    closeAction: 'destroy',
    iconCls:  'icon-application_form',
    title:  'Настройки узла',
    items:[{
        xtype:  'f_tpu_device'
	}]
	});

Ext.define('Form_tpu_views', {
extend:  'Ext.form.Panel',
alias: 'widget.f_tpu_views',
initComponent: function(){
    this.addEvents('create');
    Ext.apply(this,{
        activeRecord: null,
        defaultType:  'textfield',
        x: 0, 
        fieldDefaults: {
         labelAlign:  'top' //,
        },
        items: [
        { 
        xtype:'panel', 
        closable:false,
        title:'',
        preventHeader:true,
        id:'tpu_views-0',
        layout:'absolute', 
        border:false, 
        items: [
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 0, 

xtype:  'combobox',
trigger1Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
onTrigger1Click : function(){ 
		if(this.isExpanded) {
			this.collapse(); 
		}else{ 
			if(this.store.count(false)==0) this.store.load();
			this.expand();
		}
},
editable: false,
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('theformat', records[0].get('id'));}  },
store: cmbstore_fieldtype,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'theformat_grid',
itemId:   'theformat_grid',
fieldLabel:  'Формат отображения',
labelClsExtra:'x-item-mandatory',
allowBlank:false
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 46, 

xtype:  'combobox',
trigger1Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
onTrigger1Click : function(){ 
		if(this.isExpanded) {
			this.collapse(); 
		}else{ 
			if(this.store.count(false)==0) this.store.load();
			this.expand();
		}
},
editable: false,
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('param', records[0].get('id'));}  },
store: cmbstore_tpld_param,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'param_grid',
itemId:   'param_grid',
fieldLabel:  'Параметр',
labelClsExtra:'x-item-mandatory',
allowBlank:false
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 92, 

xtype:  'numberfield',
value:  '0',
name:   'sequence',
itemId:   'sequence',
fieldLabel:  'Номер по порядку',
labelClsExtra:'x-item-mandatory',
allowBlank:false
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 138, 

xtype:  'numberfield',
value:  '0',
name:   'thewidth',
itemId:   'thewidth',
fieldLabel:  'Ширина',
labelClsExtra:'x-item-mandatory',
allowBlank:false
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 184, 

xtype:          'combobox',
editable: false,
store: enum_Boolean,
valueField:     'name',
displayField:   'name',
typeAhead: true,
queryMode:      'local',
emptyText:      '',
name:   'hideparam_grid',
itemId:   'hideparam_grid',
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('hideparam', records[0].get('value'));}  },
fieldLabel:  'Скрыть',
labelClsExtra:'x-item-mandatory',
allowBlank:false
       ,labelWidth: 120
}
       ], width: 770,
       height: 260 
        }
          ],//items = part panel
        instanceid:'',
        dockedItems: [{
            xtype:  'toolbar',
            dock:   'bottom',
            ui:     'footer',
                items: ['->', {
                    iconCls:  'icon-accept',
                    itemId:  'save',
                    text:   'Сохранить',
                    disabled: true,
                    scope:  this,
                    handler : this.onSave
                }
               , {
                    iconCls:  'icon-cancel',
                    text:   'Закрыть',
                    scope:  this,
                    handler : this.onReset
                }
              ]
            }] // dockedItems
        }); //Ext.apply
        this.callParent();
    }, //initComponent 
    setActiveRecord: function(record,instid,parentid){
        this.activeRecord = record;
        this.instanceid = instid;
        this.parentid = parentid;
        if (record) {
            this.down('#save').enable();
            this.getForm().loadRecord(record);
        } else {
            this.down('#save').disable();
            this.getForm().reset();
        }
    },
    onSave: function(){
        var active = this.activeRecord,
            form = this.getForm();
        if (!active) {
            return;
        }
        if (form.isValid()) {
            form.updateRecord(active);
            // combobox patch
            // var form_values = form.getValues(); var field_name = '';  for(field_name in form_values){active.set(field_name, form_values[field_name]);}
        	StatusDB('Сохранение данных');
            Ext.Ajax.request({
                url: rootURL+'index.php/c_tpu_views/setRow',
                method:  'POST',
                params: { 
                    instanceid: this.instanceid,
                    parentid: this.parentid
                    ,tpu_viewsid: active.get('tpu_viewsid')
                    ,theformat: active.get('theformat') 
                    ,param: active.get('param') 
                    ,sequence: active.get('sequence') 
                    ,thewidth: active.get('thewidth') 
                    ,hideparam: active.get('hideparam') 
                }
                , success: function(response){
                var text = response.responseText;
                var res =Ext.decode(text);
	            if(res.success==false){
	       	        Ext.MessageBox.show({
	       		        title:  'Ошибка',
	       		        msg:    res.msg,
	       		        buttons: Ext.MessageBox.OK,
	       		        icon:   Ext.MessageBox.ERROR
	       	            });
        		    StatusErr( 'Ошибка. '+res.msg);
	            }else{
                    if(active.get('tpu_viewsid')==''){
               			active.set('tpu_viewsid',res.data['tpu_viewsid']);
                    }
        		    StatusReady('Изменения сохранены');
                form.owner.ownerCt.close();
                }
              }
            });
        }else{
        		Ext.MessageBox.show({
                title:  'Ошибка',
                msg:    'Не все обязательные поля заполнены!',
                buttons: Ext.MessageBox.OK,
                icon:   Ext.MessageBox.ERROR
        		});
        }
    },
    onReset: function(){
        if(this.activeRecord.get('tpu_viewsid')==''){
                this.activeRecord.store.reload();
        }
        this.setActiveRecord(null,null);
        this.ownerCt.close();
    }
}); // 'Ext.Define

Ext.define('EditWindow_tpu_views', {
    extend:  'Ext.window.Window',
    maxHeight: 365,
    maxWidth: 900,
    autoScroll:true,
    minWidth: 750,
    width: 800,
    minHeight:335,
    height:335,
    constrainHeader :true,
    layout:  'absolute',
    autoShow: true,
    modal: true,
    closable: false,
    closeAction: 'destroy',
    iconCls:  'icon-application_form',
    title:  'Поля шаблона',
    items:[{
        xtype:  'f_tpu_views'
	}]
	});
}