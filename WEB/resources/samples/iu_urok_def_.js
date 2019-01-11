
Ext.require([
'Ext.form.*'
]);

function DefineInterface_iu_urok_def_(id,mystore,selection){

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
            var form_values = form.getValues(); var field_name = '';  for(field_name in form_values){active.set(field_name, form_values[field_name]);}
        	StatusDB('Сохранение данных');
            Ext.Ajax.request({
                url: rootURL+'index.php/c_iu_urok_def/setRow',
                method:  'POST',
                params: { 
                    instanceid: p1.instanceid
                    ,iu_urok_defid: active.get('iu_urok_defid')
                    ,ucode: active.get('ucode') 
                    ,datecreated: active.get('datecreated') 
                    ,subject: active.get('subject') 
                    ,theclassnum: active.get('theclassnum') 
                    ,plannum: active.get('plannum') 
                    ,maketown: active.get('maketown') 
                    ,coursetype: active.get('coursetype') 
                    ,rtheme: active.get('rtheme') 
                    ,classtheme: active.get('classtheme') 
                    ,thequarter: active.get('thequarter') 
                    ,schooldate: active.get('schooldate') 
                    ,curator: active.get('curator') 
                    ,theteacher: active.get('theteacher') 
                    ,methodist: active.get('methodist') 
                    ,methodist2: active.get('methodist2') 
                    ,processtype: active.get('processtype') 
                    ,topstage: active.get('topstage') 
                    ,iu_urok_stage: active.get('iu_urok_stage') 
                    ,isdone: active.get('isdone') 
                    ,testpageref: active.get('testpageref') 
                    ,mainref: active.get('mainref') 
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
                    if(active.get('iu_urok_defid')==''){
               			active.set('iu_urok_defid',res.data['iu_urok_defid']);
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
                        url:        rootURL+'index.php/c_v_autoiu_urok_def/getRows?&filter=[{"property":"iu_urok_defid","value":"'+ active.get('iu_urok_defid') + '"}]',
                        method:     'GET',
                        success: function(response){
                            var data = Ext.decode(response.responseText);
                            selection.set(data.rows[0]);
                            selection.commit();
                        }
                     });
                   }
                    if (close_after_save) { if (typeof(callaftersave) == 'function') callaftersave(); if(p1.up('window')) p1.up('window').close(); }
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
            selection: selection,
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
        id:'iu_urok_def',
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
        id:'iu_urok_def_0',
        title:      'Информация',
        defaultType:  'textfield',
            items: [
{
xtype:  'hidden',
name:   'ucode',
fieldLabel:  'Код урока'
}
,
{
xtype:  'hidden',
name:   'datecreated',
fieldLabel:  'Дата создания'
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
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
editable: true,
enableRegEx: true,
queryMode:'local',
listeners:{  
select: function ( combo, records, eOpts ) {
	combo.up('form' ).activeRecord.set('subject', records[0].get('id'));
	combo.up('form' ).activeRecord.set('subject_grid', combo.getValue());
	//cmbstore_teacher_subj.load({params:{subject:combo.getValue()}});
} ,
focus: function()   {  this.store.load();  }
 },
store: cmbstore_iud_predmet,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'subject_grid',
itemId:   'subject_grid',
fieldLabel:  'Предмет',
labelClsExtra:'x-item-mandatory',
allowBlank:false
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
editable: true,
enableRegEx: true,
queryMode:'local',
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('theclassnum', records[0].get('id'));} ,focus: function()   {  this.store.load();  } },
store: cmbstore_iu_clsinfo,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'theclassnum_grid',
itemId:   'theclassnum_grid',
fieldLabel:  'Класс',
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

xtype:  'textfield',
value:  '',
name:   'plannum',
itemId:   'plannum',
fieldLabel:  'Номер по плану',
labelClsExtra:'x-item-mandatory',
allowBlank:false
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 35, 
labelWidth:140,

xtype:  'combobox',
trigger1Cls:        'x-form-clear-trigger', 
trigger2Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
hideTrigger2:false, 
onTrigger1Click : function(){
		this.collapse();
		this.clearValue();
		this.up('form' ).activeRecord.set('maketown',null );
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
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('maketown', records[0].get('id'));}  },
store: cmbstore_iud_town,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'maketown_grid',
itemId:   'maketown_grid',
fieldLabel:  'Город съемки',
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
		this.up('form' ).activeRecord.set('coursetype',null );
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
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('coursetype', records[0].get('id'));}  },
store: cmbstore_iud_ctype,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'coursetype_grid',
itemId:   'coursetype_grid',
fieldLabel:  'Тип курса',
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
name:   'rtheme',
itemId:   'rtheme',
fieldLabel:  'Тема раздела',
labelClsExtra:'x-item-mandatory',
allowBlank:false
}
,
{
        minWidth: 720,
        x: 5, 
        y: 95, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'classtheme',
itemId:   'classtheme',
fieldLabel:  'Тема урока',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 125, 
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
store: enum_Quarter,
valueField:     'value',
displayField:   'name',
typeAhead: true,
queryMode:      'local',
emptyText:      '',
name:   'thequarter',
itemId:   'thequarter',
fieldLabel:  'Четверть',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 125, 
labelWidth:140,

xtype:  'datefield',
format:'F, d',
submitFormat:'F, d',
value:  '',
name:   'schooldate',
itemId:   'schooldate',
fieldLabel:  'Дата в школе',
allowBlank:true
}
       ], 
       height: 190 
        } // group
,
        { 
        xtype:'fieldset', 
        anchor: '100%',
        x: 0, 
        layout:'absolute', 
        id:'iu_urok_def_1',
        title:      'Персонал',
        defaultType:  'textfield',
            items: [
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 5, 
labelWidth:140,

xtype:  'combobox',
trigger1Cls:        'x-form-clear-trigger', 
trigger2Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
hideTrigger2:false, 
onTrigger1Click : function(){
		this.collapse();
		this.clearValue();
		this.up('form' ).activeRecord.set('curator',null );
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
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('curator', records[0].get('id'));} ,focus: function()   {  this.store.load();  } },
store: cmbstore_iu_u_def,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'curator_grid',
itemId:   'curator_grid',
fieldLabel:  'Куратор',
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
trigger1Cls:        'x-form-clear-trigger', 
trigger2Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
hideTrigger2:false, 
onTrigger1Click : function(){
		this.collapse();
		this.clearValue();
		this.up('form' ).activeRecord.set('theteacher',null );
},
onTrigger2Click : function(){ 
		if(this.isExpanded) {
			this.collapse(); 
		}else{ 
			if(this.store.count(false)==0) this.store.load();
			this.expand();
		}
},
trigger3Cls:        'x-form-add-trigger', 
hideTrigger3:false, 
onTrigger3Click : function(){ 
onAddTeacher(this); 
},
editable: true,
enableRegEx: true,
queryMode:'local',
listeners:{  
select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('theteacher', records[0].get('id'));} ,
focus: function(combo,record)   { 
  this.store.load({params:{subject:combo.up('form' ).activeRecord.get('subject_grid')}});
 } 
},
store: cmbstore_teacher_subj,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'theteacher_grid',
itemId:   'theteacher_grid',
fieldLabel:  'Учитель',
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

xtype:  'combobox',
trigger1Cls:        'x-form-clear-trigger', 
trigger2Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
hideTrigger2:false, 
onTrigger1Click : function(){
		this.collapse();
		this.clearValue();
		this.up('form' ).activeRecord.set('methodist',null );
},
onTrigger2Click : function(){ 
		if(this.isExpanded) {
			this.collapse(); 
		}else{ 
			if(this.store.count(false)==0) this.store.load();
			this.expand();
		}
},
trigger3Cls:        'x-form-add-trigger', 
hideTrigger3:false, 
onTrigger3Click : function(){ 
onAddMethodist(this); 
},
editable: true,
enableRegEx: true,
queryMode:'local',
listeners:{  
select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('methodist', records[0].get('id'));} ,
focus: function(combo,record)   { 
  this.store.load({params:{subject:combo.up('form' ).activeRecord.get('subject_grid'),metodist:-1}});
 } 
},
store: cmbstore_metodist_subj,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'methodist_grid',
itemId:   'methodist_grid',
fieldLabel:  'Методист',
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

xtype:  'combobox',
trigger1Cls:        'x-form-clear-trigger', 
trigger2Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
hideTrigger2:false, 
onTrigger1Click : function(){
		this.collapse();
		this.clearValue();
		this.up('form' ).activeRecord.set('methodist2',null );
},
onTrigger2Click : function(){ 
		if(this.isExpanded) {
			this.collapse(); 
		}else{ 
			if(this.store.count(false)==0) this.store.load();
			this.expand();
		}
},
trigger3Cls:        'x-form-add-trigger', 
hideTrigger3:false, 
onTrigger3Click : function(){ 
onAddMethodist2(this); 
},
editable: true,
enableRegEx: true,
queryMode:'local',
listeners:{  
select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('methodist2', records[0].get('id'));} ,
focus: function(combo,record)   { 
  this.store.load({params:{subject:combo.up('form' ).activeRecord.get('subject_grid'),metodist:-1}});
 } 
},
store: cmbstore_metodist_subj,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'methodist2_grid',
itemId:   'methodist2_grid',
fieldLabel:  'Методист 2',
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
        id:'iu_urok_def_2',
        title:      'Состояние',
        defaultType:  'textfield',
            items: [
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
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
editable: true,
enableRegEx: true,
queryMode:'local',
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('processtype', records[0].get('id'));} ,focus: function()   {  this.store.load();  } },
store: cmbstore_iud_process_def,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'processtype_grid',
itemId:   'processtype_grid',
fieldLabel:  'Тип процесса',
labelClsExtra:'x-item-mandatory',
allowBlank:false
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 5, 
labelWidth:140,

hideTrigger: true,
editable: false,
readOnly: true,
       cls:'x-item-readonly',
store: cmbstore_iud_stagedef,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'topstage_grid',
itemId:   'topstage_grid',
fieldLabel:  'Этап',
allowBlank:true
}
,
{
        /* flex_field */ 
        minWidth: 735,
        width: 735,
        maxWidth: 735,
        x: 5, 
        y: 35, 
labelWidth:140,

hideTrigger: true,
editable: false,
readOnly: true,
       cls:'x-item-readonly',
store: cmbstore_iu_status,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'iu_urok_stage_grid',
itemId:   'iu_urok_stage_grid',
fieldLabel:  'Подэтап',
allowBlank:true
}
,
{
xtype:  'hidden',
name:   'isdone',
fieldLabel:  'Завершен'
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
        id:'iu_urok_def_3',
        title:      'Ссылки',
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
name:   'testpageref',
itemId:   'testpageref',
fieldLabel:  'Тестовая',
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
name:   'mainref',
itemId:   'mainref',
fieldLabel:  'Публикация',
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
function DefineForms_iu_urok_def_(){


Ext.define('Form_iu_urok_def', {
extend:  'Ext.form.Panel',
alias: 'widget.f_iu_urok_def',
initComponent: function(){
    this.addEvents('create');
    Ext.apply(this,{
        activeRecord: null,
        defaultType:  'textfield',
        id:'iu_urok_def',
        x: 0, 
        fieldDefaults: {
         labelAlign:  'top' //,
        },
        items: [
        { 
        xtype:'panel', 
        id:'iu_urok_def-0',
        title:      'Информация',
        defaultType:  'textfield',
        closable:false,
        collapsible:true,
        titleCollapse : true,
        layout:'absolute', 
        x: 0, 
            items: [
{
          xtype:  'hidden',
          name:   'ucode',
          fieldLabel:  'Код урока'
}
,
,
{
          xtype:  'hidden',
          name:   'datecreated',
          fieldLabel:  'Дата создания'
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
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
editable: true,
enableRegEx: true,
queryMode:'local',
listeners:{  select: function ( combo, records, eOpts ) {
  combo.up('form' ).activeRecord.set('subject', records[0].get('id')); 
  cmbstore_teacher_subj.load({params:{subject:combo.getValue()}});
  //cmbstore_teacher_subj.load({params:{subject:combo.up('form' ).activeRecord.get()'subject_grid'}});
 } ,focus: function()   {  this.store.load();  } },
store: cmbstore_iud_predmet,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'subject_grid',
itemId:   'subject_grid',
fieldLabel:  'Предмет',
labelClsExtra:'x-item-mandatory',
allowBlank:false
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
editable: true,
enableRegEx: true,
queryMode:'local',
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('theclassnum', records[0].get('id'));} ,focus: function()   {  this.store.load();  } },
store: cmbstore_iu_clsinfo,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'theclassnum_grid',
itemId:   'theclassnum_grid',
fieldLabel:  'Класс',
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

xtype:  'textfield',
value:  '',
name:   'plannum',
itemId:   'plannum',
fieldLabel:  'Номер по плану',
labelClsExtra:'x-item-mandatory',
allowBlank:false
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
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
		this.up('form' ).activeRecord.set('maketown',null );
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
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('maketown', records[0].get('id'));}  },
store: cmbstore_iud_town,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'maketown_grid',
itemId:   'maketown_grid',
fieldLabel:  'Город съемки',
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
		this.up('form' ).activeRecord.set('coursetype',null );
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
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('coursetype', records[0].get('id'));}  },
store: cmbstore_iud_ctype,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'coursetype_grid',
itemId:   'coursetype_grid',
fieldLabel:  'Тип курса',
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
name:   'rtheme',
itemId:   'rtheme',
fieldLabel:  'Тема раздела',
labelClsExtra:'x-item-mandatory',
allowBlank:false
       ,labelWidth: 120
}
,
{
        minWidth: 730,
        maxWidth: 730,
        width: 730,
        x: 5, 
        y: 92, 

xtype:  'textfield',
value:  '',
name:   'classtheme',
itemId:   'classtheme',
fieldLabel:  'Тема урока',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 138, 

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
store: enum_Quarter,
valueField:     'value',
displayField:   'name',
typeAhead: true,
queryMode:      'local',
emptyText:      '',
name:   'thequarter',
itemId:   'thequarter',
fieldLabel:  'Четверть',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 138, 

xtype:  'datefield',
format:'F, d',
submitFormat:'F, d',
value:  '',
name:   'schooldate',
itemId:   'schooldate',
fieldLabel:  'Дата в школе',
allowBlank:true
       ,labelWidth: 120
}
       ], width: 760,
       height: 224 
        } //group
,
        { 
        xtype:'panel', 
        id:'iu_urok_def-1',
        title:      'Персонал',
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

xtype:  'combobox',
trigger1Cls:        'x-form-clear-trigger', 
trigger2Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
hideTrigger2:false, 
onTrigger1Click : function(){
		this.collapse();
		this.clearValue();
		this.up('form' ).activeRecord.set('curator',null );
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
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('curator', records[0].get('id'));} ,focus: function()   {  this.store.load();  } },
store: cmbstore_iu_u_def,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'curator_grid',
itemId:   'curator_grid',
fieldLabel:  'Куратор',
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
trigger1Cls:        'x-form-clear-trigger', 
trigger2Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
hideTrigger2:false, 
onTrigger1Click : function(){
		this.collapse();
		this.clearValue();
		this.up('form' ).activeRecord.set('theteacher',null );
},
onTrigger2Click : function(){ 
		if(this.isExpanded) {
			this.collapse(); 
		}else{ 
			if(this.store.count(false)==0) this.store.load();
			this.expand();
		}
},
trigger3Cls:        'x-form-add-trigger', 
hideTrigger3:false, 
onTrigger3Click : function(){ 
onAddTeacher(this); 
},
editable: true,
enableRegEx: true,
queryMode:'local',
listeners:{  
select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('theteacher', records[0].get('id'));} ,
focus: function(combo,record)   { 
  alert('focus!');
 this.store.load({params:{subject:combo.up('form' ).activeRecord.get('subject_grid')}});
 } 
},
store: cmbstore_teacher_subj,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'theteacher_grid',
itemId:   'theteacher_grid',
fieldLabel:  'Учитель',
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

xtype:  'combobox',
trigger1Cls:        'x-form-clear-trigger', 
trigger2Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
hideTrigger2:false, 
onTrigger1Click : function(){
		this.collapse();
		this.clearValue();
		this.up('form' ).activeRecord.set('methodist',null );
},
onTrigger2Click : function(){ 
		if(this.isExpanded) {
			this.collapse(); 
		}else{ 
			if(this.store.count(false)==0) this.store.load();
			this.expand();
		}
},
trigger3Cls:        'x-form-add-trigger', 
hideTrigger3:false, 
onTrigger3Click : function(){ 
onAddMethodist(this); 
},
editable: true,
enableRegEx: true,
queryMode:'local',
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('methodist', records[0].get('id'));} ,focus: function()   {  this.store.load();  } },
store: cmbstore_iu_tmdef,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'methodist_grid',
itemId:   'methodist_grid',
fieldLabel:  'Методист',
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

xtype:  'combobox',
trigger1Cls:        'x-form-clear-trigger', 
trigger2Cls:        'x-form-select-trigger', 
hideTrigger1:false, 
hideTrigger2:false, 
onTrigger1Click : function(){
		this.collapse();
		this.clearValue();
		this.up('form' ).activeRecord.set('methodist2',null );
},
onTrigger2Click : function(){ 
		if(this.isExpanded) {
			this.collapse(); 
		}else{ 
			if(this.store.count(false)==0) this.store.load();
			this.expand();
		}
},
trigger3Cls:        'x-form-add-trigger', 
hideTrigger3:false, 
onTrigger3Click : function(){ 
onAddMethodist2(this); 
},
editable: true,
enableRegEx: true,
queryMode:'local',
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('methodist2', records[0].get('id'));} ,focus: function()   {  this.store.load();  } },
store: cmbstore_iu_tmdef,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'methodist2_grid',
itemId:   'methodist2_grid',
fieldLabel:  'Методист 2',
allowBlank:true
       ,labelWidth: 120
}
       ], width: 760,
       height: 132 
        } //group
,
        { 
        xtype:'panel', 
        id:'iu_urok_def-2',
        title:      'Состояние',
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
editable: true,
enableRegEx: true,
queryMode:'local',
listeners:{  select: function ( combo, records, eOpts ) {combo.up('form' ).activeRecord.set('processtype', records[0].get('id'));} ,focus: function()   {  this.store.load();  } },
store: cmbstore_iud_process_def,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'processtype_grid',
itemId:   'processtype_grid',
fieldLabel:  'Тип процесса',
labelClsExtra:'x-item-mandatory',
allowBlank:false
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 0, 

hideTrigger: true,
editable: false,
readOnly: true,
       cls:'x-item-readonly',
store: cmbstore_iud_stagedef,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'topstage_grid',
itemId:   'topstage_grid',
fieldLabel:  'Этап',
allowBlank:true
       ,labelWidth: 120
}
,
{
        /* flex_field */ 
        minWidth: 245,
        width: 245,
        maxWidth: 245,
        x: 505, 
        y: 0, 

hideTrigger: true,
editable: false,
readOnly: true,
       cls:'x-item-readonly',
store: cmbstore_iu_status,
valueField:     'brief',
displayField:   'brief',
typeAhead: true,
emptyText:      '',
name:   'iu_urok_stage_grid',
itemId:   'iu_urok_stage_grid',
fieldLabel:  'Подэтап',
allowBlank:true
       ,labelWidth: 120
}
,
,
{
          xtype:  'hidden',
          name:   'isdone',
          fieldLabel:  'Завершен'
}
       ], width: 760,
       height: 86 
        } //group
,
        { 
        xtype:'panel', 
        id:'iu_urok_def-3',
        title:      'Ссылки',
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
name:   'testpageref',
itemId:   'testpageref',
fieldLabel:  'Тестовая',
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
name:   'mainref',
itemId:   'mainref',
fieldLabel:  'Публикация',
allowBlank:true
       ,labelWidth: 120
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
            var form_values = form.getValues(); var field_name = '';  for(field_name in form_values){active.set(field_name, form_values[field_name]);}
        	StatusDB('Сохранение данных');
            form.submit({
                url: rootURL+'index.php/c_iu_urok_def/setRow',
                method:  'POST',
                params: { 
                    instanceid: this.instanceid
                    ,iu_urok_defid: active.get('iu_urok_defid')
                    ,subject: active.get('subject') 
                    ,theclassnum: active.get('theclassnum') 
                    ,maketown: active.get('maketown') 
                    ,coursetype: active.get('coursetype') 
                    ,curator: active.get('curator') 
                    ,theteacher: active.get('theteacher') 
                    ,methodist: active.get('methodist') 
                    ,methodist2: active.get('methodist2') 
                    ,processtype: active.get('processtype') 
                    ,topstage: active.get('topstage') 
                    ,iu_urok_stage: active.get('iu_urok_stage') 
                }
                , success: function(){
        		    StatusReady('Изменения сохранены');
                 }
                , failure: function(response){
        		    StatusReady('Ошибка сохранения данных');
                 }
            });   // end submit 
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
        if(this.activeRecord.get('iu_urok_defid')==''){
                this.activeRecord.store.reload();
        }
        this.setActiveRecord(null,null);
        this.ownerCt.close();
    }
}); // 'Ext.Define

Ext.define('EditWindow_iu_urok_def', {
    extend:  'Ext.window.Window',
    maxHeight: 648,
    maxWidth: 790,
    minHeight:603,
    minWidth: 790,
    width: 790,
    constrainHeader :true,
    layout:  'absolute',
    autoShow: true,
    modal: true,
    closable: false,
    closeAction: 'destroy',
    iconCls:  'icon-application_form',
    title:  'Описание',
    items:[{
        xtype:  'f_iu_urok_def'
	}]
	});
}