
Ext.require([
'Ext.form.*'
]);

function DefineInterface_tplc_e_admin(id,mystore){

var groupingFeature_tplc_e = Ext.create('Ext.grid.feature.Grouping',{
groupByText:  'Группировать по этому полю',
showGroupsText:  'Показать группировку'
});
var filterFeature_tplc_e = {
menuFilterText:  'Фильтр',
ftype: 'filters',
local: true 
};
 var p1;
    function onDeleteConfirm(selection){
      if (selection) {
        Ext.Ajax.request({
            url:    rootURL+'index.php/c_tplc_e/deleteRow',
            method:  'POST',
    		params: { 
    				tplc_eid: selection.get('tplc_eid')
    				}
    	});
    	p1.store.remove(selection);
      }
    };
    function onDeleteClick(){
      var selection = p1.getView().getSelectionModel().getSelection()[0];
      if (selection) {
   	  if(CheckOperation('TPLC.edit')!=0){
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
   	if(CheckOperation('TPLC.edit')!=0){
                var edit = Ext.create('EditWindow_tplc_eadmin');
                p1.store.insert(0, new model_tplc_e());
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
   	    if(CheckOperation('TPLC.edit')!=0){
            var edit = Ext.create('EditWindow_tplc_eadmin');
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
       stateId:  'tplc_eadmin',
        iconCls:  'icon-grid',
        frame: true,
        instanceid: '',
        features: [groupingFeature_tplc_e,filterFeature_tplc_e],
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
{text: "Дата опроса", width:110, dataIndex: 'dcall', sortable: true, xtype: 'datecolumn',    renderer:myDateRenderer}
            ,
{text: "Дата счетчика", width:110, dataIndex: 'dcounter', sortable: true, xtype: 'datecolumn',    renderer:myDateRenderer}
            ,
{text: "Энергия общ.", width:60, dataIndex: 'e0', sortable: true}
            ,
{text: "Энергия тариф 1", width:60, dataIndex: 'e1', sortable: true}
            ,
{text: "Энергия тариф 2", width:60, dataIndex: 'e2', sortable: true}
            ,
{text: "Энергия тариф 3", width:60, dataIndex: 'e3', sortable: true}
            ,
{text: "Энергия тариф 4", width:60, dataIndex: 'e4', sortable: true}
            ,
{text: "Энергия общ. НИ", width:60, dataIndex: 'e0s', sortable: true}
            ,
{text: "Энергия тариф 1 НИ", width:60, dataIndex: 'e1s', sortable: true}
            ,
{text: "Энергия тариф 2 НИ", width:60, dataIndex: 'e2s', sortable: true}
            ,
{text: "Энергия тариф 3 НИ", width:60, dataIndex: 'e3s', sortable: true}
            ,
{text: "Энергия тариф 4 НИ", width:60, dataIndex: 'e4s', sortable: true}
            ,
{text: "Активная +", width:60, dataIndex: 'ap', sortable: true}
            ,
{text: "Активная - ", width:60, dataIndex: 'am', sortable: true}
            ,
{text: "Реактивная +", width:60, dataIndex: 'rp', sortable: true}
            ,
{text: "Реактивная -", width:60, dataIndex: 'rm', sortable: true}
            ,
{text: "Ток Ф1", width:60, dataIndex: 'i1', sortable: true}
            ,
{text: "Ток Ф2", width:60, dataIndex: 'i2', sortable: true}
            ,
{text: "Ток Ф3", width:60, dataIndex: 'i3', sortable: true}
            ,
{text: "Напряжение Ф1", width:60, dataIndex: 'u1', sortable: true}
            ,
{text: "Напряжение Ф2", width:60, dataIndex: 'u2', sortable: true}
            ,
{text: "Напряжение Ф3", width:60, dataIndex: 'u3', sortable: true}
            ,
{text: "Время безошиб.работы", width:60, dataIndex: 'oktime', sortable: true}
            ,
{text: "Время работы", width:60, dataIndex: 'worktime', sortable: true}
            ,
{text: "Ошибки", width: 200, dataIndex: 'errinfo', sortable: true}
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
function DefineForms_tplc_e_admin(){


Ext.define('Form_tplc_eadmin', {
extend:  'Ext.form.Panel',
alias: 'widget.f_tplc_eadmin',
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
        id:'tplc_e-0',
        layout:'absolute', 
        border:false, 
        items: [
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 0, 

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:   'dcall',
itemId:   'dcall',
fieldLabel:  'Дата опроса',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 46, 

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:   'dcounter',
itemId:   'dcounter',
fieldLabel:  'Дата счетчика',
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

xtype:  'numberfield',
value:  '0',
name:   'e0',
itemId:   'e0',
fieldLabel:  'Энергия общ.',
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

xtype:  'numberfield',
value:  '0',
name:   'e1',
itemId:   'e1',
fieldLabel:  'Энергия тариф 1',
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

xtype:  'numberfield',
value:  '0',
name:   'e2',
itemId:   'e2',
fieldLabel:  'Энергия тариф 2',
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

xtype:  'numberfield',
value:  '0',
name:   'e3',
itemId:   'e3',
fieldLabel:  'Энергия тариф 3',
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

xtype:  'numberfield',
value:  '0',
name:   'e4',
itemId:   'e4',
fieldLabel:  'Энергия тариф 4',
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

xtype:  'numberfield',
value:  '0',
name:   'e0s',
itemId:   'e0s',
fieldLabel:  'Энергия общ. НИ',
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

xtype:  'numberfield',
value:  '0',
name:   'e1s',
itemId:   'e1s',
fieldLabel:  'Энергия тариф 1 НИ',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 414, 

xtype:  'numberfield',
value:  '0',
name:   'e2s',
itemId:   'e2s',
fieldLabel:  'Энергия тариф 2 НИ',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 460, 

xtype:  'numberfield',
value:  '0',
name:   'e3s',
itemId:   'e3s',
fieldLabel:  'Энергия тариф 3 НИ',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 506, 

xtype:  'numberfield',
value:  '0',
name:   'e4s',
itemId:   'e4s',
fieldLabel:  'Энергия тариф 4 НИ',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 552, 

xtype:  'numberfield',
value:  '0',
name:   'ap',
itemId:   'ap',
fieldLabel:  'Активная +',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 598, 

xtype:  'numberfield',
value:  '0',
name:   'am',
itemId:   'am',
fieldLabel:  'Активная - ',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 644, 

xtype:  'numberfield',
value:  '0',
name:   'rp',
itemId:   'rp',
fieldLabel:  'Реактивная +',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 690, 

xtype:  'numberfield',
value:  '0',
name:   'rm',
itemId:   'rm',
fieldLabel:  'Реактивная -',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 736, 

xtype:  'numberfield',
value:  '0',
name:   'i1',
itemId:   'i1',
fieldLabel:  'Ток Ф1',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 782, 

xtype:  'numberfield',
value:  '0',
name:   'i2',
itemId:   'i2',
fieldLabel:  'Ток Ф2',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 828, 

xtype:  'numberfield',
value:  '0',
name:   'i3',
itemId:   'i3',
fieldLabel:  'Ток Ф3',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 874, 

xtype:  'numberfield',
value:  '0',
name:   'u1',
itemId:   'u1',
fieldLabel:  'Напряжение Ф1',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 920, 

xtype:  'numberfield',
value:  '0',
name:   'u2',
itemId:   'u2',
fieldLabel:  'Напряжение Ф2',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 966, 

xtype:  'numberfield',
value:  '0',
name:   'u3',
itemId:   'u3',
fieldLabel:  'Напряжение Ф3',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 1012, 

xtype:  'numberfield',
value:  '0',
name:   'oktime',
itemId:   'oktime',
fieldLabel:  'Время безошиб.работы',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 1058, 

xtype:  'numberfield',
value:  '0',
name:   'worktime',
itemId:   'worktime',
fieldLabel:  'Время работы',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 1104, 

xtype:  'textfield',
value:  '',
name:   'errinfo',
itemId:   'errinfo',
fieldLabel:  'Ошибки',
allowBlank:true
       ,labelWidth: 120
}
       ], width: 770,
       height: 1180 
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
                url: rootURL+'index.php/c_tplc_e/setRow',
                method:  'POST',
                params: { 
                    instanceid: this.instanceid
                    ,tplc_eid: active.get('tplc_eid')
                    ,dcall:function() { if(active.get('dcall')) return active.get('dcall').toLocaleFormat('%Y-%m-%d %H:%M:%S'); else return null;}()
                    ,dcounter:function() { if(active.get('dcounter')) return active.get('dcounter').toLocaleFormat('%Y-%m-%d %H:%M:%S'); else return null;}()
                    ,e0: active.get('e0') 
                    ,e1: active.get('e1') 
                    ,e2: active.get('e2') 
                    ,e3: active.get('e3') 
                    ,e4: active.get('e4') 
                    ,e0s: active.get('e0s') 
                    ,e1s: active.get('e1s') 
                    ,e2s: active.get('e2s') 
                    ,e3s: active.get('e3s') 
                    ,e4s: active.get('e4s') 
                    ,ap: active.get('ap') 
                    ,am: active.get('am') 
                    ,rp: active.get('rp') 
                    ,rm: active.get('rm') 
                    ,i1: active.get('i1') 
                    ,i2: active.get('i2') 
                    ,i3: active.get('i3') 
                    ,u1: active.get('u1') 
                    ,u2: active.get('u2') 
                    ,u3: active.get('u3') 
                    ,oktime: active.get('oktime') 
                    ,worktime: active.get('worktime') 
                    ,errinfo: active.get('errinfo') 
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
                    if(active.get('tplc_eid')==''){
               			active.set('tplc_eid',res.data['tplc_eid']);
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
        if(this.activeRecord.get('tplc_eid')==''){
                this.activeRecord.store.reload();
        }
        this.setActiveRecord(null,null);
        this.ownerCt.close();
    }
}); // 'Ext.Define

Ext.define('EditWindow_tplc_eadmin', {
    extend:  'Ext.window.Window',
    maxHeight: 1285,
    maxWidth: 900,
    autoScroll:true,
    minWidth: 750,
    width: 800,
    minHeight:670,
    height:670,
    constrainHeader :true,
    layout:  'absolute',
    autoShow: true,
    modal: true,
    closable: false,
    closeAction: 'destroy',
    iconCls:  'icon-application_form',
    title:  'Электроэнергия',
    items:[{
        xtype:  'f_tplc_eadmin'
	}]
	});
}