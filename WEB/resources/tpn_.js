
Ext.require([
'Ext.form.*'
]);
  tpn_= null;
function TPN_Panel_(objectID, RootPanel, selection){ 


    var store_tpn_def = Ext.create('Ext.data.Store', {
        model:'model_tpn_def',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpn_def/getRows',
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
          DefineForms_tpn_def_();
     var   int_tpn_def_     =      DefineInterface_tpn_def_('int_tpn_def',store_tpn_def, selection);
     tpn_= Ext.create('Ext.form.Panel', {
      id: 'tpn',
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
        	    int_tpn_def_.doSave( me.onCommit);
        		},
        		onButtonCancel: function()
        		{
        		},
        canClose: function(){
        	return int_tpn_def_.canClose();
        },
        items: [{
            xtype:'tabpanel',
            itemId:'tabs_tpn',
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
            itemId:'tab_tpn_def',
            items:[ // panel on tab 
int_tpn_def_
        ] // panel on tab  form or grid
      } // end tab
    ] // part tabs
    }] // tabpanel
    }); //Ext.Create
    if(RootPanel==true){
       tpn_.closable= true;
       tpn_.title= 'Узел';
       tpn_.frame= true;
    }else{
       tpn_.closable= false;
       tpn_.title= '';
       tpn_.frame= false;
    }
   store_tpn_def.on('load', function() {
        if(store_tpn_def.count()==0){
            store_tpn_def.insert(0, new model_tpn_def());
        }
        record= store_tpn_def.getAt(0);
        record['instanceid']=objectID;
   int_tpn_def_.setActiveRecord(record,objectID);	
   });
       store_tpn_def.load( {params:{ instanceid:objectID} }  );
    return tpn_;
}