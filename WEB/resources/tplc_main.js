
Ext.require([
'Ext.form.*'
]);
  tplc_main= null;
function TPLC_Panel_main(objectID, RootPanel, selection){ 


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
          DefineForms_tplc_header_main();
          DefineForms_tplc_missing_main();
          DefineForms_tplc_e_main();
     var   int_tplc_header_main     =      DefineInterface_tplc_header_main('int_tplc_header',store_tplc_header, selection);
     var   int_tplc_missing_main     =      DefineInterface_tplc_missing_main('int_tplc_missing',store_tplc_missing);
     var   int_tplc_e_main     =      DefineInterface_tplc_e_main('int_tplc_e',store_tplc_e);
     tplc_main= Ext.create('Ext.form.Panel', {
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
        	    int_tplc_header_main.doSave( me.onCommit);
        		},
        		onButtonCancel: function()
        		{
        		},
        canClose: function(){
        	return int_tplc_header_main.canClose();
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
int_tplc_header_main
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
int_tplc_missing_main
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
int_tplc_e_main
        ] // panel on tab  form or grid
      } // end tab
    ] // part tabs
    }] // tabpanel
    }); //Ext.Create
    if(RootPanel==true){
       tplc_main.closable= true;
       tplc_main.title= 'Данные';
       tplc_main.frame= true;
    }else{
       tplc_main.closable= false;
       tplc_main.title= '';
       tplc_main.frame= false;
    }
   store_tplc_header.on('load', function() {
        if(store_tplc_header.count()==0){
            store_tplc_header.insert(0, new model_tplc_header());
        }
        record= store_tplc_header.getAt(0);
        record['instanceid']=objectID;
   int_tplc_header_main.setActiveRecord(record,objectID);	
   });
       store_tplc_header.load( {params:{ instanceid:objectID} }  );
   int_tplc_missing_main.instanceid=objectID;	
       store_tplc_missing.load(  {params:{ instanceid:objectID} } );
   int_tplc_e_main.instanceid=objectID;	
       store_tplc_e.load(  {params:{ instanceid:objectID} } );
    return tplc_main;
}