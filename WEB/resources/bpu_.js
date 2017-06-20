
Ext.require([
'Ext.form.*'
]);
  bpu_= null;
function bpu_Panel_(objectID, RootPanel, selection){ 

        // Prepare document for edit
        Ext.Ajax.request(
        	{
        		url:rootURL+'index.php/app/PrepareDocument',
        		method:'POST',
        		params:{
        			typename:'bpu',
        			documentid:objectID
        		}
        	}
        );

    var store_iu_u_def = Ext.create('Ext.data.Store', {
        model:'model_iu_u_def',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_iu_u_def/getRowsTemp',
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
          DefineForms_iu_u_def_();
     var   int_iu_u_def_     =      DefineInterface_iu_u_def_('int_iu_u_def',store_iu_u_def, selection);
     bpu_= Ext.create('Ext.form.Panel', {
      id: 'bpu',
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
        		// Commit document changes
        			Ext.Ajax.request(
        				{
        					url:rootURL+'index.php/app/CommitDocument',
                            method:  'POST',
        					params:{
                                typename:  'bpu',
                                documentid: objectID
        					}
        					,
        					success: function(response){
        						var text = response.responseText;
        						//alert(text);
        						var res =Ext.decode(text);
        						if(res.success==false){
        							Ext.MessageBox.show({
        								title:  'Ошибка',
                                        msg:        res.msg,
                                        buttons : Ext.MessageBox.OK,
                                        Icon : Ext.MessageBox.ERROR()
        								});
        								p1_saved=false;
        						}else{
        							if(typeof(bpu_.onButtonCancel) == 'function') bpu_.onButtonCancel();
        						}
        					}
        				}
        			);
        		},
        		onButtonOk: function()
        		{
        			var me = this;
        	    int_iu_u_def_.doSave( me.onCommit);
        		},
        		onButtonCancel: function()
        		{
        			Ext.Ajax.request(
        				{
        					url:rootURL+'index.php/app/DropTempDocument',
                            method:         'POST',
        					params:{
                            typename:       'bpu',
                            documentid:     objectID
        					},
        					success: function(response){
        						var text = response.responseText;
        						//alert(text);
        						var res =Ext.decode(text);
        						if(res.success==false){
        							// ...
        						}
        					}
        				}
        			);
        		},
        canClose: function(){
        	return int_iu_u_def_.canClose();
        },
        items: [{
            xtype:'tabpanel',
            itemId:'tabs_bpu',
            activeTab: 0,
            layout: 'fit',
            tabPosition:'top',
            border:0,
            items:[   // tabs
            { // begin part tab
            xtype:'panel',
            border:0,
            title: 'Данные сотрудника',
            layout:'fit',
            itemId:'tab_iu_u_def',
            items:[ // panel on tab 
int_iu_u_def_
        ] // panel on tab  form or grid
      } // end tab
    ] // part tabs
    }] // tabpanel
    }); //Ext.Create
    if(RootPanel==true){
       bpu_.closable= true;
       bpu_.title= 'Сотрудник';
       bpu_.frame= true;
    }else{
       bpu_.closable= false;
       bpu_.title= '';
       bpu_.frame= false;
    }
   store_iu_u_def.on('load', function() {
        if(store_iu_u_def.count()==0){
            store_iu_u_def.insert(0, new model_iu_u_def());
        }
        record= store_iu_u_def.getAt(0);
        record['instanceid']=objectID;
   int_iu_u_def_.setActiveRecord(record,objectID);	
   });
       store_iu_u_def.load( {params:{ instanceid:objectID} }  );
    return bpu_;
}