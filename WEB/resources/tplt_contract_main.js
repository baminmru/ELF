
Ext.require([
'Ext.form.*'
]);

function DefineInterface_tplt_contract_main(id,mystore){

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
                url: rootURL+'index.php/c_tplt_contract/setRow',
                method:  'POST',
                params: { 
                    instanceid: p1.instanceid
                    ,tplt_contractid: active.get('tplt_contractid')
                    ,fld12: active.get('fld12') 
                    ,fld13: active.get('fld13') 
                    ,fld14: active.get('fld14') 
                    ,fld15: active.get('fld15') 
                    ,fld16: active.get('fld16') 
                    ,fld17: active.get('fld17') 
                    ,fld18: active.get('fld18') 
                    ,fld19: active.get('fld19') 
                    ,fld20: active.get('fld20') 
                    ,fld21: active.get('fld21') 
                    ,fld22: active.get('fld22') 
                    ,fld23: active.get('fld23') 
                    ,fld24: active.get('fld24') 
                    ,fld25: active.get('fld25') 
                    ,fld26: active.get('fld26') 
                    ,fld27: active.get('fld27') 
                    ,fld28: active.get('fld28') 
                    ,fld29: active.get('fld29') 
                    ,fld30: active.get('fld30') 
                    ,fld31: active.get('fld31') 
                    ,fld32: active.get('fld32') 
                    ,fld33: active.get('fld33') 
                    ,fld34: active.get('fld34') 
                    ,fld35: active.get('fld35') 
                    ,fld36: active.get('fld36') 
                    ,fld37: active.get('fld37') 
                    ,fld40: active.get('fld40') 
                    ,fld41: active.get('fld41') 
                    ,fld42: active.get('fld42') 
                    ,fld43: active.get('fld43') 
                    ,fld45: active.get('fld45') 
                    ,fld46: active.get('fld46') 
                    ,fld47: active.get('fld47') 
                    ,fld48: active.get('fld48') 
                    ,fld49: active.get('fld49') 
                    ,fld50: active.get('fld50') 
                    ,fld51: active.get('fld51') 
                    ,fld52: active.get('fld52') 
                    ,fld53: active.get('fld53') 
                    ,fld54: active.get('fld54') 
                    ,fld55: active.get('fld55') 
                    ,fld56: active.get('fld56') 
                    ,fld57: active.get('fld57') 
                    ,fld58: active.get('fld58') 
                    ,fld59: active.get('fld59') 
                    ,fld60: active.get('fld60') 
                    ,fld61: active.get('fld61') 
                    ,fld62: active.get('fld62') 
                    ,fld63: active.get('fld63') 
                    ,fld64: active.get('fld64') 
                    ,fld65: active.get('fld65') 
                    ,fld66: active.get('fld66') 
                    ,fld67: active.get('fld67') 
                    ,fld68: active.get('fld68') 
                    ,fld69: active.get('fld69') 
                    ,fld70: active.get('fld70') 
                    ,fld71: active.get('fld71') 
                    ,fld72: active.get('fld72') 
                    ,fld73: active.get('fld73') 
                    ,fld81: active.get('fld81') 
                    ,fld82: active.get('fld82') 
                    ,fld83: active.get('fld83') 
                    ,fld84: active.get('fld84') 
                    ,fld85: active.get('fld85') 
                    ,fld86: active.get('fld86') 
                    ,fld87: active.get('fld87') 
                    ,fld88: active.get('fld88') 
                    ,fld89: active.get('fld89') 
                    ,fld90: active.get('fld90') 
                    ,fld92: active.get('fld92') 
                    ,fld93: active.get('fld93') 
                    ,fld94: active.get('fld94') 
                    ,fld95: active.get('fld95') 
                    ,fld96: active.get('fld96') 
                    ,fld97: active.get('fld97') 
                    ,fld98: active.get('fld98') 
                    ,fld99: active.get('fld99') 
                    ,fld100: active.get('fld100') 
                    ,fld101: active.get('fld101') 
                    ,fld102: active.get('fld102') 
                    ,fld103: active.get('fld103') 
                    ,fld104: active.get('fld104') 
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
                    if(active.get('tplt_contractid')==''){
               			active.set('tplt_contractid',res.data['tplt_contractid']);
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
                        url: rootURL+'index.php/c_v_autotplt_contract/getRows?&filter=[{"property":"tplt_contractid","value":"'+ active.get('tplt_contractid') + '"}]',
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
        fieldDefaults: {
         labelAlign:  'right',
         labelWidth: 110
        },
        items: [
        { 
        xtype:'fieldset', 
        anchor:     '100%',
        id:'tplt_contract-0',
        x: 0, 
        border:1, 
        layout:'absolute', 
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
name:   'fld12',
itemId:   'fld12',
fieldLabel:  '№ прибора',
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
name:   'fld13',
itemId:   'fld13',
fieldLabel:  '№ключа',
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

xtype:  'textfield',
value:  '',
name:   'fld14',
itemId:   'fld14',
fieldLabel:  'D20ОБ',
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
name:   'fld15',
itemId:   'fld15',
fieldLabel:  'D20ПР',
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
name:   'fld16',
itemId:   'fld16',
fieldLabel:  'DyГВС',
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
name:   'fld17',
itemId:   'fld17',
fieldLabel:  'DyОБР',
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
name:   'fld18',
itemId:   'fld18',
fieldLabel:  'DyПР',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 95, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld19',
itemId:   'fld19',
fieldLabel:  'dРпрОБ',
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

xtype:  'textfield',
value:  '',
name:   'fld20',
itemId:   'fld20',
fieldLabel:  'dРпрПР',
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

xtype:  'textfield',
value:  '',
name:   'fld21',
itemId:   'fld21',
fieldLabel:  'G(гвс)ПР',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 155, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld22',
itemId:   'fld22',
fieldLabel:  'Gгвс',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 155, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld23',
itemId:   'fld23',
fieldLabel:  'Gоб(гвс min)',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 185, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld24',
itemId:   'fld24',
fieldLabel:  'Gов',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 185, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld25',
itemId:   'fld25',
fieldLabel:  'Gпр(гвс min)',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 215, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld26',
itemId:   'fld26',
fieldLabel:  'Gпр_minОБ',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 215, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld27',
itemId:   'fld27',
fieldLabel:  'Gпр_minПР',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 245, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld28',
itemId:   'fld28',
fieldLabel:  'GпрОБ',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 245, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld29',
itemId:   'fld29',
fieldLabel:  'GпрПР',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 275, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld30',
itemId:   'fld30',
fieldLabel:  'Gут',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 275, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld31',
itemId:   'fld31',
fieldLabel:  'д20ОБ',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 305, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld32',
itemId:   'fld32',
fieldLabel:  'д20ПР',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 305, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld33',
itemId:   'fld33',
fieldLabel:  'Договор',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 335, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld34',
itemId:   'fld34',
fieldLabel:  'Договор G2',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 335, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld35',
itemId:   'fld35',
fieldLabel:  'Договор G1',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 365, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld36',
itemId:   'fld36',
fieldLabel:  'Источник',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 365, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld37',
itemId:   'fld37',
fieldLabel:  'Магистраль',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 395, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld40',
itemId:   'fld40',
fieldLabel:  'Расходомер',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 395, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld41',
itemId:   'fld41',
fieldLabel:  'Расходомер ГВС',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 425, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld42',
itemId:   'fld42',
fieldLabel:  'Робр',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 425, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld43',
itemId:   'fld43',
fieldLabel:  'Рпр',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 455, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld45',
itemId:   'fld45',
fieldLabel:  'Способ отбора',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 455, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld46',
itemId:   'fld46',
fieldLabel:  'Т_график',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 485, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld47',
itemId:   'fld47',
fieldLabel:  'Теп_камера',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 485, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld48',
itemId:   'fld48',
fieldLabel:  'Тип расходомера',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 515, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld49',
itemId:   'fld49',
fieldLabel:  'тип термометра',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 515, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld50',
itemId:   'fld50',
fieldLabel:  'Формула',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 545, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld51',
itemId:   'fld51',
fieldLabel:  'Наименование счетчика',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 545, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld52',
itemId:   'fld52',
fieldLabel:  'Схема',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 575, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld53',
itemId:   'fld53',
fieldLabel:  'Qот',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 575, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld54',
itemId:   'fld54',
fieldLabel:  'Qв',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 605, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld55',
itemId:   'fld55',
fieldLabel:  'Qгвс',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 605, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld56',
itemId:   'fld56',
fieldLabel:  'Qну',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 635, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld57',
itemId:   'fld57',
fieldLabel:  'Gот',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 635, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld58',
itemId:   'fld58',
fieldLabel:  'Gв',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 665, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld59',
itemId:   'fld59',
fieldLabel:  'Gну',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 665, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld60',
itemId:   'fld60',
fieldLabel:  'Часов_архив',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 695, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld61',
itemId:   'fld61',
fieldLabel:  'Сут_архив',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 695, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld62',
itemId:   'fld62',
fieldLabel:  'Термопреобр ГВС',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 725, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld63',
itemId:   'fld63',
fieldLabel:  'Т1',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 725, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld64',
itemId:   'fld64',
fieldLabel:  'Т2',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 755, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld65',
itemId:   'fld65',
fieldLabel:  'Т3',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 755, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld66',
itemId:   'fld66',
fieldLabel:  'Т4',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 785, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld67',
itemId:   'fld67',
fieldLabel:  'Gтех',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 785, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld68',
itemId:   'fld68',
fieldLabel:  'Gтех_гвс',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 815, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld69',
itemId:   'fld69',
fieldLabel:  'Gгвс_м',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 815, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld70',
itemId:   'fld70',
fieldLabel:  'Qтех',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 845, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld71',
itemId:   'fld71',
fieldLabel:  'Qвент',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 845, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld72',
itemId:   'fld72',
fieldLabel:  'Тхв',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 875, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld73',
itemId:   'fld73',
fieldLabel:  'Расходомер ГВСц',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 875, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld81',
itemId:   'fld81',
fieldLabel:  'Формула2',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 905, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld82',
itemId:   'fld82',
fieldLabel:  'Термопреобр',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 905, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld83',
itemId:   'fld83',
fieldLabel:  'Gвент',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 935, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld84',
itemId:   'fld84',
fieldLabel:  'Код УУТЭ',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 935, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld85',
itemId:   'fld85',
fieldLabel:  'Сист_теплопотребления',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 965, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld86',
itemId:   'fld86',
fieldLabel:  'Qтех_гвс',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 965, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld87',
itemId:   'fld87',
fieldLabel:  'Qтех_гвс ср',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 995, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld88',
itemId:   'fld88',
fieldLabel:  'Qгвс ср',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 995, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld89',
itemId:   'fld89',
fieldLabel:  'Дата поверки',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 1025, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld90',
itemId:   'fld90',
fieldLabel:  'Фамилия',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 1025, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld92',
itemId:   'fld92',
fieldLabel:  'Узел учета',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 1055, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld93',
itemId:   'fld93',
fieldLabel:  'Стр.адрес',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 1055, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld94',
itemId:   'fld94',
fieldLabel:  'G(гвс)ОБР',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 1085, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld95',
itemId:   'fld95',
fieldLabel:  'DyГВСц',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 1085, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld96',
itemId:   'fld96',
fieldLabel:  'Цена_имп_M1',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 1115, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld97',
itemId:   'fld97',
fieldLabel:  'Цена_имп_M2',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 1115, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld98',
itemId:   'fld98',
fieldLabel:  'Цена_имп_M1гв',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 1145, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld99',
itemId:   'fld99',
fieldLabel:  'Цена_имп_M2гв',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 1145, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld100',
itemId:   'fld100',
fieldLabel:  'Доп_погр_изм_M1%',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 1175, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld101',
itemId:   'fld101',
fieldLabel:  'Доп_погр_изм_M2%',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 1175, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld102',
itemId:   'fld102',
fieldLabel:  'Доп_погр_изм_M1гв%',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 5, 
        y: 1205, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld103',
itemId:   'fld103',
fieldLabel:  'Доп_погр_изм_M2гв%',
allowBlank:true
}
,
{
        minWidth: 365,
        width: 365,
        maxWidth: 365,
        x: 375, 
        y: 1205, 
labelWidth:140,

xtype:  'textfield',
value:  '',
name:   'fld104',
itemId:   'fld104',
fieldLabel:  'Расходомер M2',
allowBlank:true
}
       ],
       height: 1255 
        }
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
function DefineForms_tplt_contract_main(){


Ext.define('Form_tplt_contractmain', {
extend:  'Ext.form.Panel',
alias: 'widget.f_tplt_contractmain',
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
        id:'tplt_contract-0',
        layout:'absolute', 
        border:false, 
        items: [
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 0, 

xtype:  'textfield',
value:  '',
name:   'fld12',
itemId:   'fld12',
fieldLabel:  '№ прибора',
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
name:   'fld13',
itemId:   'fld13',
fieldLabel:  '№ключа',
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

xtype:  'textfield',
value:  '',
name:   'fld14',
itemId:   'fld14',
fieldLabel:  'D20ОБ',
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
name:   'fld15',
itemId:   'fld15',
fieldLabel:  'D20ПР',
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
name:   'fld16',
itemId:   'fld16',
fieldLabel:  'DyГВС',
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
name:   'fld17',
itemId:   'fld17',
fieldLabel:  'DyОБР',
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
name:   'fld18',
itemId:   'fld18',
fieldLabel:  'DyПР',
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

xtype:  'textfield',
value:  '',
name:   'fld19',
itemId:   'fld19',
fieldLabel:  'dРпрОБ',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 92, 

xtype:  'textfield',
value:  '',
name:   'fld20',
itemId:   'fld20',
fieldLabel:  'dРпрПР',
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

xtype:  'textfield',
value:  '',
name:   'fld21',
itemId:   'fld21',
fieldLabel:  'G(гвс)ПР',
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

xtype:  'textfield',
value:  '',
name:   'fld22',
itemId:   'fld22',
fieldLabel:  'Gгвс',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 138, 

xtype:  'textfield',
value:  '',
name:   'fld23',
itemId:   'fld23',
fieldLabel:  'Gоб(гвс min)',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 184, 

xtype:  'textfield',
value:  '',
name:   'fld24',
itemId:   'fld24',
fieldLabel:  'Gов',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 184, 

xtype:  'textfield',
value:  '',
name:   'fld25',
itemId:   'fld25',
fieldLabel:  'Gпр(гвс min)',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 184, 

xtype:  'textfield',
value:  '',
name:   'fld26',
itemId:   'fld26',
fieldLabel:  'Gпр_minОБ',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 230, 

xtype:  'textfield',
value:  '',
name:   'fld27',
itemId:   'fld27',
fieldLabel:  'Gпр_minПР',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 230, 

xtype:  'textfield',
value:  '',
name:   'fld28',
itemId:   'fld28',
fieldLabel:  'GпрОБ',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 230, 

xtype:  'textfield',
value:  '',
name:   'fld29',
itemId:   'fld29',
fieldLabel:  'GпрПР',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 276, 

xtype:  'textfield',
value:  '',
name:   'fld30',
itemId:   'fld30',
fieldLabel:  'Gут',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 276, 

xtype:  'textfield',
value:  '',
name:   'fld31',
itemId:   'fld31',
fieldLabel:  'д20ОБ',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 276, 

xtype:  'textfield',
value:  '',
name:   'fld32',
itemId:   'fld32',
fieldLabel:  'д20ПР',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 322, 

xtype:  'textfield',
value:  '',
name:   'fld33',
itemId:   'fld33',
fieldLabel:  'Договор',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 322, 

xtype:  'textfield',
value:  '',
name:   'fld34',
itemId:   'fld34',
fieldLabel:  'Договор G2',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 322, 

xtype:  'textfield',
value:  '',
name:   'fld35',
itemId:   'fld35',
fieldLabel:  'Договор G1',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 368, 

xtype:  'textfield',
value:  '',
name:   'fld36',
itemId:   'fld36',
fieldLabel:  'Источник',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 368, 

xtype:  'textfield',
value:  '',
name:   'fld37',
itemId:   'fld37',
fieldLabel:  'Магистраль',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 368, 

xtype:  'textfield',
value:  '',
name:   'fld40',
itemId:   'fld40',
fieldLabel:  'Расходомер',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 414, 

xtype:  'textfield',
value:  '',
name:   'fld41',
itemId:   'fld41',
fieldLabel:  'Расходомер ГВС',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 414, 

xtype:  'textfield',
value:  '',
name:   'fld42',
itemId:   'fld42',
fieldLabel:  'Робр',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 414, 

xtype:  'textfield',
value:  '',
name:   'fld43',
itemId:   'fld43',
fieldLabel:  'Рпр',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 460, 

xtype:  'textfield',
value:  '',
name:   'fld45',
itemId:   'fld45',
fieldLabel:  'Способ отбора',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 460, 

xtype:  'textfield',
value:  '',
name:   'fld46',
itemId:   'fld46',
fieldLabel:  'Т_график',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 460, 

xtype:  'textfield',
value:  '',
name:   'fld47',
itemId:   'fld47',
fieldLabel:  'Теп_камера',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 506, 

xtype:  'textfield',
value:  '',
name:   'fld48',
itemId:   'fld48',
fieldLabel:  'Тип расходомера',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 506, 

xtype:  'textfield',
value:  '',
name:   'fld49',
itemId:   'fld49',
fieldLabel:  'тип термометра',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 506, 

xtype:  'textfield',
value:  '',
name:   'fld50',
itemId:   'fld50',
fieldLabel:  'Формула',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 552, 

xtype:  'textfield',
value:  '',
name:   'fld51',
itemId:   'fld51',
fieldLabel:  'Наименование счетчика',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 552, 

xtype:  'textfield',
value:  '',
name:   'fld52',
itemId:   'fld52',
fieldLabel:  'Схема',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 552, 

xtype:  'textfield',
value:  '',
name:   'fld53',
itemId:   'fld53',
fieldLabel:  'Qот',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 598, 

xtype:  'textfield',
value:  '',
name:   'fld54',
itemId:   'fld54',
fieldLabel:  'Qв',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 598, 

xtype:  'textfield',
value:  '',
name:   'fld55',
itemId:   'fld55',
fieldLabel:  'Qгвс',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 598, 

xtype:  'textfield',
value:  '',
name:   'fld56',
itemId:   'fld56',
fieldLabel:  'Qну',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 644, 

xtype:  'textfield',
value:  '',
name:   'fld57',
itemId:   'fld57',
fieldLabel:  'Gот',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 644, 

xtype:  'textfield',
value:  '',
name:   'fld58',
itemId:   'fld58',
fieldLabel:  'Gв',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 644, 

xtype:  'textfield',
value:  '',
name:   'fld59',
itemId:   'fld59',
fieldLabel:  'Gну',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 690, 

xtype:  'textfield',
value:  '',
name:   'fld60',
itemId:   'fld60',
fieldLabel:  'Часов_архив',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 690, 

xtype:  'textfield',
value:  '',
name:   'fld61',
itemId:   'fld61',
fieldLabel:  'Сут_архив',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 690, 

xtype:  'textfield',
value:  '',
name:   'fld62',
itemId:   'fld62',
fieldLabel:  'Термопреобр ГВС',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 736, 

xtype:  'textfield',
value:  '',
name:   'fld63',
itemId:   'fld63',
fieldLabel:  'Т1',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 736, 

xtype:  'textfield',
value:  '',
name:   'fld64',
itemId:   'fld64',
fieldLabel:  'Т2',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 736, 

xtype:  'textfield',
value:  '',
name:   'fld65',
itemId:   'fld65',
fieldLabel:  'Т3',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 782, 

xtype:  'textfield',
value:  '',
name:   'fld66',
itemId:   'fld66',
fieldLabel:  'Т4',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 782, 

xtype:  'textfield',
value:  '',
name:   'fld67',
itemId:   'fld67',
fieldLabel:  'Gтех',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 782, 

xtype:  'textfield',
value:  '',
name:   'fld68',
itemId:   'fld68',
fieldLabel:  'Gтех_гвс',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 828, 

xtype:  'textfield',
value:  '',
name:   'fld69',
itemId:   'fld69',
fieldLabel:  'Gгвс_м',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 828, 

xtype:  'textfield',
value:  '',
name:   'fld70',
itemId:   'fld70',
fieldLabel:  'Qтех',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 828, 

xtype:  'textfield',
value:  '',
name:   'fld71',
itemId:   'fld71',
fieldLabel:  'Qвент',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 874, 

xtype:  'textfield',
value:  '',
name:   'fld72',
itemId:   'fld72',
fieldLabel:  'Тхв',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 874, 

xtype:  'textfield',
value:  '',
name:   'fld73',
itemId:   'fld73',
fieldLabel:  'Расходомер ГВСц',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 874, 

xtype:  'textfield',
value:  '',
name:   'fld81',
itemId:   'fld81',
fieldLabel:  'Формула2',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 920, 

xtype:  'textfield',
value:  '',
name:   'fld82',
itemId:   'fld82',
fieldLabel:  'Термопреобр',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 920, 

xtype:  'textfield',
value:  '',
name:   'fld83',
itemId:   'fld83',
fieldLabel:  'Gвент',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 920, 

xtype:  'textfield',
value:  '',
name:   'fld84',
itemId:   'fld84',
fieldLabel:  'Код УУТЭ',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 966, 

xtype:  'textfield',
value:  '',
name:   'fld85',
itemId:   'fld85',
fieldLabel:  'Сист_теплопотребления',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 966, 

xtype:  'textfield',
value:  '',
name:   'fld86',
itemId:   'fld86',
fieldLabel:  'Qтех_гвс',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 966, 

xtype:  'textfield',
value:  '',
name:   'fld87',
itemId:   'fld87',
fieldLabel:  'Qтех_гвс ср',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 1012, 

xtype:  'textfield',
value:  '',
name:   'fld88',
itemId:   'fld88',
fieldLabel:  'Qгвс ср',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 1012, 

xtype:  'textfield',
value:  '',
name:   'fld89',
itemId:   'fld89',
fieldLabel:  'Дата поверки',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 1012, 

xtype:  'textfield',
value:  '',
name:   'fld90',
itemId:   'fld90',
fieldLabel:  'Фамилия',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 1058, 

xtype:  'textfield',
value:  '',
name:   'fld92',
itemId:   'fld92',
fieldLabel:  'Узел учета',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 1058, 

xtype:  'textfield',
value:  '',
name:   'fld93',
itemId:   'fld93',
fieldLabel:  'Стр.адрес',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 1058, 

xtype:  'textfield',
value:  '',
name:   'fld94',
itemId:   'fld94',
fieldLabel:  'G(гвс)ОБР',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 1104, 

xtype:  'textfield',
value:  '',
name:   'fld95',
itemId:   'fld95',
fieldLabel:  'DyГВСц',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 1104, 

xtype:  'textfield',
value:  '',
name:   'fld96',
itemId:   'fld96',
fieldLabel:  'Цена_имп_M1',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 1104, 

xtype:  'textfield',
value:  '',
name:   'fld97',
itemId:   'fld97',
fieldLabel:  'Цена_имп_M2',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 1150, 

xtype:  'textfield',
value:  '',
name:   'fld98',
itemId:   'fld98',
fieldLabel:  'Цена_имп_M1гв',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 1150, 

xtype:  'textfield',
value:  '',
name:   'fld99',
itemId:   'fld99',
fieldLabel:  'Цена_имп_M2гв',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 1150, 

xtype:  'textfield',
value:  '',
name:   'fld100',
itemId:   'fld100',
fieldLabel:  'Доп_погр_изм_M1%',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 1196, 

xtype:  'textfield',
value:  '',
name:   'fld101',
itemId:   'fld101',
fieldLabel:  'Доп_погр_изм_M2%',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 255, 
        y: 1196, 

xtype:  'textfield',
value:  '',
name:   'fld102',
itemId:   'fld102',
fieldLabel:  'Доп_погр_изм_M1гв%',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 505, 
        y: 1196, 

xtype:  'textfield',
value:  '',
name:   'fld103',
itemId:   'fld103',
fieldLabel:  'Доп_погр_изм_M2гв%',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 220,
        width: 220,
        maxWidth: 220,
        x: 5, 
        y: 1242, 

xtype:  'textfield',
value:  '',
name:   'fld104',
itemId:   'fld104',
fieldLabel:  'Расходомер M2',
allowBlank:true
       ,labelWidth: 120
}
       ], width: 770,
       height: 1318 
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
                url: rootURL+'index.php/c_tplt_contract/setRow',
                method:  'POST',
                params: { 
                    instanceid: this.instanceid
                    ,tplt_contractid: active.get('tplt_contractid')
                    ,fld12: active.get('fld12') 
                    ,fld13: active.get('fld13') 
                    ,fld14: active.get('fld14') 
                    ,fld15: active.get('fld15') 
                    ,fld16: active.get('fld16') 
                    ,fld17: active.get('fld17') 
                    ,fld18: active.get('fld18') 
                    ,fld19: active.get('fld19') 
                    ,fld20: active.get('fld20') 
                    ,fld21: active.get('fld21') 
                    ,fld22: active.get('fld22') 
                    ,fld23: active.get('fld23') 
                    ,fld24: active.get('fld24') 
                    ,fld25: active.get('fld25') 
                    ,fld26: active.get('fld26') 
                    ,fld27: active.get('fld27') 
                    ,fld28: active.get('fld28') 
                    ,fld29: active.get('fld29') 
                    ,fld30: active.get('fld30') 
                    ,fld31: active.get('fld31') 
                    ,fld32: active.get('fld32') 
                    ,fld33: active.get('fld33') 
                    ,fld34: active.get('fld34') 
                    ,fld35: active.get('fld35') 
                    ,fld36: active.get('fld36') 
                    ,fld37: active.get('fld37') 
                    ,fld40: active.get('fld40') 
                    ,fld41: active.get('fld41') 
                    ,fld42: active.get('fld42') 
                    ,fld43: active.get('fld43') 
                    ,fld45: active.get('fld45') 
                    ,fld46: active.get('fld46') 
                    ,fld47: active.get('fld47') 
                    ,fld48: active.get('fld48') 
                    ,fld49: active.get('fld49') 
                    ,fld50: active.get('fld50') 
                    ,fld51: active.get('fld51') 
                    ,fld52: active.get('fld52') 
                    ,fld53: active.get('fld53') 
                    ,fld54: active.get('fld54') 
                    ,fld55: active.get('fld55') 
                    ,fld56: active.get('fld56') 
                    ,fld57: active.get('fld57') 
                    ,fld58: active.get('fld58') 
                    ,fld59: active.get('fld59') 
                    ,fld60: active.get('fld60') 
                    ,fld61: active.get('fld61') 
                    ,fld62: active.get('fld62') 
                    ,fld63: active.get('fld63') 
                    ,fld64: active.get('fld64') 
                    ,fld65: active.get('fld65') 
                    ,fld66: active.get('fld66') 
                    ,fld67: active.get('fld67') 
                    ,fld68: active.get('fld68') 
                    ,fld69: active.get('fld69') 
                    ,fld70: active.get('fld70') 
                    ,fld71: active.get('fld71') 
                    ,fld72: active.get('fld72') 
                    ,fld73: active.get('fld73') 
                    ,fld81: active.get('fld81') 
                    ,fld82: active.get('fld82') 
                    ,fld83: active.get('fld83') 
                    ,fld84: active.get('fld84') 
                    ,fld85: active.get('fld85') 
                    ,fld86: active.get('fld86') 
                    ,fld87: active.get('fld87') 
                    ,fld88: active.get('fld88') 
                    ,fld89: active.get('fld89') 
                    ,fld90: active.get('fld90') 
                    ,fld92: active.get('fld92') 
                    ,fld93: active.get('fld93') 
                    ,fld94: active.get('fld94') 
                    ,fld95: active.get('fld95') 
                    ,fld96: active.get('fld96') 
                    ,fld97: active.get('fld97') 
                    ,fld98: active.get('fld98') 
                    ,fld99: active.get('fld99') 
                    ,fld100: active.get('fld100') 
                    ,fld101: active.get('fld101') 
                    ,fld102: active.get('fld102') 
                    ,fld103: active.get('fld103') 
                    ,fld104: active.get('fld104') 
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
                    if(active.get('tplt_contractid')==''){
               			active.set('tplt_contractid',res.data['tplt_contractid']);
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
        if(this.activeRecord.get('tplt_contractid')==''){
                this.activeRecord.store.reload();
        }
        this.setActiveRecord(null,null);
        this.ownerCt.close();
    }
}); // 'Ext.Define

Ext.define('EditWindow_tplt_contractmain', {
    extend:  'Ext.window.Window',
    maxHeight: 1423,
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
    title:  'Договорные установки',
    items:[{
        xtype:  'f_tplt_contractmain'
	}]
	});
}