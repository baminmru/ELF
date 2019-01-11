
var groupingFeature_autotpsrv_info = Ext.create('Ext.grid.feature.Grouping',{
groupByText:  'Группировать по этому полю',
showGroupsText:  'Показать группировку'
});
var interval_autotpsrv_info;
Ext.define('grid_autotpsrv_info', {
    extend:  'Ext.grid.Panel',
    alias: 'widget.g_v_autotpsrv_info',
    requires: [
        'Ext.grid.*',
        'Ext.form.field.Text',
        'Ext.toolbar.TextItem'
    ],
    initComponent: function(){
        Ext.apply(this, {
        frame: false,
        store: store_v_autotpsrv_info,
        features: [groupingFeature_autotpsrv_info],
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
            {text: "Имя сервера", width:400, dataIndex: 'tpsrv_info_name', sortable: true}
            ,
            {text: "IP сервера", width:400, dataIndex: 'tpsrv_info_ipaddr', sortable: true}
        ]
        ,
        bbar: Ext.create('Ext.PagingToolbar', {
        store: store_v_autotpsrv_info,
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

value:  '',
name:   'tpsrv_info_name',
itemId:   'tpsrv_info_name',
fieldLabel:  '',
emptyText:      'Имя сервера',
hideLabel:  true,
listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'Имя сервера'});}}
}
,
{

value:  '',
name:   'tpsrv_info_ipaddr',
itemId:   'tpsrv_info_ipaddr',
fieldLabel:  '',
emptyText:      'IP сервера',
hideLabel:  true,
listeners: {render: function(e) {Ext.QuickTips.register({  target: e.getEl(), text: 'IP сервера'});}}
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
        			//interval_autotpsrv_info= setInterval(function() {  
        			//	store_v_autotpsrv_info.load();
        			//}, 60000);
        		}
        	,
        	destroy:function(){
        		//clearInterval(interval_autotpsrv_info);
        }
    },
    onDeleteConfirm:function(selection){
      if (selection) {
        Ext.Ajax.request({
            url:    rootURL+'index.php/c_v_autotpsrv_info/deleteRow',
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
   	    if(CheckOperation('TPSRV.edit')!=0 && OTAllowDelete('TPSRV')){
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
   	    if(CheckOperation('TPSRV.edit')!=0 && OTAllowAdd('TPSRV')){
            Ext.Ajax.request({
                url: rootURL+'index.php/c_v_autotpsrv_info/newRow',
                method:  'POST',
                params: { 
                },
                success: function(response){
                var text = response.responseText;
                var res =Ext.decode(text);
                var edit = Ext.create('iu.windowObjects');
                edit.prefix='c_v_autotpsrv_info';
                edit.setTitle('Создание документа:Сервер') ;
                var p=eval('TPSRV_Panel_'+OTAddMode('TPSRV')+'( res.data, false,null )') ;
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
   	    if(CheckOperation('TPSRV.edit')!=0 ){
                var edit = Ext.create('iu.windowObjects');
                edit.prefix='c_v_autotpsrv_info';
                edit.setTitle('Редактирование документа: Сервер') ;
            var p=eval('TPSRV_Panel_'+OTEditMode('TPSRV')+'( selection.get(\'instanceid\'), false, selection )') ;
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
function TPSRV_Jrnl(){ 

  var TPSRV= Ext.create('Ext.form.Panel', {
       closable: true,
       id:     'tpsrv_jrnl',
       title: 'Сервер',
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
            itemId:'gr_autotpsrv_info',
            xtype:'g_v_autotpsrv_info',
            stateful: stateFulSystem,
            stateId:'j_v_autotpsrv_info',
            layout: 'fit',
            flex: 1,
            store: store_v_autotpsrv_info
    }] // tabpanel
    }); //Ext.Create
    return TPSRV;
}
Ext.define('ObjectWindow_tpsrv', {
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
    title:  'Сервер',
    items:[ ]
	});