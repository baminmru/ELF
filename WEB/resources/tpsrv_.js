
Ext.require([
'Ext.form.*'
]);
  tpsrv_= null;
function TPSRV_Panel_(objectID, RootPanel, selection){ 


    var store_tpsrv_info = Ext.create('Ext.data.Store', {
        model:'model_tpsrv_info',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpsrv_info/getRows',
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

    var store_tpsrv_modems = Ext.create('Ext.data.Store', {
        model:'model_tpsrv_modems',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpsrv_modems/getRows',
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

    var store_tpsrv_ports = Ext.create('Ext.data.Store', {
        model:'model_tpsrv_ports',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpsrv_ports/getRows',
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
          DefineForms_tpsrv_info_();
          DefineForms_tpsrv_modems_();
          DefineForms_tpsrv_ports_();
     var   int_tpsrv_info_     =      DefineInterface_tpsrv_info_('int_tpsrv_info',store_tpsrv_info, selection);
     var   int_tpsrv_modems_     =      DefineInterface_tpsrv_modems_('int_tpsrv_modems',store_tpsrv_modems);
     var   int_tpsrv_ports_     =      DefineInterface_tpsrv_ports_('int_tpsrv_ports',store_tpsrv_ports);
     tpsrv_= Ext.create('Ext.form.Panel', {
      id: 'tpsrv',
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
        	    int_tpsrv_info_.doSave( me.onCommit);
        		},
        		onButtonCancel: function()
        		{
        		},
        canClose: function(){
        	return int_tpsrv_info_.canClose();
        },
        items: [{
            xtype:'tabpanel',
            itemId:'tabs_tpsrv',
            activeTab: 0,
            layout: 'fit',
            tabPosition:'top',
            border:0,
            items:[   // tabs
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Описание сервера',
            layout:'fit',
            itemId:'tab_tpsrv_info',
            items:[ // panel on tab 
int_tpsrv_info_
        ] // panel on tab  form or grid
      } // end tab
,
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Модемы',
            layout:'fit',
            itemId:'tab_tpsrv_modems',
            items:[ // panel on tab 
int_tpsrv_modems_
        ] // panel on tab  form or grid
      } // end tab
,
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Ком порты',
            layout:'fit',
            itemId:'tab_tpsrv_ports',
            items:[ // panel on tab 
int_tpsrv_ports_
        ] // panel on tab  form or grid
      } // end tab
    ] // part tabs
    }] // tabpanel
    }); //Ext.Create
    if(RootPanel==true){
       tpsrv_.closable= true;
       tpsrv_.title= 'Сервер';
       tpsrv_.frame= true;
    }else{
       tpsrv_.closable= false;
       tpsrv_.title= '';
       tpsrv_.frame= false;
    }
   store_tpsrv_info.on('load', function() {
        if(store_tpsrv_info.count()==0){
            store_tpsrv_info.insert(0, new model_tpsrv_info());
        }
        record= store_tpsrv_info.getAt(0);
        record['instanceid']=objectID;
   int_tpsrv_info_.setActiveRecord(record,objectID);	
   });
       store_tpsrv_info.load( {params:{ instanceid:objectID} }  );
   int_tpsrv_modems_.instanceid=objectID;	
       store_tpsrv_modems.load(  {params:{ instanceid:objectID} } );
   int_tpsrv_ports_.instanceid=objectID;	
       store_tpsrv_ports.load(  {params:{ instanceid:objectID} } );
    return tpsrv_;
}