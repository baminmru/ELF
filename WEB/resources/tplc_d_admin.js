
Ext.require([
'Ext.form.*'
]);

function DefineInterface_tplc_d_admin(id,mystore){

var groupingFeature_tplc_d = Ext.create('Ext.grid.feature.Grouping',{
groupByText:  'Группировать по этому полю',
showGroupsText:  'Показать группировку'
});
var filterFeature_tplc_d = {
menuFilterText:  'Фильтр',
ftype: 'filters',
local: true 
};
 var p1;
    function onDeleteConfirm(selection){
      if (selection) {
        Ext.Ajax.request({
            url:    rootURL+'index.php/c_tplc_d/deleteRow',
            method:  'POST',
    		params: { 
    				tplc_did: selection.get('tplc_did')
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
                var edit = Ext.create('EditWindow_tplc_dadmin');
                p1.store.insert(0, new model_tplc_d());
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
            var edit = Ext.create('EditWindow_tplc_dadmin');
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
       stateId:  'tplc_dadmin',
        iconCls:  'icon-grid',
        frame: true,
        instanceid: '',
        features: [groupingFeature_tplc_d,filterFeature_tplc_d],
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
{text: "Тепловая энергия канал 1", width:60, dataIndex: 'q1', sortable: true}
            ,
{text: "Тепловая энергия канал 2", width:60, dataIndex: 'q2', sortable: true}
            ,
{text: "Температура по каналу 1", width:60, dataIndex: 't1', sortable: true}
            ,
{text: "Температура по каналу 2", width:60, dataIndex: 't2', sortable: true}
            ,
{text: "Разность Температур по каналу 1 и 2", width:60, dataIndex: 'dt12', sortable: true}
            ,
{text: "Температура по каналу 3", width:60, dataIndex: 't3', sortable: true}
            ,
{text: "Температура по каналу 4", width:60, dataIndex: 't4', sortable: true}
            ,
{text: "Температура по каналу 5", width:60, dataIndex: 't5', sortable: true}
            ,
{text: "Разность Температур по каналу 4 и 5", width:60, dataIndex: 'dt45', sortable: true}
            ,
{text: "Температура по каналу 6", width:60, dataIndex: 't6', sortable: true}
            ,
{text: "Объемный расход воды по каналу 1", width:60, dataIndex: 'v1', sortable: true}
            ,
{text: "Объемный расход воды по каналу 2", width:60, dataIndex: 'v2', sortable: true}
            ,
{text: "Разность объемов канал 1  (расход ГВС)", width:60, dataIndex: 'dv12', sortable: true}
            ,
{text: "Объемный расход воды по каналу 3", width:60, dataIndex: 'v3', sortable: true}
            ,
{text: "Объемный расход воды по каналу 4", width:60, dataIndex: 'v4', sortable: true}
            ,
{text: "Объемный расход воды по каналу 5", width:60, dataIndex: 'v5', sortable: true}
            ,
{text: "Разность объемов канал 2", width:60, dataIndex: 'dv45', sortable: true}
            ,
{text: "Объемный расход воды по каналу 6", width:60, dataIndex: 'v6', sortable: true}
            ,
{text: "Масса воды по каналу 1", width:60, dataIndex: 'm1', sortable: true}
            ,
{text: "Масса воды по каналу 2", width:60, dataIndex: 'm2', sortable: true}
            ,
{text: "Разность масс канал 1  (расход ГВС)", width:60, dataIndex: 'dm12', sortable: true}
            ,
{text: "Масса воды по каналу 3", width:60, dataIndex: 'm3', sortable: true}
            ,
{text: "Масса воды по каналу 4", width:60, dataIndex: 'm4', sortable: true}
            ,
{text: "Масса воды по каналу 5", width:60, dataIndex: 'm5', sortable: true}
            ,
{text: "Разность масс канал 2", width:60, dataIndex: 'dm45', sortable: true}
            ,
{text: "Масса воды по каналу 6", width:60, dataIndex: 'm6', sortable: true}
            ,
{text: "Давление в трубопроводе 1", width:60, dataIndex: 'p1', sortable: true}
            ,
{text: "Давление в трубопроводе 2", width:60, dataIndex: 'p2', sortable: true}
            ,
{text: "Давление в трубопроводе 3", width:60, dataIndex: 'p3', sortable: true}
            ,
{text: "Давление в трубопроводе 4", width:60, dataIndex: 'p4', sortable: true}
            ,
{text: "Давление в трубопроводе 5", width:60, dataIndex: 'p5', sortable: true}
            ,
{text: "Давление в трубопроводе 6", width:60, dataIndex: 'p6', sortable: true}
            ,
{text: "Текущее значение расхода в трубопроводе 1", width:60, dataIndex: 'g1', sortable: true}
            ,
{text: "Текущее значение расхода в трубопроводе 2", width:60, dataIndex: 'g2', sortable: true}
            ,
{text: "Текущее значение расхода в трубопроводе 3", width:60, dataIndex: 'g3', sortable: true}
            ,
{text: "Текущее значение расхода в трубопроводе 4", width:60, dataIndex: 'g4', sortable: true}
            ,
{text: "Текущее значение расхода в трубопроводе 5", width:60, dataIndex: 'g5', sortable: true}
            ,
{text: "Текущее значение расхода в трубопроводе 6", width:60, dataIndex: 'g6', sortable: true}
            ,
{text: "Температура холодной воды", width:60, dataIndex: 'tcool', sortable: true}
            ,
{text: "Температура холодного конца канал 1", width:60, dataIndex: 'tce1', sortable: true}
            ,
{text: "Температура холодного конца канал 2", width:60, dataIndex: 'tce2', sortable: true}
            ,
{text: "Тотальное время счета TB1", width:60, dataIndex: 'tsum1', sortable: true}
            ,
{text: "Тотальное время счета TB2", width:60, dataIndex: 'tsum2', sortable: true}
            ,
{text: "Тепловая энергия канал 1 нарастающим итогом", width:60, dataIndex: 'q1h', sortable: true}
            ,
{text: "Тепловая энергия канал 2 нарастающим итогом", width:60, dataIndex: 'q2h', sortable: true}
            ,
{text: "Объемный расход воды по каналу 1  нарастающим итогом", width:60, dataIndex: 'v1h', sortable: true}
            ,
{text: "Объемный расход воды по каналу 2  нарастающим итогом", width:60, dataIndex: 'v2h', sortable: true}
            ,
{text: "Объемный расход воды по каналу 4  нарастающим итогом", width:60, dataIndex: 'v4h', sortable: true}
            ,
{text: "Объемный расход воды по каналу 5  нарастающим итогом", width:60, dataIndex: 'v5h', sortable: true}
            ,
{text: "Время аварии", width:60, dataIndex: 'errtime', sortable: true}
            ,
{text: "Время аварии нарастающим итогом", width:60, dataIndex: 'errtimeh', sortable: true}
            ,
{text: "Нештатные ситуации общ", width: 200, dataIndex: 'hc', sortable: true}
            ,
{text: "Схема потребления", width:60, dataIndex: 'sp', sortable: true}
            ,
{text: "Схема потребления TB1", width:60, dataIndex: 'sp_tb1', sortable: true}
            ,
{text: "Схема потребления TB2", width:60, dataIndex: 'sp_tb2', sortable: true}
            ,
{text: "datetimeCOUNTER", width:110, dataIndex: 'datetimecounter', sortable: true, xtype: 'datecolumn',    renderer:myDateRenderer}
            ,
{text: "G1-G2", width:60, dataIndex: 'dg12', sortable: true}
            ,
{text: "G4-G5", width:60, dataIndex: 'dg45', sortable: true}
            ,
{text: "P1-P2", width:60, dataIndex: 'dp12', sortable: true}
            ,
{text: "P4-P5", width:60, dataIndex: 'dp45', sortable: true}
            ,
{text: "Единицы измерения расхода", width: 200, dataIndex: 'unitsr', sortable: true}
            ,
{text: "Тепловая энергия канал 3", width:60, dataIndex: 'q3', sortable: true}
            ,
{text: "Тепловая энергия канал 4", width:60, dataIndex: 'q4', sortable: true}
            ,
{text: "Атмосферное давление", width:60, dataIndex: 'patm', sortable: true}
            ,
{text: "Тепловая энергия канал 5", width:60, dataIndex: 'q5', sortable: true}
            ,
{text: "Тепловая энергия потребитель 1", width:60, dataIndex: 'dq12', sortable: true}
            ,
{text: "Тепловая энергия потребитель 2", width:60, dataIndex: 'dq45', sortable: true}
            ,
{text: "Давление холодной воды", width:60, dataIndex: 'pxb', sortable: true}
            ,
{text: "Расход энергии потребитель 1", width:60, dataIndex: 'dq', sortable: true}
            ,
{text: "Нештатная ситуация 1 (ТВ1 или внешняя)", width: 200, dataIndex: 'hc_1', sortable: true}
            ,
{text: "Нештатная ситуация 2 (ТВ2 или внутренняя)", width: 200, dataIndex: 'hc_2', sortable: true}
            ,
{text: "Температура горячей воды", width:60, dataIndex: 'thot', sortable: true}
            ,
{text: "DANS1", width:60, dataIndex: 'dans1', sortable: true}
            ,
{text: "DANS2", width:60, dataIndex: 'dans2', sortable: true}
            ,
{text: "DANS3", width:60, dataIndex: 'dans3', sortable: true}
            ,
{text: "DANS4", width:60, dataIndex: 'dans4', sortable: true}
            ,
{text: "DANS5", width:60, dataIndex: 'dans5', sortable: true}
            ,
{text: "DANS6", width:60, dataIndex: 'dans6', sortable: true}
            ,
{text: "Проверка архивных данных на НС (0 - не производилась, 1 - произведена)", width:60, dataIndex: 'check_a', sortable: true}
            ,
{text: "Время безошиб.работы", width:60, dataIndex: 'oktime', sortable: true}
            ,
{text: "Время работы", width:60, dataIndex: 'worktime', sortable: true}
            ,
{text: "Температура воздуха канал 1", width:60, dataIndex: 'tair1', sortable: true}
            ,
{text: "Температура воздуха канал 2", width:60, dataIndex: 'tair2', sortable: true}
            ,
{text: "Код нештатной ситуации тепловычислителя", width: 200, dataIndex: 'hc_code', sortable: true}
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
function DefineForms_tplc_d_admin(){


Ext.define('Form_tplc_dadmin', {
extend:  'Ext.form.Panel',
alias: 'widget.f_tplc_dadmin',
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
        id:'tplc_d-0',
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
name:   'q1',
itemId:   'q1',
fieldLabel:  'Тепловая энергия канал 1',
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
name:   'q2',
itemId:   'q2',
fieldLabel:  'Тепловая энергия канал 2',
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
name:   't1',
itemId:   't1',
fieldLabel:  'Температура по каналу 1',
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
name:   't2',
itemId:   't2',
fieldLabel:  'Температура по каналу 2',
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
name:   'dt12',
itemId:   'dt12',
fieldLabel:  'Разность Температур по каналу 1 и 2',
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
name:   't3',
itemId:   't3',
fieldLabel:  'Температура по каналу 3',
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
name:   't4',
itemId:   't4',
fieldLabel:  'Температура по каналу 4',
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
name:   't5',
itemId:   't5',
fieldLabel:  'Температура по каналу 5',
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
name:   'dt45',
itemId:   'dt45',
fieldLabel:  'Разность Температур по каналу 4 и 5',
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
name:   't6',
itemId:   't6',
fieldLabel:  'Температура по каналу 6',
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
name:   'v1',
itemId:   'v1',
fieldLabel:  'Объемный расход воды по каналу 1',
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
name:   'v2',
itemId:   'v2',
fieldLabel:  'Объемный расход воды по каналу 2',
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
name:   'dv12',
itemId:   'dv12',
fieldLabel:  'Разность объемов канал 1  (расход ГВС)',
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
name:   'v3',
itemId:   'v3',
fieldLabel:  'Объемный расход воды по каналу 3',
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
name:   'v4',
itemId:   'v4',
fieldLabel:  'Объемный расход воды по каналу 4',
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
name:   'v5',
itemId:   'v5',
fieldLabel:  'Объемный расход воды по каналу 5',
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
name:   'dv45',
itemId:   'dv45',
fieldLabel:  'Разность объемов канал 2',
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
name:   'v6',
itemId:   'v6',
fieldLabel:  'Объемный расход воды по каналу 6',
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
name:   'm1',
itemId:   'm1',
fieldLabel:  'Масса воды по каналу 1',
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
name:   'm2',
itemId:   'm2',
fieldLabel:  'Масса воды по каналу 2',
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
name:   'dm12',
itemId:   'dm12',
fieldLabel:  'Разность масс канал 1  (расход ГВС)',
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
name:   'm3',
itemId:   'm3',
fieldLabel:  'Масса воды по каналу 3',
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

xtype:  'numberfield',
value:  '0',
name:   'm4',
itemId:   'm4',
fieldLabel:  'Масса воды по каналу 4',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 1150, 

xtype:  'numberfield',
value:  '0',
name:   'm5',
itemId:   'm5',
fieldLabel:  'Масса воды по каналу 5',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 1196, 

xtype:  'numberfield',
value:  '0',
name:   'dm45',
itemId:   'dm45',
fieldLabel:  'Разность масс канал 2',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 1242, 

xtype:  'numberfield',
value:  '0',
name:   'm6',
itemId:   'm6',
fieldLabel:  'Масса воды по каналу 6',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 1288, 

xtype:  'numberfield',
value:  '0',
name:   'p1',
itemId:   'p1',
fieldLabel:  'Давление в трубопроводе 1',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 1334, 

xtype:  'numberfield',
value:  '0',
name:   'p2',
itemId:   'p2',
fieldLabel:  'Давление в трубопроводе 2',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 1380, 

xtype:  'numberfield',
value:  '0',
name:   'p3',
itemId:   'p3',
fieldLabel:  'Давление в трубопроводе 3',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 1426, 

xtype:  'numberfield',
value:  '0',
name:   'p4',
itemId:   'p4',
fieldLabel:  'Давление в трубопроводе 4',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 1472, 

xtype:  'numberfield',
value:  '0',
name:   'p5',
itemId:   'p5',
fieldLabel:  'Давление в трубопроводе 5',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 1518, 

xtype:  'numberfield',
value:  '0',
name:   'p6',
itemId:   'p6',
fieldLabel:  'Давление в трубопроводе 6',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 1564, 

xtype:  'numberfield',
value:  '0',
name:   'g1',
itemId:   'g1',
fieldLabel:  'Текущее значение расхода в трубопроводе 1',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 1610, 

xtype:  'numberfield',
value:  '0',
name:   'g2',
itemId:   'g2',
fieldLabel:  'Текущее значение расхода в трубопроводе 2',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 1656, 

xtype:  'numberfield',
value:  '0',
name:   'g3',
itemId:   'g3',
fieldLabel:  'Текущее значение расхода в трубопроводе 3',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 1702, 

xtype:  'numberfield',
value:  '0',
name:   'g4',
itemId:   'g4',
fieldLabel:  'Текущее значение расхода в трубопроводе 4',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 1748, 

xtype:  'numberfield',
value:  '0',
name:   'g5',
itemId:   'g5',
fieldLabel:  'Текущее значение расхода в трубопроводе 5',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 1794, 

xtype:  'numberfield',
value:  '0',
name:   'g6',
itemId:   'g6',
fieldLabel:  'Текущее значение расхода в трубопроводе 6',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 1840, 

xtype:  'numberfield',
value:  '0',
name:   'tcool',
itemId:   'tcool',
fieldLabel:  'Температура холодной воды',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 1886, 

xtype:  'numberfield',
value:  '0',
name:   'tce1',
itemId:   'tce1',
fieldLabel:  'Температура холодного конца канал 1',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 1932, 

xtype:  'numberfield',
value:  '0',
name:   'tce2',
itemId:   'tce2',
fieldLabel:  'Температура холодного конца канал 2',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 1978, 

xtype:  'numberfield',
value:  '0',
name:   'tsum1',
itemId:   'tsum1',
fieldLabel:  'Тотальное время счета TB1',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 2024, 

xtype:  'numberfield',
value:  '0',
name:   'tsum2',
itemId:   'tsum2',
fieldLabel:  'Тотальное время счета TB2',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 2070, 

xtype:  'numberfield',
value:  '0',
name:   'q1h',
itemId:   'q1h',
fieldLabel:  'Тепловая энергия канал 1 нарастающим итогом',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 2116, 

xtype:  'numberfield',
value:  '0',
name:   'q2h',
itemId:   'q2h',
fieldLabel:  'Тепловая энергия канал 2 нарастающим итогом',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 2162, 

xtype:  'numberfield',
value:  '0',
name:   'v1h',
itemId:   'v1h',
fieldLabel:  'Объемный расход воды по каналу 1  нарастающим итогом',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 2208, 

xtype:  'numberfield',
value:  '0',
name:   'v2h',
itemId:   'v2h',
fieldLabel:  'Объемный расход воды по каналу 2  нарастающим итогом',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 2254, 

xtype:  'numberfield',
value:  '0',
name:   'v4h',
itemId:   'v4h',
fieldLabel:  'Объемный расход воды по каналу 4  нарастающим итогом',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 2300, 

xtype:  'numberfield',
value:  '0',
name:   'v5h',
itemId:   'v5h',
fieldLabel:  'Объемный расход воды по каналу 5  нарастающим итогом',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 2346, 

xtype:  'numberfield',
value:  '0',
name:   'errtime',
itemId:   'errtime',
fieldLabel:  'Время аварии',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 2392, 

xtype:  'numberfield',
value:  '0',
name:   'errtimeh',
itemId:   'errtimeh',
fieldLabel:  'Время аварии нарастающим итогом',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 2438, 

xtype:  'textfield',
value:  '',
name:   'hc',
itemId:   'hc',
fieldLabel:  'Нештатные ситуации общ',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 2484, 

xtype:  'numberfield',
value:  '0',
name:   'sp',
itemId:   'sp',
fieldLabel:  'Схема потребления',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 2530, 

xtype:  'numberfield',
value:  '0',
name:   'sp_tb1',
itemId:   'sp_tb1',
fieldLabel:  'Схема потребления TB1',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 2576, 

xtype:  'numberfield',
value:  '0',
name:   'sp_tb2',
itemId:   'sp_tb2',
fieldLabel:  'Схема потребления TB2',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 2622, 

xtype:  'datefield',
format:'d/m/Y H:i:s',
submitFormat:'Y-m-d H:i:s',
value:  '',
name:   'datetimecounter',
itemId:   'datetimecounter',
fieldLabel:  'datetimeCOUNTER',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 2668, 

xtype:  'numberfield',
value:  '0',
name:   'dg12',
itemId:   'dg12',
fieldLabel:  'G1-G2',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 2714, 

xtype:  'numberfield',
value:  '0',
name:   'dg45',
itemId:   'dg45',
fieldLabel:  'G4-G5',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 2760, 

xtype:  'numberfield',
value:  '0',
name:   'dp12',
itemId:   'dp12',
fieldLabel:  'P1-P2',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 2806, 

xtype:  'numberfield',
value:  '0',
name:   'dp45',
itemId:   'dp45',
fieldLabel:  'P4-P5',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 2852, 

xtype:  'textfield',
value:  '',
name:   'unitsr',
itemId:   'unitsr',
fieldLabel:  'Единицы измерения расхода',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 2898, 

xtype:  'numberfield',
value:  '0',
name:   'q3',
itemId:   'q3',
fieldLabel:  'Тепловая энергия канал 3',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 2944, 

xtype:  'numberfield',
value:  '0',
name:   'q4',
itemId:   'q4',
fieldLabel:  'Тепловая энергия канал 4',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 2990, 

xtype:  'numberfield',
value:  '0',
name:   'patm',
itemId:   'patm',
fieldLabel:  'Атмосферное давление',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 3036, 

xtype:  'numberfield',
value:  '0',
name:   'q5',
itemId:   'q5',
fieldLabel:  'Тепловая энергия канал 5',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 3082, 

xtype:  'numberfield',
value:  '0',
name:   'dq12',
itemId:   'dq12',
fieldLabel:  'Тепловая энергия потребитель 1',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 3128, 

xtype:  'numberfield',
value:  '0',
name:   'dq45',
itemId:   'dq45',
fieldLabel:  'Тепловая энергия потребитель 2',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 3174, 

xtype:  'numberfield',
value:  '0',
name:   'pxb',
itemId:   'pxb',
fieldLabel:  'Давление холодной воды',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 3220, 

xtype:  'numberfield',
value:  '0',
name:   'dq',
itemId:   'dq',
fieldLabel:  'Расход энергии потребитель 1',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 3266, 

xtype:  'textfield',
value:  '',
name:   'hc_1',
itemId:   'hc_1',
fieldLabel:  'Нештатная ситуация 1 (ТВ1 или внешняя)',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 3312, 

xtype:  'textfield',
value:  '',
name:   'hc_2',
itemId:   'hc_2',
fieldLabel:  'Нештатная ситуация 2 (ТВ2 или внутренняя)',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 3358, 

xtype:  'numberfield',
value:  '0',
name:   'thot',
itemId:   'thot',
fieldLabel:  'Температура горячей воды',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 3404, 

xtype:  'numberfield',
value:  '0',
name:   'dans1',
itemId:   'dans1',
fieldLabel:  'DANS1',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 3450, 

xtype:  'numberfield',
value:  '0',
name:   'dans2',
itemId:   'dans2',
fieldLabel:  'DANS2',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 3496, 

xtype:  'numberfield',
value:  '0',
name:   'dans3',
itemId:   'dans3',
fieldLabel:  'DANS3',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 3542, 

xtype:  'numberfield',
value:  '0',
name:   'dans4',
itemId:   'dans4',
fieldLabel:  'DANS4',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 3588, 

xtype:  'numberfield',
value:  '0',
name:   'dans5',
itemId:   'dans5',
fieldLabel:  'DANS5',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 3634, 

xtype:  'numberfield',
value:  '0',
name:   'dans6',
itemId:   'dans6',
fieldLabel:  'DANS6',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 3680, 

xtype:  'numberfield',
value:  '0',
name:   'check_a',
itemId:   'check_a',
fieldLabel:  'Проверка архивных данных на НС (0 - не производилась, 1 - произведена)',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 3726, 

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
        y: 3772, 

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
        y: 3818, 

xtype:  'numberfield',
value:  '0',
name:   'tair1',
itemId:   'tair1',
fieldLabel:  'Температура воздуха канал 1',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 3864, 

xtype:  'numberfield',
value:  '0',
name:   'tair2',
itemId:   'tair2',
fieldLabel:  'Температура воздуха канал 2',
allowBlank:true
       ,labelWidth: 120
}
,
{
        minWidth: 740,
        width: 740,
        maxWidth: 740,
        x: 5, 
        y: 3910, 

xtype:  'textfield',
value:  '',
name:   'hc_code',
itemId:   'hc_code',
fieldLabel:  'Код нештатной ситуации тепловычислителя',
allowBlank:true
       ,labelWidth: 120
}
       ], width: 770,
       height: 3986 
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
                url: rootURL+'index.php/c_tplc_d/setRow',
                method:  'POST',
                params: { 
                    instanceid: this.instanceid
                    ,tplc_did: active.get('tplc_did')
                    ,dcall:function() { if(active.get('dcall')) return active.get('dcall').toLocaleFormat('%Y-%m-%d %H:%M:%S'); else return null;}()
                    ,dcounter:function() { if(active.get('dcounter')) return active.get('dcounter').toLocaleFormat('%Y-%m-%d %H:%M:%S'); else return null;}()
                    ,q1: active.get('q1') 
                    ,q2: active.get('q2') 
                    ,t1: active.get('t1') 
                    ,t2: active.get('t2') 
                    ,dt12: active.get('dt12') 
                    ,t3: active.get('t3') 
                    ,t4: active.get('t4') 
                    ,t5: active.get('t5') 
                    ,dt45: active.get('dt45') 
                    ,t6: active.get('t6') 
                    ,v1: active.get('v1') 
                    ,v2: active.get('v2') 
                    ,dv12: active.get('dv12') 
                    ,v3: active.get('v3') 
                    ,v4: active.get('v4') 
                    ,v5: active.get('v5') 
                    ,dv45: active.get('dv45') 
                    ,v6: active.get('v6') 
                    ,m1: active.get('m1') 
                    ,m2: active.get('m2') 
                    ,dm12: active.get('dm12') 
                    ,m3: active.get('m3') 
                    ,m4: active.get('m4') 
                    ,m5: active.get('m5') 
                    ,dm45: active.get('dm45') 
                    ,m6: active.get('m6') 
                    ,p1: active.get('p1') 
                    ,p2: active.get('p2') 
                    ,p3: active.get('p3') 
                    ,p4: active.get('p4') 
                    ,p5: active.get('p5') 
                    ,p6: active.get('p6') 
                    ,g1: active.get('g1') 
                    ,g2: active.get('g2') 
                    ,g3: active.get('g3') 
                    ,g4: active.get('g4') 
                    ,g5: active.get('g5') 
                    ,g6: active.get('g6') 
                    ,tcool: active.get('tcool') 
                    ,tce1: active.get('tce1') 
                    ,tce2: active.get('tce2') 
                    ,tsum1: active.get('tsum1') 
                    ,tsum2: active.get('tsum2') 
                    ,q1h: active.get('q1h') 
                    ,q2h: active.get('q2h') 
                    ,v1h: active.get('v1h') 
                    ,v2h: active.get('v2h') 
                    ,v4h: active.get('v4h') 
                    ,v5h: active.get('v5h') 
                    ,errtime: active.get('errtime') 
                    ,errtimeh: active.get('errtimeh') 
                    ,hc: active.get('hc') 
                    ,sp: active.get('sp') 
                    ,sp_tb1: active.get('sp_tb1') 
                    ,sp_tb2: active.get('sp_tb2') 
                    ,datetimecounter:function() { if(active.get('datetimecounter')) return active.get('datetimecounter').toLocaleFormat('%Y-%m-%d %H:%M:%S'); else return null;}()
                    ,dg12: active.get('dg12') 
                    ,dg45: active.get('dg45') 
                    ,dp12: active.get('dp12') 
                    ,dp45: active.get('dp45') 
                    ,unitsr: active.get('unitsr') 
                    ,q3: active.get('q3') 
                    ,q4: active.get('q4') 
                    ,patm: active.get('patm') 
                    ,q5: active.get('q5') 
                    ,dq12: active.get('dq12') 
                    ,dq45: active.get('dq45') 
                    ,pxb: active.get('pxb') 
                    ,dq: active.get('dq') 
                    ,hc_1: active.get('hc_1') 
                    ,hc_2: active.get('hc_2') 
                    ,thot: active.get('thot') 
                    ,dans1: active.get('dans1') 
                    ,dans2: active.get('dans2') 
                    ,dans3: active.get('dans3') 
                    ,dans4: active.get('dans4') 
                    ,dans5: active.get('dans5') 
                    ,dans6: active.get('dans6') 
                    ,check_a: active.get('check_a') 
                    ,oktime: active.get('oktime') 
                    ,worktime: active.get('worktime') 
                    ,tair1: active.get('tair1') 
                    ,tair2: active.get('tair2') 
                    ,hc_code: active.get('hc_code') 
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
                    if(active.get('tplc_did')==''){
               			active.set('tplc_did',res.data['tplc_did']);
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
        if(this.activeRecord.get('tplc_did')==''){
                this.activeRecord.store.reload();
        }
        this.setActiveRecord(null,null);
        this.ownerCt.close();
    }
}); // 'Ext.Define

Ext.define('EditWindow_tplc_dadmin', {
    extend:  'Ext.window.Window',
    maxHeight: 4091,
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
    title:  'Суточный архив',
    items:[{
        xtype:  'f_tplc_dadmin'
	}]
	});
}