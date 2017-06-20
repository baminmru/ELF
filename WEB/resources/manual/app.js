
Ext.Loader.setConfig({
  enabled: true
 });
 Ext.Loader.setPath('Ext.ux', rootURL+'/ux');

 
 Ext.require([
  'Ext.layout.container.*',
  'Ext.resizer.Splitter',
  'Ext.fx.target.Element',
  'Ext.fx.target.Component',
  'Ext.window.Window',
  'Ext.selection.CellModel',
  'Ext.grid.*',
  'Ext.data.*',
  'Ext.util.*',
  'Ext.state.*',
  'Ext.form.*',
  'Ext.grid.plugin.*',
  'Ext.ux.CheckColumn', 
  'Ext.ux.grid.FiltersFeature',
  'Ext.toolbar.Paging',
  'Ext.ux.statusbar.StatusBar',
  'Ext.ModelManager',
   'Ext.tip.QuickTipManager'
 ]);
 
 Ext.Loader.setConfig({enabled: true});

Ext.Component.prototype.stateful = false;
try{
	//Ext.state.Manager.setProvider(new Ext.state.CookieProvider());
	Ext.state.Manager.setProvider(new Ext.state.LocalStorageProvider());
}catch( ex ){
	//alert(ex);

}

Ext.define('iu.window', {
	extend: 'Ext.window.Window',
	closeAction:'destroy',
	modal : true,
	constrainHeader:true,
	resizable : false,
	labelAlign: 'right',	
	title:'',
	buttonOkCaption: 'Сохранить и закрыть',
	buttonOkDisabled: false,
	buttonOkHidden: false,	
	buttonOkIconCls: 'icon-accept',		
	buttonCancelCaption: 'Отмена',
	buttonCancelDisabled: false,
	buttonCancelHidden: false,
	buttonCancelIconCls: 'icon-cancel',		
	initComponent:function() 
	{
		Ext.apply(this, 
		{		
			buttons:
			[		
				{
					id: this.id+'_buttonOk',
					iconCls:  this.buttonOkIconCls,					
					text: this.buttonOkCaption,					
					disabled: this.buttonOkDisabled,
					hidden: this.buttonOkHidden,					
					handler: Ext.bind(this.onButtonOk, this)
				},
				{
					id: this.id+'_buttonCancel',
					iconCls:  this.buttonCancelIconCls,				
					text: this.buttonCancelCaption,
					disabled: this.buttonCancelDisabled,
					hidden: this.buttonCancelHidden,					
					handler: Ext.bind(this.onButtonCancel, this)
				}
			]
		});
		this.callParent();
	},
	formSave: function()
	{
		var me = this;
		var form =  me.down('#form').getForm();
		if(form.isValid())
		{		
			form.submit(
			{
				url: me.url+'/setRow',
				waitMsg: 'Сохранение...',
				success: function(f, response)
				{	
					var result = response.result;
					
					if(result.success==false)
					{
						Ext.Msg.error('Ошибка', 'Ошибка');
					}
					else
					{							
						me.formAfterSave(result.data);										
						me.close();	
					};
				},
				failure: function(f,response) 
				{
					Ext.Msg.error('Ошибка', response.result.msg);
				}
			});
		}
	},
	formAfterSave: function(result){},	
	onButtonOk: function(){this.formSave()},
	onButtonCancel: function(){this.close();}
});


Ext.define('iu.windowObjects', {
    extend:'iu.window',
    maxHeight: 620,
    minHeight: 620,
    minWidth: 820,
    maxWidth: 1024,
    layout:  'fit',
    border: 0,
    autoShow: true,	
	deleteConfirmed:false,
	title:'',
	buttonCancelCaption: 'Закрыть',
	prefix: '',
	listeners:
	{
		beforeclose:function( thisform, eOpts )
		{
			var me = this;	
			/*
			if(true ) //!me.items.items[0].canClose())
			{
				var result=false;
				var instanceid=me.items.items[0].instanceid;
				if(!me.deleteConfirmed)
				{					  
					Ext.Msg.confirm('Внимание!', 'Форма не заполнена и будет удалена. Удалить?', function(btn)
					{
						if (btn == 'yes') 
						{
							 Ext.Ajax.request({
								url:    rootURL+'index.php/'+me.prefix+'/deleteRow',
								method:  'POST',
								params: 
								{ 
									instanceid: instanceid
								}
							});
							me.deleteConfirmed=true;
							me.close();
							result=true;
						}
						else
						{
							result=false;
							me.deleteConfirmed=false;
							me.close();
						}
					});
				}
				else
				{
					result=true;
				}
				return result;
			}
			*/
			/*
			var result=false;
			
			if(!me.items.items[0].canClose())
			{
				var instanceid=me.items.items[0].instanceid;
				
				if(!me.deleteConfirmed){
				
					Ext.Msg.confirm('Внимание!', 'Форма не заполнена и будет удалена. Удалить?', function(btn)
					{
						if (btn == 'yes') 
						{
							 Ext.Ajax.request({
								url:    rootURL+'index.php/c_v_auto'+me.prefix+'_info/deleteRow',
								method:  'POST',
								params: 
								{ 
									instanceid: instanceid
								}
							});
							me.deleteConfirmed=true;
							me.close();
							result=true;
						}
						else
						{
							result=false;
							me.deleteConfirmed=false;
						}
					});					 
				}
				else result=true;				
			}
			else
			{				
				if(!me.deleteConfirmed)
				{
					Ext.Msg.confirm('Внимание!', 'Вы действительно хотите закрыть карточку объекта без сохранения?', function(btn)
					{
						if (btn == 'yes') 
						{
							me.deleteConfirmed=true;	
							me.close();										
							result=true;
						}
						else
						{
							result=false;
							me.deleteConfirmed=false;
						}
					});

				}
				else result=true;
			}
			
			return result;
			*/
			return true;
		}
	},
    items:[],
	onButtonOk: function(){if(typeof(this.items.items[0].onButtonOk)=='function') this.items.items[0].onButtonOk();},
	onButtonCancel: function(){ if(typeof(this.items.items[0].onButtonCancel)=='function') this.items.items[0].onButtonCancel();   this.close();}
});




 
Ext.define('application_info',{
            extend:'Ext.data.Model',
        fields: [
			{name: 'userid',type: 'string'},
			{name: 'roleid',type: 'string'},
			{name: 'rolename',type: 'string'},
			{name: 'login',type: 'string'},
            {name: 'info',type: 'string'},
        ]
});


 Ext.define('application_actions',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'accesible',type: 'integer'}
            ,{name: 'menuname',type: 'string'}
            ,{name: 'menucode',type: 'string'}
        ]
});

	
 Ext.define('application_operations',{
		extend:'Ext.data.Model',
	fields: [
		{name: 'allowaction',type: 'integer'}
		,{name: 'name',type: 'string'}
	]
});

 Ext.define('application_modes',{
		extend:'Ext.data.Model',
	fields: [
		{name: 'name',type: 'string'}
		,{name: 'addmode',type: 'string'}
		,{name: 'editmode',type: 'string'}
		,{name: 'allowadd',type: 'integer'}
		,{name: 'allowdelete',type: 'integer'}
	]
});

var app_operations;
var app_modes;
var menuPanel;
var leftPanel;
var contentPanel;
var inClick = false;
var app_info;
function CurrentUserID(){
	return app_info.getAt(0).get("userid");
};
function CurrentRoleID(){
	return app_info.getAt(0).get("roleid");
};
function CurrentUserName(){
	return app_info.getAt(0).get("info");
};
function CurrentRoleName(){
	return app_info.getAt(0).get("rolename");
};




Ext.onReady(function () {
    Ext.tip.QuickTipManager.init();
    UserLogin();
});

function combo_LoadNext() {
    if (combo_Index < combo_Stores.length - 1) {
        combo_Index = combo_Index + 1;
        combo_Waiter = 0;
        combo_StoreLoaded = false;
        combo_Stores[combo_Index].load();
        combo_timeout_id = setTimeout(combo_wait, 100);
        if (combo_pbar)
            combo_pbar.updateProgress(combo_Index / combo_Stores.length, 'Запрос пакета данных ' + (combo_Index + 1) + ' из ' + combo_Stores.length + '...');
    } else {
        HideLoading();
    }
}

function combo_wait() {
    if (combo_StoreLoaded) {
        clearTimeout(combo_timeout_id);
        combo_LoadNext();
    } else {
        combo_Waiter = combo_Waiter + 1;
        if (combo_Waiter == 300) {
            clearTimeout(combo_timeout_id);
            combo_LoadNext();
        } else {
            combo_timeout_id = setTimeout(combo_wait, 100);
        }
    }
}

function HideLoading() {
    var loadingMask = Ext.get('loading-mask');
    var loading = Ext.get('loading');
    //  Hide loading message
    loading.fadeOut({ duration:0.2, remove:true });
    //  Hide loading mask
    loadingMask.setOpacity(0.9);
    loadingMask.shift({
        xy:loading.getXY(),
        width:loading.getWidth(),
        height:loading.getHeight(),
        remove:true,
        duration:1,
        opacity:0.1,
        easing:'bounceOut'
    });
	//EnableActions();
}



var cardNav = function (name, incr, maxtab) {
    var l = Ext.getCmp(name).getLayout();
    var i = l.activeItem.id.split(name + '-')[1];
    var next = parseInt(i, 10) + incr;
    l.setActiveItem(next);
    Ext.getCmp(name + '-prev').setDisabled(next === 0);
    Ext.getCmp(name + '-next').setDisabled(next === maxtab);
}


function EnableActions(){

	app_actions.each(function(record,idx){
	
	 var name=record.get('menucode'); 
	 var enableMenu = record.get('accesible'); 
	 var comp=null;
	 //console.log('code->'+name);
	 if(enableMenu==-1){
		comp=null;
		//startMenu.items[0].menu.down("#"+name)
		comp=menuPanel.down("#"+name);
		//console.log('comp->'+comp);
		if (comp!=null){
			comp.hidden=false;
			comp.disabled=false;
		    /* var comp1=null
			 comp1=comp.up();
			if(comp1!=null)
				if(comp1.hidden)
					comp1.show(); */
		}
	 }else{
		comp=null;
		comp=menuPanel.down("#"+name);
		//console.log('comp->'+comp);
		if (comp!=null){
			comp.disabled=true;
			comp.hidden=true;
			
		}
		
	 }
	 
	}
	
	
	);
	menuPanel.doLayout();
	
	
	
	
	
};


function MakeExit(btn){
		if(btn=="yes"){
			Ext.Ajax.request(
					{
						url: rootURL+'index.php/app/logout',
						method:  'POST',
						success: function(response){
							document.location=document.location;
							
						}
					}
				);
			//document.location=document.location;
		}
    };
	var actionEXIT = Ext.create('Ext.Action', {
		itemId:'actionEXIT',
        text: 'Выход',
        iconCls: 'icon-door',
		disabled:false,
        handler: function(){
            Ext.Msg.confirm('Выход из приложения?',
				'Завершить работу с приложением?',
				 MakeExit);
			
        }
    });
	
	var actionChangePassword = Ext.create('Ext.Action', {
		itemId:'actionChangePassword',
        text: 'Сменить пароль',
        iconCls: 'icon-building_key',
		disabled:false,
        handler: function() {
				var edit = Ext.create('EditWindow_sp_password');
				edit.show();
			}
    });

	
	var actionReportH= Ext.create('Ext.Action', {
	itemId:             'actionReportH',
	text:               'Часовые архивы',
	iconCls:            'icon-script_lightning',
	disabled:false,
	handler: function(){
		var j=Ext.getCmp('iu_report');
		if(j==null){
			j=ReportsH();
			j.iconCls='icon-script_lightning';
			contentPanel.add(j);
			contentPanel.setActiveTab(j);
		}
		else{
			contentPanel.setActiveTab(j);
		}
	}
});

	var actionReportD= Ext.create('Ext.Action', {
	itemId:             'actionReportD',
	text:               'Суточные архивы',
	iconCls:            'icon-script_lightning',
	disabled:false,
	handler: function(){
		var j=Ext.getCmp('iu_report_d');
		if(j==null){
			j=ReportsD();
			j.iconCls='icon-script_lightning';
			contentPanel.add(j);
			contentPanel.setActiveTab(j);
		}
		else{
			contentPanel.setActiveTab(j);
		}
	}
});


function MyInit(){
    combo_pbar = Ext.create('Ext.ProgressBar', {
        id:'combo_pbar',
        width:300,
        renderTo:'loading'
    });

	/*
    var app_info_loaded=false;
	app_info = Ext.create('Ext.data.Store', {
        model:'application_info',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/app/getSessionInfo',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){
		app_info_loaded =true;
		combo_StoreLoaded=true; 
		var comp=menuPanel.down("#sessionInfo"); 
	    comp.setValue('Пользователь: '+app_info.getAt(0).get("info") + '. (' + app_info.getAt(0).get("rolename") +')' );
	   }
       }
    });
	combo_Stores.push(app_info);

	app_modes = Ext.create('Ext.data.Store', {
        model:'application_modes',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/app/getModes',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){ combo_StoreLoaded=true; }
       }
    });
	combo_Stores.push(app_modes);

	app_actions = Ext.create('Ext.data.Store', {
        model:'application_actions',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   'index.php/app/getActions',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){app_actions_loaded =true;combo_StoreLoaded=true; EnableActions();}
       }
    });
	combo_Stores.push(app_actions);
	*/

    menuPanel = new Ext.panel.Panel({
        xtype:'panel',
        region:'north',
        dockedItems:{
            itemId:'toolbar',
            xtype:'toolbar',
            items:[ 
                {
					itemId:'actionFile',
				    text:'Файл',
                    iconCls:'icon-folder',
                    menu:[ actionChangePassword,actionEXIT] 
				
				}
				,
				{
					itemId:'actionDict',
				    text:'Справочники',
                    iconCls:'icon-book_open',
                    menu:[actionTPLD,actionbpc,actionbpdi,actionbpdr,actionbprcfg,actionbpu] 
				
				}
				,
				
				{
					itemId:'actionProcess',
				    text:'Узлы',
                    iconCls:'icon-chart_bar',
                    menu:[actionTPN,actionTPLS,actionTPLT,actionTPSRV,actionTPLC] 
				
				},
				{
					itemId:'actionReports',
				    text:'Отчеты',
                    iconCls:'icon-script',
                    menu:[actionReportH,actionReportD] 
				
				}
				
				/*,
				{
					itemId:'actionReports',
				    text:'Отчеты',
                    iconCls:'icon-script',
                    menu:[actionReportStage,actionReportCur,actionReportCurSN] 
				
				}*/
				
				,'->',
				{
					itemId:'sessionInfo',
					xtype:'displayfield',
					iconCls:'icon-information'//,
					//menu:[ actionInfo]
				}
			
				
            ]
        }
    });
	
	
    contentPanel = new Ext.tab.Panel({
        region:'center',
        xtype:'tabpanel', // TabPanel itself has no title
		splitter:true,
        activeTab:0      // First tab active by default
    });

	statusPanel = new Ext.Panel( {
	 region:'south',
     hideHeaders:true,
	 title:'',
	 //layout:'hbox',
	 border:false,
	 bbar:
		 Ext.create('Ext.ux.StatusBar', {
			id: 'my-status',

			// defaults to use when the status is cleared:
			defaultText: 'все хорошо',
			//defaultIconCls: 'icon-bullet_green',

			// values to set initially:
			text: 'Готово',
			//iconCls: 'icon-bullet_green',

		})
	
	});

    var vPort = new Ext.container.Viewport({
            layout:'border',
            renderTo:Ext.getBody(),
            items:[ /*leftPanel,*/ menuPanel, 
                contentPanel,statusPanel]
        }
    );

	//combo_LoadNext();
	
	
	
}




function CheckOperation( action){
   /* if(app_operations.getCount()==0){
		app_operations.load();
	}
	var recordIndex = app_operations.find('name', action);

	if(recordIndex == -1){
		return true;
	}else{
		return app_operations.getAt(recordIndex).get('allowaction');
	}
	*/
	return true;
}


function FindModes( objtype ){
	var recordIndex = app_modes.find('name', objtype,0,false,false,true);
	if(recordIndex == -1){
		return null;
	}else{
		return app_modes.getAt(recordIndex);
	}
}


function OTAllowAdd( objtype ){
	return true;
	var fm =FindModes(objtype);
	if(fm==null){
		return true;
	}else{
		if(fm.get('allowadd')==-1)
			return true;
		else
			return false;	
	}
}

function OTAllowDelete( objtype ){
	return true;
	var fm =FindModes(objtype);
	if(fm==null){
		return true;
	}else{
		if(fm.get('allowdelete')==-1)
			return true;
		else
			return false;	
	}
}

function OTAddMode( objtype ){
	return '';
	var fm =FindModes(objtype);
	if(fm==null){
		return '';
	}else{
		if(fm.get('addmode')==null)
			return '';
		else
			return fm.get('addmode');	
	}
}

function OTEditMode( objtype ){
	return '';
	var fm =FindModes(objtype);
	if(fm==null){
		return '';
	}else{
		if(fm.get('editmode')==null)
			return '';
		else
			return fm.get('editmode');	
	}
}

function StatusErr(sText){
	var sb = Ext.getCmp('my-status');
	sb.setStatus({
		text: sText,
		//iconCls: 'icon-bullet_red',
		clear: true // auto-clear after a set interval
	});
}

function StatusDB(sText){
	var sb = Ext.getCmp('my-status');
	sb.setStatus({
		text: sText,
		//iconCls: 'icon-bullet_database_yellow',
		clear: true // auto-clear after a set interval
	});
}

function StatusWait(sText){
	var sb = Ext.getCmp('my-status');
	sb.setStatus({
		text: sText,
		//iconCls: 'icon-bullet_yellow',
		clear: true // auto-clear after a set interval
	});
}

function StatusReady(sText){
	var sb = Ext.getCmp('my-status');
	sb.setStatus({
		text: sText,
		//iconCls: 'sicon-bullet_green',
		clear: true // auto-clear after a set interval
	});
}


function onAddTeacher(robj){
   //alert("Добваление учителя ...("+robj.store.data.length + " rows ) id=" +robj.up('form' ).activeRecord.get('id') );
  if(CheckOperation('iu_tm.edit')!=0){
		Ext.Ajax.request({
			url: rootURL+'index.php/c_v_autoiu_tmdef/newRow',
			method:  'POST',
			params: { 
			},
			success: function(response){
			var text = response.responseText;
			var res =Ext.decode(text);
			var edit = Ext.create('iu.windowObjects');
			edit.setTitle('Создание документа:Учителя и Методисты') ;
			var p=iu_tm_Panel_( res.data, false,null ) ;
			edit.add(p);
			edit.show();
			}
		});
		robj.store.load();
	}else{
			Ext.MessageBox.show({
			title:  'Контроль прав.',
			msg:    'Создание объектов не разрешено!',
			buttons: Ext.MessageBox.OK,
		   icon:   Ext.MessageBox.WARNING
			});
	}
}

function onAddMethodist(robj){
	//alert("Добваление методиста ...("+robj.store.data.length + " rows ) id=" +robj.up('form' ).activeRecord.get('id') );
	if(CheckOperation('iu_tm.edit')!=0){
		Ext.Ajax.request({
			url: rootURL+'index.php/c_v_autoiu_tmdef/newRow',
			method:  'POST',
			params: { 
			},
			success: function(response){
			var text = response.responseText;
			var res =Ext.decode(text);
			var edit = Ext.create('iu.windowObjects');
			edit.setTitle('Создание документа:Учителя и Методисты') ;
			var p=iu_tm_Panel_( res.data, false,null ) ;
			edit.add(p);
			edit.show();
			}
		});
		robj.store.load();
	}else{
			Ext.MessageBox.show({
			title:  'Контроль прав.',
			msg:    'Создание объектов не разрешено!',
			buttons: Ext.MessageBox.OK,
		   icon:   Ext.MessageBox.WARNING
			});
	}
}
function onAddMethodist2(robj){
	//alert("Добваление методиста 2 ...("+robj.store.data.length + " rows ) id=" +robj.up('form' ).activeRecord.get('id') );
	if(CheckOperation('iu_tm.edit')!=0){
		Ext.Ajax.request({
			url: rootURL+'index.php/c_v_autoiu_tmdef/newRow',
			method:  'POST',
			params: { 
			},
			success: function(response){
			var text = response.responseText;
			var res =Ext.decode(text);
			var edit = Ext.create('iu.windowObjects');
			edit.setTitle('Создание документа:Учителя и Методисты') ;
			var p=iu_tm_Panel_( res.data, false,null ) ;
			edit.add(p);
			edit.show();
			}
		});
		robj.store.load();
	}else{
			Ext.MessageBox.show({
			title:  'Контроль прав.',
			msg:    'Создание объектов не разрешено!',
			buttons: Ext.MessageBox.OK,
		   icon:   Ext.MessageBox.WARNING
			});
	}
}



 Ext.define('cmbmodel_teacher_subj',{
            extend:'Ext.data.Model',
        fields: [
			{name: 'id',type: 'string'}
            ,{name: 'iu_tmdefid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });

var cmbstore_teacher_subj = Ext.create('Ext.data.Store', {
    model:'cmbmodel_teacher_subj',
    autoLoad:false,
    autoSync:false,
    proxy:{
        type:'ajax',
        url:rootURL+'index.php/wf/getTeacher',
        reader:{
            type:'json', root:'data', successProperty:'success', messageProperty:'msg'
        },
        listeners:{
            exception:function (proxy, response, operation) {
            /*    Ext.MessageBox.show({
                    title:'REMOTE EXCEPTION',
                    msg:operation.getError(),
                    icon:Ext.MessageBox.ERROR,
                    buttons:Ext.Msg.OK
                }); */
            }
        }
    }
});

var cmbstore_metodist_subj = Ext.create('Ext.data.Store', {
    model:'cmbmodel_teacher_subj',
    autoLoad:false,
    autoSync:false,
    proxy:{
        type:'ajax',
        url:rootURL+'index.php/wf/getTeacher',
        reader:{
            type:'json', root:'data', successProperty:'success', messageProperty:'msg'
        },
        listeners:{
            exception:function (proxy, response, operation) {
            /*    Ext.MessageBox.show({
                    title:'REMOTE EXCEPTION',
                    msg:operation.getError(),
                    icon:Ext.MessageBox.ERROR,
                    buttons:Ext.Msg.OK
                }); */
            }
        }
    }
});
function resizeImg(img,sz){
	with (img) {
		if (offsetWidth <offsetHeight) 
		style.height = sz; 
		else style.width = sz; 
		style.visibility ='visible';
	}
};



///////////////// change password //////////////////////

Ext.define('Form_sp_password', 
	{
		extend:  'Ext.form.Panel',
		alias: 'widget.f_sp_password',
		defaultType:'textfield',
		layout:'absolute',
		initComponent:function () 
			{
				this.addEvents('create');
				Ext.apply(this, 
					{
			  
						url:'index.php/app/setSPPassword',
						layout:'absolute',
						items:[
							{
								fieldLabel:'Старый пароль',
								name:'oldPassword',
								itemId:'oldPassword',
								//inputType:'password',
								allowBlank:false,
								value:'',
								x:5,
								y:5,
								labelWidth :170,
								minWidth: 270,
								width: 270,
								maxWidth: 270 //,
								//minLength:8,
								//minLengthText : 'Длинна пароля не менее 8 символов'
							}
							,
							{
								fieldLabel:'Новый пароль',
								name:'newPassword',
								itemId:'newPassword',
								//inputType:'password',
								allowBlank:false,
								value:'',
								x:5,
								y:35,
								labelWidth :170,
								minWidth: 270,
								width: 270,
								maxWidth: 270,
								minLength:8,
								minLengthText : 'Длинна пароля не менее 8 символов'
							},
							{
								fieldLabel:'Подтверждение пароля',
								name:'compPassword',
								itemId:'compPassword',
								inputType:'password',
								allowBlank:false,
								value:'',
								x:5,
								y:70,
								labelWidth :170,
								minWidth: 270,
								width: 270,
								maxWidth: 270,
								minLength:8,
								minLengthText : 'Длинна пароля не менее 8 символов'
							}
							
						],
		   
						dockedItems: 
						[
							{
							xtype:  'toolbar',
							dock:   'bottom',
							ui:     'footer',
							items: ['->', 
								{
									iconCls:  'icon-accept',
									itemId:  'save',
									text:   'Сохранить',
									disabled: false,
									scope:  this,
									handler:function()
									{
										var form = this.getForm();
										if(form.isValid()){
										    if(form._fields.items[2].getValue()==form._fields.items[1].getValue()){
												form.submit(
													{
														url: 'index.php/app/setSPPassword',
														waitMsg: 'Сохранение...',
														success: function(f,response){
															var text = response.result.msg;
															//var res =Ext.decode(text);
															if(text=="OK"){
																Ext.MessageBox.show({
																title:  'Подтверждение',
																msg:    'Изменения сохранены',
																buttons: Ext.MessageBox.OK,
																icon:   Ext.MessageBox.INFO
																});
																var wn = this.form.owner.ownerCt;
																wn.close();
																spData.load();
															}else{
																Ext.MessageBox.show({
																	title:  'Ошибка',
																	msg:    text,
																	buttons: Ext.MessageBox.OK,
																	icon:   Ext.MessageBox.ERROR
																});
															}
														}
														,
														failure: function(f,response) {
															var text = response.result.msg;
															Ext.MessageBox.show({
															title:  'Ошибка',
															msg:    text,
															buttons: Ext.MessageBox.OK,
															icon:   Ext.MessageBox.ERROR
															});
														}

													}
												);
											}else{
												Ext.MessageBox.show({
													title:  'Ошибка',
													msg:    'Новый пароль не совпадает с подтверждением пароля',
													buttons: Ext.MessageBox.OK,
													icon:   Ext.MessageBox.ERROR
													});
											}
										}
									}
								}, 
								{
									iconCls:  'icon-cancel',
									text:   'Закрыть',
									scope:  this,
									handler : this.onReset
								}
							]
							}
						] // dockedItems
					}
				); //Ext.apply
				this.callParent();
			}, //initComponent 
	   
		onReset: function()
			{
				 this.ownerCt.close();
			}
	}
); // 'Ext.Define

Ext.define('EditWindow_sp_password',{
    extend:  'Ext.window.Window',
constrainHeader:true,
    height: 160,
    width: 300,
    layout:  'fit',
    autoShow: true,
    modal: true,
    closeAction: 'destroy',
    iconCls:  'icon-building_key',
    title:  'Сменить пароль',
    items:[
		{
			xtype:'f_sp_password'
		}
	]
	}
);

var defaultMenuDisabled=false;
var defaultMenuHidden=false;
//////////////////////////////////////////////////////