
Ext.require([
'Ext.form.*'
]);
  bpc_= null;
function bpc_Panel_(objectID, RootPanel, selection){ 


    var store_bpc_info = Ext.create('Ext.data.Store', {
        model:'model_bpc_info',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_bpc_info/getRows',
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
          DefineForms_bpc_info_();
     var   int_bpc_info_     =      DefineInterface_bpc_info_('int_bpc_info',store_bpc_info, selection);
     bpc_= Ext.create('Ext.form.Panel', {
      id: 'bpc',
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
        	    int_bpc_info_.doSave( me.onCommit);
        		},
        		onButtonCancel: function()
        		{
        		},
        canClose: function(){
        	return int_bpc_info_.canClose();
        },
        items: [{
            xtype:'tabpanel',
            itemId:'tabs_bpc',
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
            itemId:'tab_bpc_info',
            items:[ // panel on tab 
int_bpc_info_
        ] // panel on tab  form or grid
      } // end tab
    ] // part tabs
    }] // tabpanel
    }); //Ext.Create
    if(RootPanel==true){
       bpc_.closable= true;
       bpc_.title= 'Клиент';
       bpc_.frame= true;
    }else{
       bpc_.closable= false;
       bpc_.title= '';
       bpc_.frame= false;
    }
   store_bpc_info.on('load', function() {
        if(store_bpc_info.count()==0){
            store_bpc_info.insert(0, new model_bpc_info());
        }
        record= store_bpc_info.getAt(0);
        record['instanceid']=objectID;
   int_bpc_info_.setActiveRecord(record,objectID);	
   });
       store_bpc_info.load( {params:{ instanceid:objectID} }  );
    return bpc_;
}