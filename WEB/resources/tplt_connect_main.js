
Ext.require([
'Ext.form.*'
]);

function DefineInterface_tplt_connect_main(id,mystore){

var p1 ; 
var p1_saved=false;
var p1_valid=false;
     function onSave(close_after_save,callaftersave){
        var active = p1.activeRecord,
        form = p1.getForm();
        if (!active) {
            return;
        }
        if (form.isValid()) {
            form.updateRecord(active);
            // combobox patch
            // var form_values = form.getValues(); var field_name = '';  for(field_name in form_values){active.set(field_name, form_values[field_name]);}
        	StatusDB('Сохранение данных');
            Ext.Ajax.request({
                url: rootURL+'index.php/c_tplt_connect/setRow',
                method:  'POST',
                params: { 
                    instanceid: p1.instanceid
                    ,tplt_connectid: active.get('tplt_connectid')
                    ,connectionenabled: active.get('connectionenabled') 
                    ,connecttype: active.get('connecttype') 
                    ,paramlimit: active.get('paramlimit') 
                    ,connectlimit: active.get('connectlimit') 
                    ,theserver: active.get('theserver') 
                    ,cspeed: active.get('cspeed') 
                    ,cdatabit: active.get('cdatabit') 
                    ,cparity: active.get('cparity') 
                    ,cstopbits: active.get('cstopbits') 
                    ,flowcontrol: active.get('flowcontrol') 
                    ,comportnum: active.get('comportnum') 
                    ,ipaddr: active.get('ipaddr') 
                    ,portnum: active.get('portnum') 
                    ,username: active.get('username') 
                    ,password: active.get('password') 
                    ,ctowncode: active.get('ctowncode') 
                    ,cphone: active.get('cphone') 
                    ,atcommand: active.get('atcommand') 
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
        		        StatusErr('Ошибка. '+res.msg);
                        p1_saved=false;
	            }else{
                    if(active.get('tplt_connectid')==''){
               			active.set('tplt_connectid',res.data['tplt_connectid']);
                    }
        		   /* Ext.MessageBox.show({
                        title:  'Подтверждение',
                        msg:    'Изменения сохранены',
                        buttons: Ext.MessageBox.OK,
                        icon:   Ext.MessageBox.INFO
        		    }); */
        		    StatusReady('Изменения сохранены');
                    p1_saved=true;
                   if(selection){
                     Ext.Ajax.request({
                        url: rootURL+'index.php/c_v_autotplt_connect/getRows?&filter=[{"property":"tplt_connectid","value":"'+ active.get('tplt_connectid') + '"}]',
                        method:     'GET',
                        success: function(response){
                            var data = Ext.decode(response.responseText);
                            selection.set(data.rows[0]);
                            selection.commit();
                        }
                     });
                   }
                    if (close_after_save) { if (typeof(callaftersave) == 'function') callaftersave();  p1.up('window').close(); }
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
    };
     function onSave1(aftersave){onSave(false,aftersave);}
     function onSave2(aftersave){onSave(true,aftersave);}
    function onReset(){
        p1.setActiveRecord(null,null);
    }
p1=new Ext.form.Panel(
{
            itemId: id+'',
            autoScroll:true,
            border:0, bodyPadding: 5,
            activeRecord: null,
            selection: null,
            defaultType:  'textfield',
            doSave: onSave2,
            canClose: function(){
            	if( p1_valid){
            		if(! p1.getForm().isValid()  ) return true;
            		return true ;
            	}else{
            		if(! p1.getForm().isValid()  ) return false;
            		if(p1_saved) return  true;
            		return false;
            	}
            },
        id:'tplt_connect',
        fieldDefaults: {
         labelAlign:  'right',
         labelWidth: 110
        },
        items: [
        { 
        xtype:'fieldset', 
        anchor: '100%',
        x: 0, 
        layout:'absolute', 
        id:'tplt_connect_0',
        title:      'Общие',
        defaultType:  'textfield',
            items: [
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 5, 
labelWidth:140,

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
name:   'connectionenabled_grid',
itemId:   'connectionenabled_grid',
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('connectionenabled', records[0].get('value'));}  },
fieldLabel:  'Подключение разрешено',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 5, 
labelWidth:140,

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
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('connecttype', records[0].get('id'));}  },
store: cmbstore_tpld_connecttype,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'connecttype_grid',
itemId:   'connecttype_grid',
fieldLabel:  'Тип подключения',
labelClsExtra:'x-item-mandatory',
allowBlank:false
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 35, 
labelWidth:140,

xtype:  'numberfield',
value:  '0',
name:   'paramlimit',
itemId:   'paramlimit',
fieldLabel:  'Время опроса параметра',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 35, 
labelWidth:140,

xtype:  'numberfield',
value:  '0',
name:   'connectlimit',
itemId:   'connectlimit',
fieldLabel:  'Время на соединение',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 65, 
labelWidth:140,

xtype:  'combobox',
trigger1Cls:        'x-form-clear-trigger', 
trigger2Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
hideTrigger2:false, 
onTrigger1Click : function(){
		this.collapse();
		this.clearValue();
		this.up('form' ).activeRecord.set('theserver',null );
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
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('theserver', records[0].get('id'));}  },
store: cmbstore_tpsrv_info,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'theserver_grid',
itemId:   'theserver_grid',
fieldLabel:  'Сервер опроса',
allowBlank:true
}
       ], 
       height: 130 
        } // group
,
        { 
        xtype:'fieldset', 
        anchor: '100%',
        x: 0, 
        layout:'absolute', 
        id:'tplt_connect_1',
        title:      'Параметры',
        defaultType:  'textfield',
            items: [
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 5, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'cspeed',
itemId:   'cspeed',
fieldLabel:  'Скорость бод',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 5, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'cdatabit',
itemId:   'cdatabit',
fieldLabel:  'Биты данных',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 35, 
labelWidth:140,

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
store: enum_ParityType,
valueField:     'name',
displayField:   'name',
typeAhead: true,
queryMode:      'local',
emptyText:      '',
name:   'cparity_grid',
itemId:   'cparity_grid',
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('cparity', records[0].get('value'));}  },
fieldLabel:  'Четность',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 35, 
labelWidth:140,

xtype:  'numberfield',
value:  '0',
name:   'cstopbits',
itemId:   'cstopbits',
fieldLabel:  'Стоповые биты',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 65, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'flowcontrol',
itemId:   'flowcontrol',
fieldLabel:  'FlowControl',
allowBlank:true
}
       ], 
       height: 130 
        } // group
,
        { 
        xtype:'fieldset', 
        anchor: '100%',
        x: 0, 
        layout:'absolute', 
        id:'tplt_connect_2',
        title:      'Транспорт',
        defaultType:  'textfield',
            items: [
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 5, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'comportnum',
itemId:   'comportnum',
fieldLabel:  'Com Port',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 5, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'ipaddr',
itemId:   'ipaddr',
fieldLabel:  'IP адрес',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 35, 
labelWidth:140,

xtype:  'numberfield',
value:  '0',
name:   'portnum',
itemId:   'portnum',
fieldLabel:  'TCP Порт',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 35, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'username',
itemId:   'username',
fieldLabel:  'Пользователь',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 65, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'password',
itemId:   'password',
fieldLabel:  'Пароль',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 65, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'ctowncode',
itemId:   'ctowncode',
fieldLabel:  'Код города',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 95, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'cphone',
itemId:   'cphone',
fieldLabel:  'Телефон',
allowBlank:true
}
,
{
        minWidth: 720,
        xtype: 'textarea', 
        x: 5, 
        y: 125, 
        height: 80, 
labelWidth:140,

xtype:  'textarea',
value:  '',
name:   'atcommand',
itemId:   'atcommand',
fieldLabel:  'AT команда',
allowBlank:true
}
       ], 
       height: 250 
        } // group
          ],//items = part panel
        instanceid:''
    ,setActiveRecord: function(record,instid){
        p1.activeRecord = record;
        p1.instanceid = instid;
        if (record) {
            p1.getForm().loadRecord(record);
            p1_valid =p1.getForm().isValid();
        } else {
            p1.getForm().reset();
        }
    }
}); // 'Ext.Define

return p1;
};
function DefineForms_tplt_connect_main(){


Ext.define('Form_tplt_connectmain', {
extend:  'Ext.form.Panel',
alias: 'widget.f_tplt_connectmain',
initComponent: function(){
    this.addEvents('create');
    Ext.apply(this,{
        activeRecord: null,
        defaultType:  'textfield',
        id:'tplt_connect',
        x: 0, 
        fieldDefaults: {
         labelAlign:  'top' //,
        },
        items: [
        { 
        xtype:'panel', 
        id:'tplt_connect-0',
        title:      'Общие',
        defaultType:  'textfield',
        closable:false,
        collapsible:true,
        titleCollapse : true,
        layout:'absolute', 
        x: 0, 
            items: [
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 0, 

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
name:   'connectionenabled_grid',
itemId:   'connectionenabled_grid',
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('connectionenabled', records[0].get('value'));}  },
fieldLabel:  'Подключение разрешено',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
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
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('connecttype', records[0].get('id'));}  },
store: cmbstore_tpld_connecttype,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'connecttype_grid',
itemId:   'connecttype_grid',
fieldLabel:  'Тип подключения',
labelClsExtra:'x-item-mandatory',
allowBlank:false
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 0, 

xtype:  'numberfield',
value:  '0',
name:   'paramlimit',
itemId:   'paramlimit',
fieldLabel:  'Время опроса параметра',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 46, 

xtype:  'numberfield',
value:  '0',
name:   'connectlimit',
itemId:   'connectlimit',
fieldLabel:  'Время на соединение',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 46, 

xtype:  'combobox',
trigger1Cls:        'x-form-clear-trigger', 
trigger2Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
hideTrigger2:false, 
onTrigger1Click : function(){
		this.collapse();
		this.clearValue();
		this.up('form' ).activeRecord.set('theserver',null );
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
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('theserver', records[0].get('id'));}  },
store: cmbstore_tpsrv_info,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'theserver_grid',
itemId:   'theserver_grid',
fieldLabel:  'Сервер опроса',
allowBlank:true
       ,labelWidth: 120
}
       ], width: 760,
       height: 132 
        } //group
,
        { 
        xtype:'panel', 
        id:'tplt_connect-1',
        title:      'Параметры',
        defaultType:  'textfield',
        closable:false,
        collapsible:true,
        titleCollapse : true,
        layout:'absolute', 
        x: 0, 
            items: [
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 0, 

xtype:  'textfield',
value:  '',
name:   'cspeed',
itemId:   'cspeed',
fieldLabel:  'Скорость бод',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 0, 

xtype:  'textfield',
value:  '',
name:   'cdatabit',
itemId:   'cdatabit',
fieldLabel:  'Биты данных',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 0, 

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
store: enum_ParityType,
valueField:     'name',
displayField:   'name',
typeAhead: true,
queryMode:      'local',
emptyText:      '',
name:   'cparity_grid',
itemId:   'cparity_grid',
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('cparity', records[0].get('value'));}  },
fieldLabel:  'Четность',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 46, 

xtype:  'numberfield',
value:  '0',
name:   'cstopbits',
itemId:   'cstopbits',
fieldLabel:  'Стоповые биты',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 46, 

xtype:  'textfield',
value:  '',
name:   'flowcontrol',
itemId:   'flowcontrol',
fieldLabel:  'FlowControl',
allowBlank:true
       ,labelWidth: 120
}
       ], width: 760,
       height: 132 
        } //group
,
        { 
        xtype:'panel', 
        id:'tplt_connect-2',
        title:      'Транспорт',
        defaultType:  'textfield',
        closable:false,
        collapsible:true,
        collapsed:true,
        titleCollapse : true,
        layout:'absolute', 
        x: 0, 
            items: [
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 0, 

xtype:  'textfield',
value:  '',
name:   'comportnum',
itemId:   'comportnum',
fieldLabel:  'Com Port',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 0, 

xtype:  'textfield',
value:  '',
name:   'ipaddr',
itemId:   'ipaddr',
fieldLabel:  'IP адрес',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 0, 

xtype:  'numberfield',
value:  '0',
name:   'portnum',
itemId:   'portnum',
fieldLabel:  'TCP Порт',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 46, 

xtype:  'textfield',
value:  '',
name:   'username',
itemId:   'username',
fieldLabel:  'Пользователь',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 46, 

xtype:  'textfield',
value:  '',
name:   'password',
itemId:   'password',
fieldLabel:  'Пароль',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 46, 

xtype:  'textfield',
value:  '',
name:   'ctowncode',
itemId:   'ctowncode',
fieldLabel:  'Код города',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 92, 

xtype:  'textfield',
value:  '',
name:   'cphone',
itemId:   'cphone',
fieldLabel:  'Телефон',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 92, 

xtype:  'textarea',
value:  '',
name:   'atcommand',
itemId:   'atcommand',
fieldLabel:  'AT команда',
allowBlank:true
       ,labelWidth: 120
}
       ], width: 760,
       height: 178 
        } //group
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
                url: rootURL+'index.php/c_tplt_connect/setRow',
                method:  'POST',
                params: { 
                    instanceid: this.instanceid
                    ,tplt_connectid: active.get('tplt_connectid')
                    ,connectionenabled: active.get('connectionenabled') 
                    ,connecttype: active.get('connecttype') 
                    ,paramlimit: active.get('paramlimit') 
                    ,connectlimit: active.get('connectlimit') 
                    ,theserver: active.get('theserver') 
                    ,cspeed: active.get('cspeed') 
                    ,cdatabit: active.get('cdatabit') 
                    ,cparity: active.get('cparity') 
                    ,cstopbits: active.get('cstopbits') 
                    ,flowcontrol: active.get('flowcontrol') 
                    ,comportnum: active.get('comportnum') 
                    ,ipaddr: active.get('ipaddr') 
                    ,portnum: active.get('portnum') 
                    ,username: active.get('username') 
                    ,password: active.get('password') 
                    ,ctowncode: active.get('ctowncode') 
                    ,cphone: active.get('cphone') 
                    ,atcommand: active.get('atcommand') 
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
                    if(active.get('tplt_connectid')==''){
               			active.set('tplt_connectid',res.data['tplt_connectid']);
                    }
        		    StatusReady('Изменения сохранены');
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
        if(this.activeRecord.get('tplt_connectid')==''){
                this.activeRecord.store.reload();
        }
        this.setActiveRecord(null,null);
        this.ownerCt.close();
    }
}); // 'Ext.Define

Ext.define('EditWindow_tplt_connectmain', {
    extend:  'Ext.window.Window',
    maxHeight: 557,
    maxWidth: 900,
    autoScroll:true,
    minWidth: 750,
    width: 800,
    minHeight:527,
    height:527,
    constrainHeader :true,
    layout:  'absolute',
    autoShow: true,
    modal: true,
    closable: false,
    closeAction: 'destroy',
    iconCls:  'icon-application_form',
    title:  'Параметры соединения',
    items:[{
        xtype:  'f_tplt_connectmain'
	}]
	});
}