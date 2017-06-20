
Ext.require([
'Ext.form.*'
]);
  tpq_= null;
function TPQ_Panel_(objectID, RootPanel, selection){ 


    var store_tpq_def = Ext.create('Ext.data.Store', {
        model:'model_tpq_def',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpq_def/getRows',
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

    var store_tpq_result = Ext.create('Ext.data.Store', {
        model:'model_tpq_result',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpq_result/getRows',
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
          DefineForms_tpq_def_();
          DefineForms_tpq_result_();
     var   int_tpq_def_     =      DefineInterface_tpq_def_('int_tpq_def',store_tpq_def, selection);
     var   int_tpq_result_     =      DefineInterface_tpq_result_('int_tpq_result',store_tpq_result);
     tpq_= Ext.create('Ext.form.Panel', {
      id: 'tpq',
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
        	    int_tpq_def_.doSave( me.onCommit);
        		},
        		onButtonCancel: function()
        		{
        		},
        canClose: function(){
        	return int_tpq_def_.canClose();
        },
        items: [{
            xtype:'tabpanel',
            itemId:'tabs_tpq',
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
            itemId:'tab_tpq_def',
            items:[ // panel on tab 
int_tpq_def_
        ] // panel on tab  form or grid
      } // end tab
,
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Результат обработки',
            layout:'fit',
            itemId:'tab_tpq_result',
            items:[ // panel on tab 
int_tpq_result_
        ] // panel on tab  form or grid
      } // end tab
    ] // part tabs
    }] // tabpanel
    }); //Ext.Create
    if(RootPanel==true){
       tpq_.closable= true;
       tpq_.title= 'Запрос на обработку';
       tpq_.frame= true;
    }else{
       tpq_.closable= false;
       tpq_.title= '';
       tpq_.frame= false;
    }
   store_tpq_def.on('load', function() {
        if(store_tpq_def.count()==0){
            store_tpq_def.insert(0, new model_tpq_def());
        }
        record= store_tpq_def.getAt(0);
        record['instanceid']=objectID;
   int_tpq_def_.setActiveRecord(record,objectID);	
   });
       store_tpq_def.load( {params:{ instanceid:objectID} }  );
   int_tpq_result_.instanceid=objectID;	
       store_tpq_result.load(  {params:{ instanceid:objectID} } );
    return tpq_;
}