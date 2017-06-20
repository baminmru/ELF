
Ext.Loader.setConfig({
  enabled: true
 });
 Ext.Loader.setPath('Ext.ux', '../ux/');
 
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
  'Ext.ux.CheckColumn', 
  'Ext.ux.grid.FiltersFeature',
  'Ext.ux.PreviewPlugin',
  'Ext.toolbar.Paging',
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


 
Ext.define('application_info',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'info',type: 'string'}
        ]
});
var app_info;

 Ext.define('application_actions',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'accesible',type: 'integer'}
            ,{name: 'menuname',type: 'string'}
            ,{name: 'menucode',type: 'string'}
        ]
});
var app_actions;
	
 Ext.define('application_operations',{
		extend:'Ext.data.Model',
	fields: [
		{name: 'allowaction',type: 'integer'}
		,{name: 'name',type: 'string'}
	]
});

var app_operations;


 Ext.define('application_roles',{
            extend:'Ext.data.Model',
        fields: [
            {name:'name', type: 'string'}
        ]
    });
	
var app_roles;


Ext.onReady(function () {
    Ext.tip.QuickTipManager.init();
    login_win.show();
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
	EnableActions();
}



var cardNav = function (name, incr, maxtab) {
    var l = Ext.getCmp(name).getLayout();
    var i = l.activeItem.id.split(name + '-')[1];
    var next = parseInt(i, 10) + incr;
    l.setActiveItem(next);
    Ext.getCmp(name + '-prev').setDisabled(next === 0);
    Ext.getCmp(name + '-next').setDisabled(next === maxtab);
}


var menuPanel;
var leftPanel;
var contentPanel;

function RoleSelect() {
   
   
   var app_role_loaded=false;
   
   app_roles = Ext.create('Ext.data.Store', {
        model:'application_roles',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/app/getRoleList',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){
			app_roles_loaded =true;

			
			if(app_roles.count()==1){
	
				/*
					Ext.MessageBox.show({
					title:  'Информация',
					 msg:    'Вы работаете в роли:' + app_roles.getAt(0).get('name'),
					buttons: Ext.MessageBox.OK,
					 icon:   Ext.MessageBox.INFO
					});
					*/
					Ext.Ajax.request({
							url: rootURL+'index.php/app/setRole',
							method:  'POST',
							params: { 
								RoleName: app_roles.getAt(0).get('name') 
								}
							, success: function(response){
								var text = response.responseText;
								var res =Ext.decode(text);
								MyInit();
						  }
					});
			}
			
			if(app_roles.count()==0){
				
					combo_StoreLoaded=true;
					
					Ext.MessageBox.show({
					title:  'Информация',
					 msg:    'Извините, Вам не разрешена работа с данным приложением.',
					buttons: Ext.MessageBox.OK,
					 icon:   Ext.MessageBox.ERROR
					});
					
					document.location=document.location;
			}
			if(app_roles.count()>1){
			
				combo_StoreLoaded=true;
				showSelectRoles();
			}
	   
	   }
       }
    });
	
	app_roles.load();
  
}

var actionB2B;
var actionB2C;
var actionB2S;
var actionB2P;
var actionB2Z;
var actionB2FR;
var app_operations_loaded=false;
var app_actions_loaded=false;
var inClick = false;

function MyInit(){


	Ext.Ajax.request({
				url: rootURL+'index.php/app/martlogin',
				method:  'POST',
				params: { 
					
					}
				, success: function(response){
				var text = response.responseText;
				var res =Ext.decode(text);
				
				  }
	});


    combo_pbar = Ext.create('Ext.ProgressBar', {
        id:'combo_pbar',
        width:300,
        renderTo:'loading'
    });

   
  
 
	app_actions = Ext.create('Ext.data.Store', {
        model:'application_actions',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/app/getActions',
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

	app_operations = Ext.create('Ext.data.Store', {
        model:'application_operations',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/app/getOperations',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){app_operations_loaded =true;combo_StoreLoaded=true;}
       }
    });
	combo_Stores.push(app_operations);
	
	
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
	    comp.setText(app_info.getAt(0).get("info"));
		window.document.title=app_info.getAt(0).get("info");
	   }
       }
    });
	combo_Stores.push(app_info);
	//combo_Stores.push(cmbstore_bfrm_struct2);
	

	
	function MakeExit(btn){
	if(btn=="yes"){
        Ext.Ajax.request({
							url: rootURL+'index.php/app/logout',
							method:  'POST',
							success: function(response){
								app_info.load();
								document.location=document.location;
							}
							});
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
	
	//////////////////////////////////////////////////////  
	
	
	
	var actionREPORT1 = Ext.create('Ext.Action', {
		itemId:'actionREPORT1',
        text: 'По объектам',
        iconCls: 'icon-report_magnify',
		disabled:false,
        handler: function(){
			if(inClick) return; inClick=true;
			var o = contentPanel.down('#dReportsCustom1');
			if(o==null){
				 Ext.Ajax.request({
				url: '/yf/?r=dReportsMaster/index/type/2',
				success: function(response, opts) {
					var j = Ext.decode(response.responseText);
					j.itemId='dReportsCustom1';
					j.iconCls='icon-report_magnify';
					j.title='Отчеты по объектам';
					j.closable=true;
					var x=contentPanel.add(j);
					contentPanel.setActiveTab(x);
					 inClick=false;
				},
				failure: function(response, opts) {
					inClick=false;
				}
			   });
			}else{
				contentPanel.setActiveTab(o);
				 inClick=false;
			}
			
        }
    });
	var actionREPORT2 = Ext.create('Ext.Action', {
		itemId:'actionREPORT2',
        text: 'Финансовые',
        iconCls: 'icon-report_add',
		disabled:false,
        handler: function(){
			if(inClick) return; inClick=true;
			var o = contentPanel.down('#dReportsCustom2');
			if(o==null){
				 Ext.Ajax.request({
				url: '/yf/?r=dReportsMaster/index/type/1',
				success: function(response, opts) {
					var j = Ext.decode(response.responseText);
					j.itemId='dReportsCustom2';
					j.iconCls='icon-report_add';
					j.title='Финансовые отчеты';
					j.closable=true;
					var x=contentPanel.add(j);
					contentPanel.setActiveTab(x);
					 inClick=false;
				},
				failure: function(response, opts) {
					inClick=false;
				}
			   });
			 }else{
				contentPanel.setActiveTab(o);
				 inClick=false;
			}
			
        }
    });
	
	var actionREPORT3 = Ext.create('Ext.Action', {
		itemId:'actionREPORT3',
        text: 'По сотрудникам',
        iconCls: 'icon-report_user',
		disabled:false,
        handler: function(){
			if(inClick) return; inClick=true;
			var o = contentPanel.down('#dReportsCustom3');
			if(o==null){
				 Ext.Ajax.request({
				url: '/yf/?r=dReportsMaster/index/type/3',
				success: function(response, opts) {
					var j = Ext.decode(response.responseText);
					j.itemId='dReportsCustom3';
					j.iconCls='icon-report_user';
					j.title='Отчеты по сотрудникам';
					j.closable=true;
					var x=contentPanel.add(j);
					contentPanel.setActiveTab(x);
					 inClick=false;
				},
				failure: function(response, opts) {
					inClick=false;
				}
			   });
			}else{
				contentPanel.setActiveTab(o);
				 inClick=false;
			}
			
        }
    });
	
	var actionREPORT4 = Ext.create('Ext.Action', {
		itemId:'actionREPORT4',
        text: 'Диспетчера',
        iconCls: 'icon-report_picture',
		disabled:false,
        handler: function(){
			if(inClick) return; inClick=true;
			var o = contentPanel.down('#dReportsCustom4');
			if(o==null){
				 Ext.Ajax.request({
				url: '/yf/?r=dReportsMaster/index/type/4',
				success: function(response, opts) {
					var j = Ext.decode(response.responseText);
					j.itemId='dReportsCustom4';
					j.iconCls='icon-report_picture';
					j.title='Отчеты диспетчера';
					j.closable=true;
					var x=contentPanel.add(j);
					contentPanel.setActiveTab(x);
					 inClick=false;
				},
				failure: function(response, opts) {
					inClick=false;
				}
			   });
			}else{
				contentPanel.setActiveTab(o);
				 inClick=false;
			}
		
        }
    });
	
	
	
	

	
	
	var actionPublishObj = Ext.create('Ext.Action', {
		itemId:'actionPublishObj',
        text: 'Подать объект в рекламу',
        iconCls: 'icon-door',
		disabled:false,
        handler: function(){
			if(inClick) return; inClick=true;
			var o = contentPanel.down('#PublishObj');
			if(o==null){
				  Ext.Ajax.request({
				url: '/yf/index.php?r=exportPlacement/edit',
				success: function(response, opts) {
				 var j = Ext.decode(response.responseText);
				 j.itemId='PublishObj';
				 j.iconCls='icon-door';
				 j.title='Подать объект в рекламу';
				 j.closable=true;
				 var x = contentPanel.add(j);
				 contentPanel.setActiveTab(x);
				  inClick=false;
				},
				failure: function(response, opts) {
					inClick=false;
				}
			   });
			}else{
				contentPanel.setActiveTab(o);
				 inClick=false;
			}
			
			
        }
    });
	
	var actionSendMail = Ext.create('Ext.Action', {
		itemId:'actionSendMail',
        text: 'Сообщение разработчикам',
        iconCls: 'icon-email',
		disabled:false,
        handler: function(){
			if(inClick) return; inClick=true;
		
			  Ext.Ajax.request({
				url:    rootURL+'index.php/c_usermail/form',
				method:  'POST',
				params: { 
					type: 'message',
				},
				success: function(response, opts) 
				{
					var obj = Ext.decode(response.responseText);
					obj.constrainHeader=true;
					var printWin = Ext.create('Ext.window.Window', obj);
					printWin.show();
					inClick=false;
				},
				failure: function(response, opts) {
					inClick=false;
				
				}
			});
				
				
			
		
			
			
        }
    });
	
	
	var actionReclamaURL = Ext.create('Ext.Action', {
		itemId:'actionReclamaURL',
        text: 'Цены на рекламу',
        iconCls: 'icon-door',
		disabled:false,
        handler: function(){
			if(inClick) return; inClick=true;
			var o=contentPanel.down('#exportBlockCost');
			
			if(o==null){
			
				
				
				Ext.Ajax.request({
				url: '/yf/index.php?r=exportBlockCost',
				success: function(response, opts) {
				
					var mypanel;
					mypanel = Ext.create('Ext.form.Panel', {
					closable:true,
					collapsible:false,
					layout:'fit',
					itemId:'exportBlockCost',
					id:'exportBlockCost',
					title:'Цены на рекламу',
					iconCls:'icon-door'
					}); //Ext.Create
			
					var xx = contentPanel.add(mypanel);
				 
					 var j = Ext.decode(response.responseText);
					 mypanel.add(j);
					
					 
					 contentPanel.setActiveTab(xx);
					
				  inClick=false;
				},
				failure: function(response, opts) {
					inClick=false;
				
				}
			   });
			}else{
				contentPanel.setActiveTab(o);
				 inClick=false;
			}
			
			
        }
    });
	
	var actionReclamaOBJ = Ext.create('Ext.Action', {
		itemId:'actionReclamaOBJ',
        text: 'Подтвердить рекламу',
        iconCls: 'icon-television',
		disabled:false,
        handler: function(){
		
		if(inClick) return; inClick=true;
		 var o=contentPanel.down('#exportPlacement');
			
			if(o==null){
				  Ext.Ajax.request({
				url: '/yf/index.php?r=exportPlacement/index2',
				success: function(response, opts) {
				 var j = Ext.decode(response.responseText);
				 j.itemId='exportPlacement';
				 j.iconCls='icon-television';
				 var x=contentPanel.add(j);
				 contentPanel.setActiveTab(x);
				  inClick=false;
				
				},
				failure: function(response, opts) {
					inClick=false;
				}
			   });
			
			}else{
				contentPanel.setActiveTab(o);
				 inClick=false;
			}
			
			
			
        }
    });
	
	
	var actionExportSheduler = Ext.create('Ext.Action', {
		itemId:'actionExportSheduler',
        text: 'Выгрузка файлов',
        iconCls: 'icon-script_save',
		disabled:false,
        handler: function(){
		   if(inClick) return; inClick=true;
		   var o=contentPanel.down('#shedulerTab2');
			
			if(o==null){
				 Ext.Ajax.request({
				url: '/yf/index.php?r=exportSheduler/index2',
				success: function(response, opts) {
				 var j = Ext.decode(response.responseText);
				 j.itemId='shedulerTab2';
				 j.iconCls='icon-script_save';
				 var x=contentPanel.add(j);
				 contentPanel.setActiveTab(x);
				  inClick=false;
				
				},
				failure: function(response, opts) {
					inClick=false;
				}
			   });
			 }else{
				contentPanel.setActiveTab(o);
				 inClick=false;
			}
			
	
        }
    });
	
	
	var actionReestr = Ext.create('Ext.Action', {
		itemId:'actionReestr',
        text: 'Реестр договоров',
        iconCls: 'icon-folder_bookmark',
		disabled:false,
        handler: function(){
		   if(inClick) return; inClick=true;
		   var o=contentPanel.down('#Reestr');
			
			if(o==null){
				 Ext.Ajax.request({
				url: '/yf/?r=exportBlockParams',
				success: function(response, opts) {
				 var j = Ext.decode(response.responseText);
				 j.itemId='Reestr';
				 j.iconCls='icon-folder_bookmark';
				 j.title='Реестр договоров';
				 var x=contentPanel.add(j);
				 contentPanel.setActiveTab(x);
				  inClick=false;
				
				},
				failure: function(response, opts) {
					inClick=false;
				}
			   });
			 }else{
				contentPanel.setActiveTab(o);
				 inClick=false;
			
			}
			
        }
    });
	 
	 var actionUsersAccounts = Ext.create('Ext.Action', {
		itemId:'actionUsersAccounts',
        text: 'Счета агентов',
        iconCls: 'icon-money_dollar',
		disabled:false,
        handler: function(){
			if(inClick) return; inClick=true;
		   var o= contentPanel.down('#paymentTab');
			
			if(o==null){
				Ext.Ajax.request({
				url: '/yf/index.php?r=usersAccounts',
				success: function(response, opts) {
				 var j = Ext.decode(response.responseText);
				 j.itemId='paymentTab';
				 j.iconCls='icon-money_dollar';
				 var x=contentPanel.add(j);
				 contentPanel.setActiveTab(x);
				  inClick=false;
				},
				failure: function(response, opts) {
					inClick=false;
				}
			   });
			 }else{
				contentPanel.setActiveTab(o);
				 inClick=false;
			}
			
			
        }
    });
	
	
	 var actionStartPage = Ext.create('Ext.Action', {
		itemId:'actionStartPage',
        text: 'Стартовая страница',
        iconCls: 'icon-star_gold',
		disabled:false,
        disabled:false,
             handler: function(){
             
				 
			var j=Ext.getCmp('myStartPage');
			
			if(j==null){
				j=StartPage();
				j.iconCls='icon-star_gold';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
             }
         });
		 
		var actionRolePage = Ext.create('Ext.Action', {
		itemId:'actionRolePage',
        text: 'Настройка ролей',
        iconCls: 'icon-user_home',
		disabled:false,
        disabled:false,
             handler: function(){
             
				 
			var j=Ext.getCmp('myRolePage');
			
			if(j==null){
				j=RolePage();
				j.iconCls='icon-user_home';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
             }
         });
		 
	
	

	var actionInfo = Ext.create('Ext.Action', {
		itemId:'actionInfo',
        text: 'Обновить состояние',
        iconCls: 'icon-arrow_refresh',
		disabled:false,
        handler: function(){
           app_info.load();
		   EnableActions();
			
        }
    });

  
	
	var actionB2DEV = Ext.create('Ext.Action', {
	 itemId:'actionB2DEV',
     text:           'Строительные компании',
     iconCls:        'icon-bricks',
	 disabled:false,
             handler: function(){
                 //contentPanel.add(B2DEV_Jrnl());
				 
				 var j=Ext.getCmp('b2dev_jrnl');
			//alert(j);
			if(j==null){
				j=B2DEV_Jrnl();
				j.iconCls='icon-bricks';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
             }
         });
		 
		 
		 
		 
	actionB2P = Ext.create('Ext.Action', {
		 itemId:'actionB2P',
		 text:           'Квартиры в новостройках',
		 iconCls:        'icon-shape_square',
		 disabled:false,
		 handler: function(){
						
					var j=Ext.getCmp('b2p_jrnl');
					
					if(j==null){
						j=B2P_Jrnl();
						j.iconCls=   'icon-shape_square';
						contentPanel.add(j);
						contentPanel.setActiveTab(j);
					}
					else{
						contentPanel.setActiveTab(j);
					}
             }
         });
		 
		 
		actionB2S = Ext.create('Ext.Action', {
		itemId:'actionB2S',
        text: 'Объекты вторичного рынка',
        iconCls: 'icon-package',
		disabled:false,
        handler: function(){
			
           
			
			var j=Ext.getCmp('b2s_jrnl');
			
			if(j==null){
				j=B2S_Jrnl();
				j.iconCls= 'icon-package';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
        }
    });
	
	
	
	actionB2Z = Ext.create('Ext.Action', {
		itemId:'actionB2Z',
        text: 'Загородные объекты',
        iconCls: 'icon-house',
		disabled:false,
        handler: function(){
            //contentPanel.add(B2Z_Jrnl());
			
			var j=Ext.getCmp('b2z_jrnl');
			//alert(j);
			if(j==null){
				j=B2Z_Jrnl();
				j.iconCls= 'icon-house';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
        }
    });
	
	var actionB2QRY = Ext.create('Ext.Action', {
		itemId:'actionB2QRY',
        text: 'Заявки от клиентов',
        iconCls: 'icon-telephone_red',
		disabled:false,
        handler: function(){
       
			
			var j=Ext.getCmp('b2qry_jrnl_disp');
			//alert(j);
			if(j==null){
				j=B2QRY_JrnlDISP();
				j.iconCls= 'icon-telephone_red';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
        }
    });
	
	var actionB2MYQRY = Ext.create('Ext.Action', {
		itemId:'actionB2MYQRY',
        text: 'Заявки от клиентов',
        iconCls: 'icon-flag_red',
		disabled:false,
        handler: function(){
         
			
			var j=Ext.getCmp('b2qry_jrnl');
			//alert(j);
			if(j==null){
				j=B2QRY_Jrnl();
				j.iconCls= 'icon-flag_red';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
        }
    });
	
	
	var actionB2CALL = Ext.create('Ext.Action', {
		itemId:'actionB2CALL',
        text: 'Звонки по объектам',
        iconCls: 'icon-telephone',
		disabled:false,
        handler: function(){
            //contentPanel.add(B2CALL_Jrnl());
			
			var j=Ext.getCmp('b2call_jrnl_disp');
			//alert(j);
			if(j==null){
				j=B2CALL_JrnlDISP();
				j.iconCls= 'icon-telephone';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
        }
    });
	
	var actionTerminal = Ext.create('Ext.Action', {
		itemId:'actionTerminal',
        text: 'Терминал диспетчера',
        iconCls: 'icon-computer_off',
		disabled:false,
        handler: function(){
            //contentPanel.add(B2CALL_Jrnl());
			
			var j=Ext.getCmp('terminal_jrnl');
			//alert(j);
			if(j==null){
				j=terminal_Jrnl();
				j.iconCls= 'icon-computer_off';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
        }
    });
	
	
	var actionB2MYCALL = Ext.create('Ext.Action', {
		itemId:'actionB2MYCALL',
        text: 'Звонки по объектам',
        iconCls: 'icon-flag_blue',
		disabled:false,
        handler: function(){
            //contentPanel.add(B2CALL_Jrnl());
			
			var j=Ext.getCmp('b2call_jrnl');
			//alert(j);
			if(j==null){
				j=B2CALL_Jrnl();
				j.iconCls= 'icon-flag_blue';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
        }
    });
	
	actionB2FR = Ext.create('Ext.Action', {
		itemId:'actionB2FR',
        text: 'Зарубежные объекты',
        iconCls: 'icon-world',
		disabled:false,
        handler: function(){
            //contentPanel.add(B2FR_Jrnl());
			var j=Ext.getCmp('b2fr_jrnl');
			//alert(j);
			if(j==null){
				j=B2FR_Jrnl();
				j.iconCls='icon-world';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
        }
    }); 
	
	  actionB2B = Ext.create('Ext.Action', {
			 itemId:'actionB2B',
			 text:           'Жилые комплексы',
			 iconCls:        'icon-brick',
			 disabled:false,
             handler: function(){
       
			var j=Ext.getCmp('b2b_jrnl');
		
			if(j==null){
				j=B2B_Jrnl();
				j.iconCls='icon-brick';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
             }
         });
	 
	actionB2C = Ext.create('Ext.Action', {
		 itemId:'actionB2C',
		 text:           'Коммерческие объекты',
		 iconCls:        'icon-lorry',
		 disabled:false,
             handler: function(){
           
			var j=Ext.getCmp('b2c_jrnl');
			if(j==null){
				j=B2C_Jrnl();
				j.iconCls='icon-lorry';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
             }
         });
		 
		 
		 
		 
	// витрина
	var actionMartB2P = Ext.create('Ext.Action', {
		 itemId:'actionMartB2P',
		 text:           'Квартиры в новостройках',
		 iconCls:        'icon-shape_square_link',
		 disabled:false,
             handler: function(){
            
			var j=Ext.getCmp('b2p_mart_jrnl');
		
			if(j==null){
				j=B2P_mart_Jrnl();
				j.iconCls=   'icon-shape_square_link';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
             }
         });
		 
		 
		 var actionMartB2S = Ext.create('Ext.Action', {
		itemId:'actionMartB2S',
        text: 'Объекты вторичного рынка',
        iconCls: 'icon-package_link',
		disabled:false,
        handler: function(){
			
           
			
			var j=Ext.getCmp('b2s_mart_jrnl');
			
			if(j==null){
				j=B2S_mart_Jrnl();
				j.iconCls= 'icon-package_link';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
        }
    });
	
	
	
	var actionMartB2Z = Ext.create('Ext.Action', {
		itemId:'actionMartB2Z',
        text: 'Загородные объекты',
        iconCls: 'icon-house_link',
		disabled:false,
        handler: function(){
            //contentPanel.add(B2Z_mart_Jrnl());
			
			var j=Ext.getCmp('b2z_mart_jrnl');
			//alert(j);
			if(j==null){
				j=B2Z_mart_Jrnl();
				j.iconCls= 'icon-house_link';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
        }
    });
	
	var actionMartB2FR = Ext.create('Ext.Action', {
		itemId:'actionMartB2FR',
        text: 'Зарубежные объекты',
        iconCls: 'icon-world_link',
		disabled:false,
        handler: function(){
            //contentPanel.add(B2FR_mart_Jrnl());
			var j=Ext.getCmp('b2fr_mart_jrnl');
			//alert(j);
			if(j==null){
				j=B2FR_mart_Jrnl();
				j.iconCls='icon-world_link';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
        }
    }); 
	var actionMartB2B = Ext.create('Ext.Action', {
			 itemId:'actionMartB2B',
			 text:           'Жилые комплексы',
			 iconCls:        'icon-brick_link',
			 disabled:false,
             handler: function(){
       
			var j=Ext.getCmp('b2b_mart_jrnl');
		
			if(j==null){
				j=B2B_mart_Jrnl();
				j.iconCls='icon-brick_link';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
             }
         });
		 
		var actionMartB2C = Ext.create('Ext.Action', {
		 itemId:'actionMartB2C',
		 text:           'Коммерческие объекты',
		 iconCls:        'icon-lorry_link',
		 disabled:false,
             handler: function(){
           
			var j=Ext.getCmp('b2c_mart_jrnl');
			if(j==null){
				j=B2C_mart_Jrnl();
				j.iconCls='icon-lorry_link';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
             }
         });	
	
	// справочники
	var actionB2D = Ext.create('Ext.Action', {
	itemId:'actionB2D',
        text: 'Справочник листинга',
        iconCls: 'icon-book_tabs',
		disabled:false,
        handler: function(){
		
		
			var j=Ext.getCmp('b2d');
	
			if(j==null){
				j=B2D_Panel_('73760978-A708-479A-A2EF-6F1E4E6DB7DA', true);
				j.iconCls='icon-book_tabs';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
           
        }
    });
	
	var actionB2DUTY = Ext.create('Ext.Action', {
	itemId:'actionB2DUTY',
        text: 'Назначить дежурных',
        iconCls: 'icon-bell',
		disabled:false,
        handler: function(){
		
		
			var j=Ext.getCmp('b2duty');
	
			if(j==null){
				j=B2DUTY_Panel_('91D1E3F2-57F0-4032-A3CB-416931018787', true);
				j.iconCls='icon-bell';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
           
        }
    });
	
	
	var actionB2ACTUAL = Ext.create('Ext.Action', {
	itemId:'actionB2ACTUAL',
        text: 'Сроки актуальности',
        iconCls: 'icon-clock_red',
		disabled:false,
        handler: function(){
		
		
			var j=Ext.getCmp('b2actual');
	
			if(j==null){
				j=B2ACTUAL_Panel_('837928FB-B6B3-41E4-BBCA-334821AE1F0F', true);
				j.iconCls='icon-clock_red';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
           
        }
    });
	
	
	/*
	var actionBR_DIC = Ext.create('Ext.Action', {
	    itemId:'actionBR_DIC',
        text: 'Справочник по рекламе',
        iconCls: 'icon-book',
		disabled:false,
        handler: function(){
		
		
			var j=Ext.getCmp('br_dic');
	
			if(j==null){
				j=BR_DIC_Panel_('F191F749-F6BB-4517-A170-124357B01CF3', true);
				j.iconCls='icon-book';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
           
        }
    });
	*/
	
	var actionBFD = Ext.create('Ext.Action', {
	itemId:'actionBFD',
        text: 'Справочники общие',
        iconCls: 'icon-book_red',
		disabled:false,
        handler: function(){
		
		
			var j=Ext.getCmp('bfd');
	
			if(j==null){
				j=BFD_Panel_('7CFF66A3-CB6C-47A9-BA4D-DA816766196B', true);
				j.conCls='icon-book_red';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
           
        }
    });
	

	
	var actionB2G = Ext.create('Ext.Action', {
	itemId:'actionB2G',
        text: 'Справочник адресной подсистемы',
        iconCls: 'icon-book_addresses',
		disabled:false,
        handler: function(){

			var j=Ext.getCmp('b2g');
	
			if(j==null){
				j=B2G_Panel_('3422A02F-44A9-448C-98F6-6387B541D772', true);
				j.iconCls='icon-book_addresses';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
           
        }
    });
	/*
	 var actionBFIRM = Ext.create('Ext.Action', {
	 itemId:'actionBFIRM',
			 text:           'О компании',
			 iconCls:        'icon-chart_organisation',
			 disabled:false,
             handler: function(){
			 
			var j=Ext.getCmp('bfirm_jrnl');
		
			if(j==null){
				j=BFIRM_Jrnl();
				j.iconCls='icon-chart_organisation';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
             }
         });
		 */
		 
		 var actionBFIRM = Ext.create('Ext.Action', {
	itemId:'actionBFIRM',
        text: 'О компании',
        iconCls: 'icon-chart_organisation',
		disabled:false,
        handler: function(){
		
		
			var j=Ext.getCmp('bfirm');
	
			if(j==null){
				j=BFIRM_Panel_(firmID, true);
				j.iconCls='icon-chart_organisation';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
           
        }
    });
		 
	var actionBUSR = Ext.create('Ext.Action', {
	itemId:'actionBUSR',
     text:           'Cотрудники',
     iconCls:        'icon-chart_org_inverted',
	 disabled:false,
             handler: function(){
                 //contentPanel.add(BUSR_Jrnl());
				 var j=Ext.getCmp('busr_jrnl');
			//alert(j);
			if(j==null){
				j=BUSR_Jrnl();
				j.iconCls='icon-chart_org_inverted';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
             }
         });
	
	var actionB2CL = Ext.create('Ext.Action', {
	itemId:'actionB2CL',
     text:           'Клиент',
     iconCls:        'icon-telephone',
	 disabled:false,
             handler: function(){
                 //contentPanel.add(B2CL_Jrnl());
				 var j=Ext.getCmp('b2cl_jrnl');
			//alert(j);
			if(j==null){
				j=B2CL_Jrnl();
				j.iconCls='icon-telephone';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
             }
         });
		 
		 
	// реклама	 
	
	/*	 
	 var actionBR_MART = Ext.create('Ext.Action', {
	 itemId:'actionBR_MART',
     text:           'Рекламная площадка',
     iconCls:        'icon-finger_point',
	 disabled:false,
             handler: function(){
                 //contentPanel.add(BR_MART_Jrnl());
				 var j=Ext.getCmp('br_mart_jrnl');
			//alert(j);
			if(j==null){
				j=BR_MART_Jrnl();
				j.iconCls='icon-finger_point';
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
             }
         });
		 
		var actionBR_TRF = Ext.create('Ext.Action', {
		itemId:'actionBR_TRF',
		 text:           'Тарифы',
		 iconCls:        'icon-calculator',
		 disabled:false,
				 handler: function(){
					 //contentPanel.add(BR_TRF_Jrnl());
						 var j=Ext.getCmp('br_trf_jrnl');
				//alert(j);
				if(j==null){
					j=BR_TRF_Jrnl();
					j.iconCls='icon-calculator';
					contentPanel.add(j);
					contentPanel.setActiveTab(j);
				}
				else{
					contentPanel.setActiveTab(j);
				}
				 }
			 });
    
	*/
	
		 
		  var actionROLES = Ext.create('Ext.Action', {
			 itemId:'actionROLES',
			 text:           'Роли',
			 iconCls:        'icon-user_home',
			 disabled:false,
             handler: function(){
				 var j=Ext.getCmp('roles_jrnl');
  				if(j==null){
					j=ROLES_Jrnl();
					j.iconCls='icon-user_home';
					contentPanel.add(j);
					contentPanel.setActiveTab(j);
				}
				else{
					contentPanel.setActiveTab(j);
				}
             }
         });
		 
		 var actionMTZwp = Ext.create('Ext.Action', {
			 itemId:'actionMTZwp',
			 text:           'Приложения',
			 iconCls:        'icon-application_osx_start',
			 disabled:false,
             handler: function(){
				 var j=Ext.getCmp('mtzwp_jrnl');
  				if(j==null){
					j=MTZwp_Jrnl();
					j.iconCls='icon-application_osx_start';
					contentPanel.add(j);
					contentPanel.setActiveTab(j);
				}
				else{
					contentPanel.setActiveTab(j);
				}
             }
         });
		 
		 var actionMTZUsers = Ext.create('Ext.Action', {
			itemId:'actionMTZUsers',
			text: 'Справочник акаунтов',
			iconCls: 'icon-user',
			disabled:false,
			handler: function(){

			var j=Ext.getCmp('mtzusers');
	
			if(j==null){
				j=MTZUsers_Panel_('{E0FB5E85-050E-4322-8505-9E0CA132E901}', true);
				j.iconCls='icon-user';
				
				contentPanel.add(j);
				contentPanel.setActiveTab(j);
			}
			else{
				contentPanel.setActiveTab(j);
			}
           
        }
    });

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
                    menu:[  actionStartPage,actionB2MYCALL,actionB2MYQRY,actionSendMail,actionEXIT] 
				
				},
				{
					itemId:'actionBook',
				    text:'Бухгалтер',
                    iconCls:'icon-book_open',
                    menu:[actionUsersAccounts,  actionReclamaURL] 
				
				},
				{
					itemId:'actionReports',
				    text:'Отчеты',
                    iconCls:'icon-report_disk',
                    menu:[actionREPORT1,  actionREPORT2,actionREPORT3,actionREPORT4] 
				
				},
				{
					itemId:'actionDisp',
				    text:'Диспетчер',
                    iconCls:'icon-telephone',
                    menu:[  actionTerminal,actionB2CALL,actionB2QRY,actionB2DUTY] 
				
				},
                {
					itemId:'actionListings',
                    text:'Мои объекты',
                    iconCls:'icon-house',
                    menu:[ /*actionB2B, */  actionB2P, actionB2S, actionB2Z,actionB2C, actionB2FR ] 
					},
					{
					itemId:'actionMartListings',
                    text:'Поиск объектов',
                    iconCls:'icon-house_link',
                    menu:[  actionB2B,  actionMartB2P, actionMartB2S, actionMartB2Z,actionMartB2C, actionMartB2FR ] 
					},
                {
					itemId:'actionReklama',
                    text:'Реклама',
                    iconCls:'icon-television',
                    menu:[ actionPublishObj,actionReclamaOBJ, actionExportSheduler,actionReestr] 
                }, 
              
				{
					itemId:'actionSubjects',
                    text:'Фирма',
                    iconCls:'icon-computer',
                    menu:[  actionBFIRM,  actionBUSR , actionRolePage, actionB2ACTUAL ] 
                },
				 {
					itemId:'actionDict',
                    text:'Справочники',
                    iconCls:'icon-book_open',
                    menu:[actionBFD,actionB2D,actionB2DEV   ] 
                }, 
			
				{
					itemId:'sessionInfo',
					iconCls:'icon-information',
					menu:[ actionInfo]
				}
				
            ]
        }
    });
	
	leftPanel=new Ext.panel.Panel(
	{
                region: 'west',
                stateId: 'navigation-panel',
                id: 'leftPanel', 
				itemId: 'leftPanel', 
                title: 'Навигация',
                split: true,
                width: 200,
                minWidth: 175,
                maxWidth: 400,
                collapsible: true,
                animCollapse: false,
                margins: '0 0 0 5',
                layout: 'accordion',
                items: [
				   {
						itmId:'actionMy',
						title:'Начало работы',
						iconCls:'icon-user_star',
						layout:'anchor',
						defaults: { // defaults are applied to items, not the container
							anchor: '100%',
							scale: 'large',
							textAlign :'left'
						},
						items:[ 
						new Ext.button.Button(actionStartPage),
						new Ext.button.Button(actionB2MYCALL),
						new Ext.button.Button(actionB2MYQRY),
						new Ext.button.Button(actionSendMail)
						
						
						] 
					},	
					
					{
						itmId:'actionBookkeepr',
						title:'Бухгалтер',
						iconCls:'icon-book_open',
						layout:'anchor',
						defaults: { // defaults are applied to items, not the container
							anchor: '100%',
							scale: 'large',
							textAlign :'left'
						},
						
						items:[ 
						new Ext.button.Button(actionUsersAccounts),
						new Ext.button.Button(actionReclamaURL)
						] 
					},	
					
					{
						itmId:'actionReports',
						title:'Отчеты',
						iconCls:'icon-report_disk',
						layout:'anchor',
						defaults: { // defaults are applied to items, not the container
							anchor: '100%',
							scale: 'large',
							textAlign :'left'
						},
						
						items:[ 
						new Ext.button.Button(actionREPORT1),
						new Ext.button.Button(actionREPORT2),
						new Ext.button.Button(actionREPORT3),
						new Ext.button.Button(actionREPORT4)
						] 
					},	
					
					
				
				
					{
					itmId:'actionListings',
                    title:'Мои объекты',
                    iconCls:'icon-house',
					layout:'anchor',
					defaults: { // defaults are applied to items, not the container
						anchor: '100%',
						scale: 'large',
						textAlign :'left'
					},
                    items:[ 
					// new Ext.button.Button(actionB2B),  
					new Ext.button.Button(actionB2P), 
					new Ext.button.Button(actionB2S), 
					new Ext.button.Button(actionB2Z),
					new Ext.button.Button(actionB2C), 
					new Ext.button.Button(actionB2FR)
					] 
					},
					{
					itmId:'actionListings',
                    title:'Поиск объектов',
                    iconCls:'icon-house_link',
					layout:'anchor',
					defaults: { // defaults are applied to items, not the container
						anchor: '100%',
						scale: 'large',
						textAlign :'left'
					},
                    items:[ 
					new Ext.button.Button(actionB2B),  
					new Ext.button.Button(actionMartB2P), 
					new Ext.button.Button(actionMartB2S), 
					new Ext.button.Button(actionMartB2Z),
					new Ext.button.Button(actionMartB2C), 
					new Ext.button.Button(actionMartB2FR)
					] 
					},
                {
					itmId:'actionReklama',
                    title:'Реклама',
                    iconCls:'icon-television',
					layout:'anchor',
					defaults: { // defaults are applied to items, not the container
						anchor: '100%',
						scale: 'large',
						textAlign :'left'
					},
                    items:[ 
					new Ext.button.Button(actionPublishObj), 
					new Ext.button.Button(actionReclamaOBJ ), 
					new Ext.button.Button(actionExportSheduler ) ,
					new Ext.button.Button(actionReestr )
					] 
                }, 
              /*   {
					itmId:'actionDict',
                    title:'Справочники',
                    iconCls:'icon-book_open',
					layout:'anchor',
					defaults: { // defaults are applied to items, not the container
						anchor: '100%', 
						scale: 'large',
						textAlign :'left'
					},
                    items:[
					new Ext.button.Button(actionBFD),
					new Ext.button.Button(actionB2D),
					//new Ext.button.Button(actionBR_DIC),
					new Ext.button.Button(actionB2DEV),
					new Ext.button.Button(actionB2G)
					
					] 
                }, */
				{
						itmId:'actionMy',
						title:'Диспетчер',
						iconCls:'icon-telephone',
						layout:'anchor',
						defaults: { // defaults are applied to items, not the container
							anchor: '100%',
							scale: 'large',
							textAlign :'left'
						},
						items:[ 
							new Ext.button.Button(actionTerminal),
							new Ext.button.Button(actionB2CALL),
							new Ext.button.Button(actionB2QRY),
							new Ext.button.Button(actionB2DUTY)
							
							
						] 
					},	
				{
					itmId:'actionSubjects',
                    title:'Фирма',
                    iconCls:'icon-computer',
					layout:'anchor',
					defaults: { // defaults are applied to items, not the container
						anchor: '100%',
						scale: 'large',
						textAlign :'left'
					},
                    items:[  
					new Ext.button.Button(actionBFIRM), 
					new Ext.button.Button(actionBUSR),
					//new Ext.button.Button(actionROLES),
					new Ext.button.Button(actionRolePage)
					, 
					new Ext.button.Button(actionB2ACTUAL)  ] 
                }
				]
            }
	);
    contentPanel = new Ext.tab.Panel({
        region:'center',
        xtype:'tabpanel', // TabPanel itself has no title
        activeTab:0      // First tab active by default
    });

	//while(!app_operations_loaded && !app_actions_loaded){
	//}
    var vPort = new Ext.container.Viewport({
            layout:'border',
            renderTo:Ext.getBody(),
            items:[ leftPanel, menuPanel, 
                contentPanel]
        }
    );
	
	combo_LoadNext();
	
	// открытие окна по умолчанию
	var sp=StartPage();
	sp.iconCls='icon-star_gold';
	contentPanel.add(sp);
	contentPanel.setActiveTab(sp);
	
 
	
	
}

function EnableActions(){
	//console.log('menuPanel->'+menuPanel);
	if(app_actions.getCount()==0){
		app_actions.load();
	}
	app_actions.each(function(record,idx){
	
	 var name=record.get('menucode'); 
	 var enableMenu = record.get('accesible'); 
	 var comp=null;
	 //console.log('code->'+name);
	 if(enableMenu!=0){
		comp=null;
		comp=menuPanel.down("#"+name);
		//console.log('comp->'+comp);
		if (comp!=null){
			comp.disabled=false;
		}
		comp=null;
		comp=leftPanel.down("#"+name);
		//console.log('comp->'+comp);
		if (comp!=null){
			comp.disabled=false;
			comp.btnInnerEl.setStyle({color:"black"});
		}
		
	 }else{
	 comp=null;
		comp=menuPanel.down("#"+name);
		//console.log('comp->'+comp);
		if (comp!=null){
			comp.disabled=true;
			
		}
		comp=null;
		comp=leftPanel.down("#"+name);
		//console.log('comp->'+comp);
		if (comp!=null){
			comp.disabled=true;
			comp.btnInnerEl.setStyle({color:"lightgrey"});
		}
	 }
	 
	});
};


function CheckOperation( action){
    if(app_operations.getCount()==0){
		app_operations.load();
	}
	var recordIndex = app_operations.find('name', action);

	if(recordIndex == -1){
		return true;
	}else{
		return app_operations.getAt(recordIndex).get('allowaction');
	}

}
