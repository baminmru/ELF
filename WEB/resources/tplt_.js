
Ext.require([
'Ext.form.*'
]);
  tplt_= null;
function TPLT_Panel_(objectID, RootPanel, selection){ 


    var store_tplt_bdevices = Ext.create('Ext.data.Store', {
        model:'model_tplt_bdevices',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tplt_bdevices/getRows',
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

    var store_tplt_connect = Ext.create('Ext.data.Store', {
        model:'model_tplt_connect',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tplt_connect/getRows',
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

    var store_tplt_contract = Ext.create('Ext.data.Store', {
        model:'model_tplt_contract',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tplt_contract/getRows',
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

    var store_tplt_plancall = Ext.create('Ext.data.Store', {
        model:'model_tplt_plancall',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tplt_plancall/getRows',
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
          DefineForms_tplt_bdevices_();
          DefineForms_tplt_connect_();
          DefineForms_tplt_contract_();
          DefineForms_tplt_plancall_();
     var   int_tplt_bdevices_     =      DefineInterface_tplt_bdevices_('int_tplt_bdevices',store_tplt_bdevices, selection);
     var   int_tplt_connect_     =      DefineInterface_tplt_connect_('int_tplt_connect',store_tplt_connect);
     var   int_tplt_contract_     =      DefineInterface_tplt_contract_('int_tplt_contract',store_tplt_contract);
     var   int_tplt_plancall_     =      DefineInterface_tplt_plancall_('int_tplt_plancall',store_tplt_plancall);
     tplt_= Ext.create('Ext.form.Panel', {
      id: 'tplt',
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
					int_tplt_connect_.doSave( );
				int_tplt_contract_.doSave( );
				int_tplt_plancall_.doSave( );
        	    int_tplt_bdevices_.doSave( me.onCommit);
        		},
        		onButtonCancel: function()
        		{
        		},
        canClose: function(){
        	return int_tplt_bdevices_.canClose();
        },
        items: [{
            xtype:'tabpanel',
            itemId:'tabs_tplt',
            activeTab: 0,
            layout: 'fit',
            tabPosition:'top',
            border:0,
            items:[   // tabs
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Описание',
            layout:'fit',
            itemId:'tab_tplt_bdevices',
            items:[ // panel on tab 
int_tplt_bdevices_
        ] // panel on tab  form or grid
      } // end tab
,
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Параметры соединения',
            layout:'fit',
            itemId:'tab_tplt_connect',
            items:[ // panel on tab 
int_tplt_connect_
        ] // panel on tab  form or grid
      } // end tab
,
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Договорные установки',
            layout:'fit',
            itemId:'tab_tplt_contract',
            items:[ // panel on tab 
int_tplt_contract_
        ] // panel on tab  form or grid
      } // end tab
,
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'План опроса устройств',
            layout:'fit',
            itemId:'tab_tplt_plancall',
            items:[ // panel on tab 
int_tplt_plancall_
        ] // panel on tab  form or grid
      } // end tab
    ] // part tabs
    }] // tabpanel
    }); //Ext.Create
    if(RootPanel==true){
       tplt_.closable= true;
       tplt_.title= 'Тепловычислитель';
       tplt_.frame= true;
    }else{
       tplt_.closable= false;
       tplt_.title= '';
       tplt_.frame= false;
    }
   store_tplt_bdevices.on('load', function() {
        if(store_tplt_bdevices.count()==0){
            store_tplt_bdevices.insert(0, new model_tplt_bdevices());
        }
        record= store_tplt_bdevices.getAt(0);
        record['instanceid']=objectID;
   int_tplt_bdevices_.setActiveRecord(record,objectID);	
   });
       store_tplt_bdevices.load( {params:{ instanceid:objectID} }  );
   store_tplt_connect.on('load', function() {
        if(store_tplt_connect.count()==0){
            store_tplt_connect.insert(0, new model_tplt_connect());
        }
        record= store_tplt_connect.getAt(0);
        record['instanceid']=objectID;
   int_tplt_connect_.setActiveRecord(record,objectID);	
   });
       store_tplt_connect.load( {params:{ instanceid:objectID} }  );
   store_tplt_contract.on('load', function() {
        if(store_tplt_contract.count()==0){
            store_tplt_contract.insert(0, new model_tplt_contract());
        }
        record= store_tplt_contract.getAt(0);
        record['instanceid']=objectID;
   int_tplt_contract_.setActiveRecord(record,objectID);	
   });
       store_tplt_contract.load( {params:{ instanceid:objectID} }  );
   store_tplt_plancall.on('load', function() {
        if(store_tplt_plancall.count()==0){
            store_tplt_plancall.insert(0, new model_tplt_plancall());
        }
        record= store_tplt_plancall.getAt(0);
        record['instanceid']=objectID;
   int_tplt_plancall_.setActiveRecord(record,objectID);	
   });
       store_tplt_plancall.load( {params:{ instanceid:objectID} }  );
    return tplt_;
}