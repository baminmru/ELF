
Ext.require([
'Ext.form.*'
]);

function DefineInterface_tpq_result_(id,mystore){

var groupingFeature_tpq_result = Ext.create('Ext.grid.feature.Grouping',{
groupByText:  'Группировать по этому полю',
showGroupsText:  'Показать группировку'
});
var filterFeature_tpq_result = {
menuFilterText:  'Фильтр',
ftype: 'filters',
local: true 
};
 var p1;
    function onDeleteConfirm(selection){
      if (selection) {
        Ext.Ajax.request({
            url:    rootURL+'index.php/c_tpq_result/deleteRow',
            method:  'POST',
    		params: { 
    				tpq_resultid: selection.get('tpq_resultid')
    				}
    	});
    	p1.store.remove(selection);
      }
    };
    function onDeleteClick(){
      var selection = p1.getView().getSelectionModel().getSelection()[0];
      if (selection) {
   	  if(CheckOperation('TPQ.edit')!=0){
        Ext.Msg.show({
            title:  'Удалить?',
            msg:    'Удалить строку из базы данных?',
        	buttons: Ext.Msg.YESNO,
        	icon:   Ext.MessageBox.QUESTION,
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
   	if(CheckOperation('TPQ.edit')!=0){
                var edit = Ext.create('EditWindow_tpq_result');
                p1.store.insert(0, new model_tpq_result());
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
   	    if(CheckOperation('TPQ.edit')!=0){
            var edit = Ext.create('EditWindow_tpq_result');
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
 p1=   new Ext.grid.Panel(
         {
        itemId:  id,
        store:  mystore,
        width:600,
        header:false,
        layout:'fit',
        scroll:'both',
      stateful:stateFulSystem,
       stateId:  'tpq_result',
        iconCls:  'icon-grid',
        frame: true,
        instanceid: '',
        features: [groupingFeature_tpq_result,filterFeature_tpq_result],
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
{text: "Текстовый результат", width: 200, dataIndex: 'textresult', sortable: true}
            ,
{text: "Запись мгновенного архива", width:200, dataIndex: 'momentarch_grid', sortable: true}
            ,
{text: "Запись часового архива", width:200, dataIndex: 'hourarch_grid', sortable: true}
            ,
{text: "Запись суточного архива", width:200, dataIndex: 'dayarch_grid', sortable: true}
            ,
{text: "Запись итогового архива", width:200, dataIndex: 'totalarch_grid', sortable: true}
            ,
{text: "Обработан с ошибкой", width:80, dataIndex: 'iserror_grid', sortable: true}
            ,
{text: "Протокол", width: 200, dataIndex: 'logmessage', sortable: true}
            ,
{text: "Время начала обработки", width:110, dataIndex: 'starttime', sortable: true, xtype: 'datecolumn',    renderer:myDateRenderer}
            ,
{text: "Время завершения обработки", width:110, dataIndex: 'endtime', sortable: true, xtype: 'datecolumn',    renderer:myDateRenderer}
        ]
       ,
    listeners: {
     render : function(grid){
                grid.store.on('load', function(store, records, options){
                        if(store.count() > 0) grid.getSelectionModel().select(0);      
                }); 
         },
        itemdblclick: function() { 
    	    onEditClick();
        },
          itemclick: function(view , record){
         p1.down('#delete').setDisabled(false);
         p1.down('#edit').setDisabled(false);
    },
    select: function( selmodel, record,  index,  eOpts ){
        p1.down('#delete').setDisabled(false);
        p1.down('#edit').setDisabled(false);
    }, 
    selectionchange: function(selModel, selections){
    	 p1.down('#delete').setDisabled(selections.length === 0);
    	 p1.down('#edit').setDisabled(selections.length === 0);
    }
    }
    }
    );
return p1;
};
function DefineForms_tpq_result_(){


Ext.define('Form_tpq_result', {
extend:  'Ext.form.Panel',
alias: 'widget.f_tpq_result',
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
        id:'tpq_result-0',
        layout:'absolute', 
        border:false, 
        items: [
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 0, 

xtype:  'textfield',
value:  '',
name:   'textresult',
itemId:   'textresult',
fieldLabel:  'Текстовый результат',
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
trigger1Cls:        'x-form-clear-trigger', 
trigger2Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
hideTrigger2:false, 
onTrigger1Click : function(){
		this.collapse();
		this.clearValue();
		this.up('form' ).activeRecord.set('momentarch',null );
},
onTrigger2Click : function(){ 
		if(this.isExpanded) {
			this.collapse(); 
		}else{ 
			if(this.store.count(false)==0) this.store.load();
			this.expand();
		}
},
editable: false,
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('momentarch', records[0].get('id'));}  },
store: cmbstore_tplc_m,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'momentarch_grid',
itemId:   'momentarch_grid',
fieldLabel:  'Запись мгновенного архива',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 92, 

xtype:  'combobox',
trigger1Cls:        'x-form-clear-trigger', 
trigger2Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
hideTrigger2:false, 
onTrigger1Click : function(){
		this.collapse();
		this.clearValue();
		this.up('form' ).activeRecord.set('hourarch',null );
},
onTrigger2Click : function(){ 
		if(this.isExpanded) {
			this.collapse(); 
		}else{ 
			if(this.store.count(false)==0) this.store.load();
			this.expand();
		}
},
editable: false,
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('hourarch', records[0].get('id'));}  },
store: cmbstore_tplc_h,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'hourarch_grid',
itemId:   'hourarch_grid',
fieldLabel:  'Запись часового архива',
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

xtype:  'combobox',
trigger1Cls:        'x-form-clear-trigger', 
trigger2Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
hideTrigger2:false, 
onTrigger1Click : function(){
		this.collapse();
		this.clearValue();
		this.up('form' ).activeRecord.set('dayarch',null );
},
onTrigger2Click : function(){ 
		if(this.isExpanded) {
			this.collapse(); 
		}else{ 
			if(this.store.count(false)==0) this.store.load();
			this.expand();
		}
},
editable: false,
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('dayarch', records[0].get('id'));}  },
store: cmbstore_tplc_d,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'dayarch_grid',
itemId:   'dayarch_grid',
fieldLabel:  'Запись суточного архива',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 184, 

xtype:  'combobox',
trigger1Cls:        'x-form-clear-trigger', 
trigger2Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
hideTrigger2:false, 
onTrigger1Click : function(){
		this.collapse();
		this.clearValue();
		this.up('form' ).activeRecord.set('totalarch',null );
},
onTrigger2Click : function(){ 
		if(this.isExpanded) {
			this.collapse(); 
		}else{ 
			if(this.store.count(false)==0) this.store.load();
			this.expand();
		}
},
editable: false,
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('totalarch', records[0].get('id'));}  },
store: cmbstore_tplc_t,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'totalarch_grid',
itemId:   'totalarch_grid',
fieldLabel:  'Запись итогового архива',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 230, 

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
valueField:     'name',
displayField:   'name',
typeAhead: true,
queryMode:      'local',
emptyText:      '',
name:   'iserror_grid',
itemId:   'iserror_grid',
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('iserror', records[0].get('value'));}  },
fieldLabel:  'Обработан с ошибкой',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 276, 

xtype:  'textarea',
value:  '',
name:   'logmessage',
itemId:   'logmessage',
fieldLabel:  'Протокол',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 322, 

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:   'starttime',
itemId:   'starttime',
fieldLabel:  'Время начала обработки',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 368, 

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:   'endtime',
itemId:   'endtime',
fieldLabel:  'Время завершения обработки',
allowBlank:true
       ,labelWidth: 120
}
       ], width: 770,
       height: 444 
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
                url: rootURL+'index.php/c_tpq_result/setRow',
                method:  'POST',
                params: { 
                    instanceid: this.instanceid
                    ,tpq_resultid: active.get('tpq_resultid')
                    ,textresult: active.get('textresult') 
                    ,momentarch: active.get('momentarch') 
                    ,hourarch: active.get('hourarch') 
                    ,dayarch: active.get('dayarch') 
                    ,totalarch: active.get('totalarch') 
                    ,iserror: active.get('iserror') 
                    ,logmessage: active.get('logmessage') 
                    ,starttime:function() { if(active.get('starttime')) return active.get('starttime').toLocaleFormat('%Y-%m-%d %H:%M:%S'); else return null;}()
                    ,endtime:function() { if(active.get('endtime')) return active.get('endtime').toLocaleFormat('%Y-%m-%d %H:%M:%S'); else return null;}()
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
                    if(active.get('tpq_resultid')==''){
               			active.set('tpq_resultid',res.data['tpq_resultid']);
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
        if(this.activeRecord.get('tpq_resultid')==''){
                this.activeRecord.store.reload();
        }
        this.setActiveRecord(null,null);
        this.ownerCt.close();
    }
}); // 'Ext.Define

Ext.define('EditWindow_tpq_result', {
    extend:  'Ext.window.Window',
    maxHeight: 549,
    maxWidth: 900,
    autoScroll:true,
    minWidth: 750,
    width: 800,
    minHeight:519,
    height:519,
    constrainHeader :true,
    layout:  'absolute',
    autoShow: true,
    modal: true,
    closable: false,
    closeAction: 'destroy',
    iconCls:  'icon-application_form',
    title:  'Результат обработки',
    items:[{
        xtype:  'f_tpq_result'
	}]
	});
}