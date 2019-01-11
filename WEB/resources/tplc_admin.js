
Ext.require([
'Ext.form.*'
]);
  tplc_admin= null;
function TPLC_Panel_admin(objectID, RootPanel, selection){ 


    var store_tplc_header = Ext.create('Ext.data.Store', {
        model:'model_tplc_header',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tplc_header/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
                },
            extraParams:{
                instanceid: objectID
            }
        }
    });

    var store_tplc_m = Ext.create('Ext.data.Store', {
        model:'model_tplc_m',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tplc_m/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
                },
            extraParams:{
                instanceid: objectID
            }
        }
    });

    var store_tplc_h = Ext.create('Ext.data.Store', {
        model:'model_tplc_h',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tplc_h/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
                },
            extraParams:{
                instanceid: objectID
            }
        }
    });

    var store_tplc_d = Ext.create('Ext.data.Store', {
        model:'model_tplc_d',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tplc_d/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
                },
            extraParams:{
                instanceid: objectID
            }
        }
    });

    var store_tplc_t = Ext.create('Ext.data.Store', {
        model:'model_tplc_t',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tplc_t/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
                },
            extraParams:{
                instanceid: objectID
            }
        }
    });

    var store_tplc_missing = Ext.create('Ext.data.Store', {
        model:'model_tplc_missing',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tplc_missing/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
                },
            extraParams:{
                instanceid: objectID
            }
        }
    });

    var store_tplc_e = Ext.create('Ext.data.Store', {
        model:'model_tplc_e',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tplc_e/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
                },
            extraParams:{
                instanceid: objectID
            }
        }
    });
          DefineForms_tplc_header_admin();
          DefineForms_tplc_m_admin();
          DefineForms_tplc_h_admin();
          DefineForms_tplc_d_admin();
          DefineForms_tplc_t_admin();
          DefineForms_tplc_missing_admin();
          DefineForms_tplc_e_admin();
     var   int_tplc_header_admin     =      DefineInterface_tplc_header_admin('int_tplc_header',store_tplc_header, selection);
     var   int_tplc_m_admin     =      DefineInterface_tplc_m_admin('int_tplc_m',store_tplc_m);
     var   int_tplc_h_admin     =      DefineInterface_tplc_h_admin('int_tplc_h',store_tplc_h);
     var   int_tplc_d_admin     =      DefineInterface_tplc_d_admin('int_tplc_d',store_tplc_d);
     var   int_tplc_t_admin     =      DefineInterface_tplc_t_admin('int_tplc_t',store_tplc_t);
     var   int_tplc_missing_admin     =      DefineInterface_tplc_missing_admin('int_tplc_missing',store_tplc_missing);
     var   int_tplc_e_admin     =      DefineInterface_tplc_e_admin('int_tplc_e',store_tplc_e);
     tplc_admin= Ext.create('Ext.form.Panel', {
      id: 'tplc',
      layout:'fit',
      fieldDefaults: {
          labelAlign:             'top',
          msgTarget:              'side'
        },
        defaults: {
        anchor:'100%'
        },

        instanceid:objectID,
                onCommit: function(){
        		},
        		onButtonOk: function()
        		{
        			var me = this;
        	    int_tplc_header_admin.doSave( me.onCommit);
        		},
        		onButtonCancel: function()
        		{
        		},
        canClose: function(){
        	return int_tplc_header_admin.canClose();
        },
        items: [{
            xtype:'tabpanel',
            itemId:'tabs_tplc',
            activeTab: 0,
            layout: 'fit',
            tabPosition:'top',
            border:0,
            items:[   // tabs
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Заголовок',
            layout:'fit',
            itemId:'tab_tplc_header',
            items:[ // panel on tab 
int_tplc_header_admin
        ] // panel on tab  form or grid
      } // end tab
,
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Мгновенные значения',
            layout:'fit',
            itemId:'tab_tplc_m',
            items:[ // panel on tab 
int_tplc_m_admin
        ] // panel on tab  form or grid
      } // end tab
,
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Часовые архивы',
            layout:'fit',
            itemId:'tab_tplc_h',
            items:[ // panel on tab 
int_tplc_h_admin
        ] // panel on tab  form or grid
      } // end tab
,
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Суточный архив',
            layout:'fit',
            itemId:'tab_tplc_d',
            items:[ // panel on tab 
int_tplc_d_admin
        ] // panel on tab  form or grid
      } // end tab
,
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Суммарные показатели',
            layout:'fit',
            itemId:'tab_tplc_t',
            items:[ // panel on tab 
int_tplc_t_admin
        ] // panel on tab  form or grid
      } // end tab
,
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Пропущенные архивы',
            layout:'fit',
            itemId:'tab_tplc_missing',
            items:[ // panel on tab 
int_tplc_missing_admin
        ] // panel on tab  form or grid
      } // end tab
,
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Электроэнергия',
            layout:'fit',
            itemId:'tab_tplc_e',
            items:[ // panel on tab 
int_tplc_e_admin
        ] // panel on tab  form or grid
      } // end tab
    ] // part tabs
    }] // tabpanel
    }); //Ext.Create
    if(RootPanel==true){
       tplc_admin.closable= true;
       tplc_admin.title= 'Данные';
       tplc_admin.frame= true;
    }else{
       tplc_admin.closable= false;
       tplc_admin.title= '';
       tplc_admin.frame= false;
    }
   store_tplc_header.on('load', function() {
        if(store_tplc_header.count()==0){
            store_tplc_header.insert(0, new model_tplc_header());
        }
        record= store_tplc_header.getAt(0);
        record['instanceid']=objectID;
   int_tplc_header_admin.setActiveRecord(record,objectID);	
   });
       store_tplc_header.load( {params:{ instanceid:objectID} }  );
   int_tplc_m_admin.instanceid=objectID;	
       store_tplc_m.load(  {params:{ instanceid:objectID} } );
   int_tplc_h_admin.instanceid=objectID;	
       store_tplc_h.load(  {params:{ instanceid:objectID} } );
   int_tplc_d_admin.instanceid=objectID;	
       store_tplc_d.load(  {params:{ instanceid:objectID} } );
   int_tplc_t_admin.instanceid=objectID;	
       store_tplc_t.load(  {params:{ instanceid:objectID} } );
   int_tplc_missing_admin.instanceid=objectID;	
       store_tplc_missing.load(  {params:{ instanceid:objectID} } );
   int_tplc_e_admin.instanceid=objectID;	
       store_tplc_e.load(  {params:{ instanceid:objectID} } );
    return tplc_admin;
}