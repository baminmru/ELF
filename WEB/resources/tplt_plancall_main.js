
Ext.require([
'Ext.form.*'
]);

function DefineInterface_tplt_plancall_main(id,mystore){

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
                url: rootURL+'index.php/c_tplt_plancall/setRow',
                method:  'POST',
                params: { 
                    instanceid: p1.instanceid
                    ,tplt_plancallid: active.get('tplt_plancallid')
                    ,cstatus: active.get('cstatus') 
                    ,nmaxcall: active.get('nmaxcall') 
                    ,minrepeat: active.get('minrepeat') 
                    ,dlock: active.get('dlock') 
                    ,dlastcall: active.get('dlastcall') 
                    ,ccurr: active.get('ccurr') 
                    ,icallcurr: active.get('icallcurr') 
                    ,dnextcurr: active.get('dnextcurr') 
                    ,chour: active.get('chour') 
                    ,icall: active.get('icall') 
                    ,numhour: active.get('numhour') 
                    ,dnexthour: active.get('dnexthour') 
                    ,dlasthour: active.get('dlasthour') 
                    ,c24: active.get('c24') 
                    ,icall24: active.get('icall24') 
                    ,num24: active.get('num24') 
                    ,dnext24: active.get('dnext24') 
                    ,dlastday: active.get('dlastday') 
                    ,csum: active.get('csum') 
                    ,icallsum: active.get('icallsum') 
                    ,dnextsum: active.get('dnextsum') 
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
                    if(active.get('tplt_plancallid')==''){
               			active.set('tplt_plancallid',res.data['tplt_plancallid']);
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
                        url: rootURL+'index.php/c_v_autotplt_plancall/getRows?&filter=[{"property":"tplt_plancallid","value":"'+ active.get('tplt_plancallid') + '"}]',
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
        id:'tplt_plancall',
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
        id:'tplt_plancall_0',
        title:      'Общая настройка',
        defaultType:  'textfield',
            items: [
{
        minWidth: 370,
        width: 370,
        maxWidth: 370,
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
name:   'cstatus_grid',
itemId:   'cstatus_grid',
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('cstatus', records[0].get('value'));}  },
fieldLabel:  'Исключить из опроса',
allowBlank:true
}
,
{
        minWidth: 370,
        width: 370,
        maxWidth: 370,
        x: 380, 
        y: 5, 
labelWidth:140,

xtype:  'numberfield',
value:  '0',
name:   'nmaxcall',
itemId:   'nmaxcall',
fieldLabel:  'Max число попыток дозвона',
allowBlank:true
}
,
{
        minWidth: 370,
        width: 370,
        maxWidth: 370,
        x: 5, 
        y: 35, 
labelWidth:140,

xtype:  'numberfield',
value:  '0',
name:   'minrepeat',
itemId:   'minrepeat',
fieldLabel:  'Повторить через (минут)',
allowBlank:true
}
,
{
        minWidth: 370,
        width: 370,
        maxWidth: 370,
        x: 380, 
        y: 35, 
labelWidth:140,

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:   'dlock',
itemId:   'dlock',
fieldLabel:  'Когда заблокирован',
allowBlank:true
}
,
{
        minWidth: 370,
        width: 370,
        maxWidth: 370,
        x: 5, 
        y: 65, 
labelWidth:140,

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:   'dlastcall',
itemId:   'dlastcall',
fieldLabel:  'Последний опрос',
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
        id:'tplt_plancall_1',
        title:      'Текущие',
        defaultType:  'textfield',
            items: [
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 5, 
        y: 5, 
labelWidth:110,

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
name:   'ccurr_grid',
itemId:   'ccurr_grid',
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('ccurr', records[0].get('value'));}  },
fieldLabel:  'Опрашивать текущие',
allowBlank:true
}
,
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 255, 
        y: 5, 
labelWidth:110,

xtype:  'numberfield',
value:  '0',
name:   'icallcurr',
itemId:   'icallcurr',
fieldLabel:  'Интервал (минут) ',
allowBlank:true
}
,
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 505, 
        y: 5, 
labelWidth:110,

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:   'dnextcurr',
itemId:   'dnextcurr',
fieldLabel:  'Следующий опрос',
allowBlank:true
}
       ], 
       height: 70 
        } // group
,
        { 
        xtype:'fieldset', 
        anchor: '100%',
        x: 0, 
        layout:'absolute', 
        id:'tplt_plancall_2',
        title:      'Часовые',
        defaultType:  'textfield',
            items: [
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 5, 
        y: 5, 
labelWidth:110,

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
name:   'chour_grid',
itemId:   'chour_grid',
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('chour', records[0].get('value'));}  },
fieldLabel:  'Опрашивать',
allowBlank:true
}
,
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 255, 
        y: 5, 
labelWidth:110,

xtype:  'numberfield',
value:  '0',
name:   'icall',
itemId:   'icall',
fieldLabel:  'Интервал опроса (минут)',
allowBlank:true
}
,
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 505, 
        y: 5, 
labelWidth:110,

xtype:  'numberfield',
value:  '0',
name:   'numhour',
itemId:   'numhour',
fieldLabel:  'За сколько часов',
allowBlank:true
}
,
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 5, 
        y: 35, 
labelWidth:110,

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:   'dnexthour',
itemId:   'dnexthour',
fieldLabel:  'Следующий опрос',
allowBlank:true
}
,
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 255, 
        y: 35, 
labelWidth:110,

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:   'dlasthour',
itemId:   'dlasthour',
fieldLabel:  'Последний опрос',
allowBlank:true
}
       ], 
       height: 100 
        } // group
,
        { 
        xtype:'fieldset', 
        anchor: '100%',
        x: 0, 
        layout:'absolute', 
        id:'tplt_plancall_3',
        title:      'Суточные',
        defaultType:  'textfield',
            items: [
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 5, 
        y: 5, 
labelWidth:110,

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
name:   'c24_grid',
itemId:   'c24_grid',
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('c24', records[0].get('value'));}  },
fieldLabel:  'Опрашивать',
allowBlank:true
}
,
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 255, 
        y: 5, 
labelWidth:110,

xtype:  'numberfield',
value:  '0',
name:   'icall24',
itemId:   'icall24',
fieldLabel:  'Интервал (часов)',
allowBlank:true
}
,
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 505, 
        y: 5, 
labelWidth:110,

xtype:  'numberfield',
value:  '0',
name:   'num24',
itemId:   'num24',
fieldLabel:  'За сколько суток',
allowBlank:true
}
,
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 5, 
        y: 35, 
labelWidth:110,

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:   'dnext24',
itemId:   'dnext24',
fieldLabel:  'Следующий опрос',
allowBlank:true
}
,
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 255, 
        y: 35, 
labelWidth:110,

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:   'dlastday',
itemId:   'dlastday',
fieldLabel:  'Последний опрос',
allowBlank:true
}
       ], 
       height: 100 
        } // group
,
        { 
        xtype:'fieldset', 
        anchor: '100%',
        x: 0, 
        layout:'absolute', 
        id:'tplt_plancall_4',
        title:      'Итоговые',
        defaultType:  'textfield',
            items: [
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 5, 
        y: 5, 
labelWidth:110,

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
name:   'csum_grid',
itemId:   'csum_grid',
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('csum', records[0].get('value'));}  },
fieldLabel:  'Опрашивать',
allowBlank:true
}
,
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 255, 
        y: 5, 
labelWidth:110,

xtype:  'numberfield',
value:  '0',
name:   'icallsum',
itemId:   'icallsum',
fieldLabel:  'Интервал  (минут) ',
allowBlank:true
}
,
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 505, 
        y: 5, 
labelWidth:110,

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:   'dnextsum',
itemId:   'dnextsum',
fieldLabel:  'Следующий опрос',
allowBlank:true
}
       ], 
       height: 70 
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
function DefineForms_tplt_plancall_main(){


Ext.define('Form_tplt_plancallmain', {
extend:  'Ext.form.Panel',
alias: 'widget.f_tplt_plancallmain',
initComponent: function(){
    this.addEvents('create');
    Ext.apply(this,{
        activeRecord: null,
        defaultType:  'textfield',
        id:'tplt_plancall',
        x: 0, 
        fieldDefaults: {
         labelAlign:  'top' //,
        },
        items: [
        { 
        xtype:'panel', 
        id:'tplt_plancall-0',
        title:      'Общая настройка',
        defaultType:  'textfield',
        closable:false,
        collapsible:true,
        titleCollapse : true,
        layout:'absolute', 
        x: 0, 
            items: [
{
        minWidth: 370,
        width: 370,
        maxWidth: 370,
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
name:   'cstatus_grid',
itemId:   'cstatus_grid',
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('cstatus', records[0].get('value'));}  },
fieldLabel:  'Исключить из опроса',
allowBlank:true
       ,labelWidth: 140
}
,
{
        minWidth: 370,
        width: 370,
        maxWidth: 370,
        x: 380, 
        y: 0, 

xtype:  'numberfield',
value:  '0',
name:   'nmaxcall',
itemId:   'nmaxcall',
fieldLabel:  'Max число попыток дозвона',
allowBlank:true
       ,labelWidth: 140
}
,
{
        minWidth: 370,
        width: 370,
        maxWidth: 370,
        x: 5, 
        y: 46, 

xtype:  'numberfield',
value:  '0',
name:   'minrepeat',
itemId:   'minrepeat',
fieldLabel:  'Повторить через (минут)',
allowBlank:true
       ,labelWidth: 140
}
,
{
        minWidth: 370,
        width: 370,
        maxWidth: 370,
        x: 380, 
        y: 46, 

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:   'dlock',
itemId:   'dlock',
fieldLabel:  'Когда заблокирован',
allowBlank:true
       ,labelWidth: 140
}
,
{
        minWidth: 370,
        width: 370,
        maxWidth: 370,
        x: 5, 
        y: 92, 

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:   'dlastcall',
itemId:   'dlastcall',
fieldLabel:  'Последний опрос',
allowBlank:true
       ,labelWidth: 140
}
       ], width: 760,
       height: 178 
        } //group
,
        { 
        xtype:'panel', 
        id:'tplt_plancall-1',
        title:      'Текущие',
        defaultType:  'textfield',
        closable:false,
        collapsible:true,
        titleCollapse : true,
        layout:'absolute', 
        x: 0, 
            items: [
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
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
name:   'ccurr_grid',
itemId:   'ccurr_grid',
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('ccurr', records[0].get('value'));}  },
fieldLabel:  'Опрашивать текущие',
allowBlank:true
       ,labelWidth: 110
}
,
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 255, 
        y: 0, 

xtype:  'numberfield',
value:  '0',
name:   'icallcurr',
itemId:   'icallcurr',
fieldLabel:  'Интервал (минут) ',
allowBlank:true
       ,labelWidth: 110
}
,
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 505, 
        y: 0, 

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:   'dnextcurr',
itemId:   'dnextcurr',
fieldLabel:  'Следующий опрос',
allowBlank:true
       ,labelWidth: 110
}
       ], width: 760,
       height: 86 
        } //group
,
        { 
        xtype:'panel', 
        id:'tplt_plancall-2',
        title:      'Часовые',
        defaultType:  'textfield',
        closable:false,
        collapsible:true,
        collapsed:true,
        titleCollapse : true,
        layout:'absolute', 
        x: 0, 
            items: [
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
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
name:   'chour_grid',
itemId:   'chour_grid',
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('chour', records[0].get('value'));}  },
fieldLabel:  'Опрашивать',
allowBlank:true
       ,labelWidth: 110
}
,
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 255, 
        y: 0, 

xtype:  'numberfield',
value:  '0',
name:   'icall',
itemId:   'icall',
fieldLabel:  'Интервал опроса (минут)',
allowBlank:true
       ,labelWidth: 110
}
,
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 505, 
        y: 0, 

xtype:  'numberfield',
value:  '0',
name:   'numhour',
itemId:   'numhour',
fieldLabel:  'За сколько часов',
allowBlank:true
       ,labelWidth: 110
}
,
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 5, 
        y: 46, 

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:   'dnexthour',
itemId:   'dnexthour',
fieldLabel:  'Следующий опрос',
allowBlank:true
       ,labelWidth: 110
}
,
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 255, 
        y: 46, 

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:   'dlasthour',
itemId:   'dlasthour',
fieldLabel:  'Последний опрос',
allowBlank:true
       ,labelWidth: 110
}
       ], width: 760,
       height: 132 
        } //group
,
        { 
        xtype:'panel', 
        id:'tplt_plancall-3',
        title:      'Суточные',
        defaultType:  'textfield',
        closable:false,
        collapsible:true,
        collapsed:true,
        titleCollapse : true,
        layout:'absolute', 
        x: 0, 
            items: [
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
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
name:   'c24_grid',
itemId:   'c24_grid',
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('c24', records[0].get('value'));}  },
fieldLabel:  'Опрашивать',
allowBlank:true
       ,labelWidth: 110
}
,
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 255, 
        y: 0, 

xtype:  'numberfield',
value:  '0',
name:   'icall24',
itemId:   'icall24',
fieldLabel:  'Интервал (часов)',
allowBlank:true
       ,labelWidth: 110
}
,
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 505, 
        y: 0, 

xtype:  'numberfield',
value:  '0',
name:   'num24',
itemId:   'num24',
fieldLabel:  'За сколько суток',
allowBlank:true
       ,labelWidth: 110
}
,
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 5, 
        y: 46, 

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:   'dnext24',
itemId:   'dnext24',
fieldLabel:  'Следующий опрос',
allowBlank:true
       ,labelWidth: 110
}
,
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 255, 
        y: 46, 

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:   'dlastday',
itemId:   'dlastday',
fieldLabel:  'Последний опрос',
allowBlank:true
       ,labelWidth: 110
}
       ], width: 760,
       height: 132 
        } //group
,
        { 
        xtype:'panel', 
        id:'tplt_plancall-4',
        title:      'Итоговые',
        defaultType:  'textfield',
        closable:false,
        collapsible:true,
        collapsed:true,
        titleCollapse : true,
        layout:'absolute', 
        x: 0, 
            items: [
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
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
name:   'csum_grid',
itemId:   'csum_grid',
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('csum', records[0].get('value'));}  },
fieldLabel:  'Опрашивать',
allowBlank:true
       ,labelWidth: 110
}
,
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 255, 
        y: 0, 

xtype:  'numberfield',
value:  '0',
name:   'icallsum',
itemId:   'icallsum',
fieldLabel:  'Интервал  (минут) ',
allowBlank:true
       ,labelWidth: 110
}
,
{
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 505, 
        y: 0, 

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:   'dnextsum',
itemId:   'dnextsum',
fieldLabel:  'Следующий опрос',
allowBlank:true
       ,labelWidth: 110
}
       ], width: 760,
       height: 86 
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
                url: rootURL+'index.php/c_tplt_plancall/setRow',
                method:  'POST',
                params: { 
                    instanceid: this.instanceid
                    ,tplt_plancallid: active.get('tplt_plancallid')
                    ,cstatus: active.get('cstatus') 
                    ,nmaxcall: active.get('nmaxcall') 
                    ,minrepeat: active.get('minrepeat') 
                    ,dlock:function() { if(active.get('dlock')) return active.get('dlock').toLocaleFormat('%Y-%m-%d %H:%M:%S'); else return null;}()
                    ,dlastcall:function() { if(active.get('dlastcall')) return active.get('dlastcall').toLocaleFormat('%Y-%m-%d %H:%M:%S'); else return null;}()
                    ,ccurr: active.get('ccurr') 
                    ,icallcurr: active.get('icallcurr') 
                    ,dnextcurr:function() { if(active.get('dnextcurr')) return active.get('dnextcurr').toLocaleFormat('%Y-%m-%d %H:%M:%S'); else return null;}()
                    ,chour: active.get('chour') 
                    ,icall: active.get('icall') 
                    ,numhour: active.get('numhour') 
                    ,dnexthour:function() { if(active.get('dnexthour')) return active.get('dnexthour').toLocaleFormat('%Y-%m-%d %H:%M:%S'); else return null;}()
                    ,dlasthour:function() { if(active.get('dlasthour')) return active.get('dlasthour').toLocaleFormat('%Y-%m-%d %H:%M:%S'); else return null;}()
                    ,c24: active.get('c24') 
                    ,icall24: active.get('icall24') 
                    ,num24: active.get('num24') 
                    ,dnext24:function() { if(active.get('dnext24')) return active.get('dnext24').toLocaleFormat('%Y-%m-%d %H:%M:%S'); else return null;}()
                    ,dlastday:function() { if(active.get('dlastday')) return active.get('dlastday').toLocaleFormat('%Y-%m-%d %H:%M:%S'); else return null;}()
                    ,csum: active.get('csum') 
                    ,icallsum: active.get('icallsum') 
                    ,dnextsum:function() { if(active.get('dnextsum')) return active.get('dnextsum').toLocaleFormat('%Y-%m-%d %H:%M:%S'); else return null;}()
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
                    if(active.get('tplt_plancallid')==''){
               			active.set('tplt_plancallid',res.data['tplt_plancallid']);
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
        if(this.activeRecord.get('tplt_plancallid')==''){
                this.activeRecord.store.reload();
        }
        this.setActiveRecord(null,null);
        this.ownerCt.close();
    }
}); // 'Ext.Define

Ext.define('EditWindow_tplt_plancallmain', {
    extend:  'Ext.window.Window',
    maxHeight: 739,
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
    title:  'План опроса устройств',
    items:[{
        xtype:  'f_tplt_plancallmain'
	}]
	});
}