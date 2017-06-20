var adrString;
var addrwin;
var region;
var district;
var town;
var street;

var region_txt;
var district_txt;
var town_txt;
var street_txt;


Ext.define('treemodel_aw', {
    extend:'Ext.data.Model',
    fields:[
        {name:'id', type:'string'},
        {name:'text', type:'string'},
        {name:'leaf', type:'string'},
        {name:'cls', type:'string'},
        {name:'fullname', type:'string'},
		{name:'name', type:'string'}
    ]
});

Ext.define('cmbmodel_aw_region', {
    extend:'Ext.data.Model',
    fields:[
		{name:'b2g_addrid', type:'string'}
        ,
        {name:'objectid', type:'string'}
        ,
        {name:'name', type:'string'}
        ,
        {name:'treecode', type:'string'}
    ]
});

var cmbstore_aw_country = Ext.create('Ext.data.Store', {
    model:'cmbmodel_aw_region',
    autoLoad:false,
    autoSync:false,
    proxy:{
        type:'ajax',
        url:rootURL+'index.php/c_adrwin/getCountry',
        reader:{
            type:'json', root:'data', successProperty:'success', messageProperty:'msg'
        },
        listeners:{
            exception:function (proxy, response, operation) {
                Ext.MessageBox.show({
                    title:'REMOTE EXCEPTION',
                    msg:operation.getError(),
                    icon:Ext.MessageBox.ERROR,
                    buttons:Ext.Msg.OK
                });
            }
        }
    }
});

var cmbstore_aw_region = Ext.create('Ext.data.Store', {
    model:'cmbmodel_aw_region',
    autoLoad:false,
    autoSync:false,
    proxy:{
        type:'ajax',
        url:rootURL+'index.php/c_adrwin/getRegion',
        reader:{
            type:'json', root:'data', successProperty:'success', messageProperty:'msg'
        },
        listeners:{
            exception:function (proxy, response, operation) {
                Ext.MessageBox.show({
                    title:'REMOTE EXCEPTION',
                    msg:operation.getError(),
                    icon:Ext.MessageBox.ERROR,
                    buttons:Ext.Msg.OK
                });
            }
        }
    }
});

var cmbstore_aw_district = Ext.create('Ext.data.Store', {
    model:'cmbmodel_aw_region',
    autoLoad:false,
    autoSync:false,
    proxy:{
        type:'ajax',
        url:rootURL+'index.php/c_adrwin/getDistrict',
        reader:{
            type:'json', root:'data', successProperty:'success', messageProperty:'msg'
        },
        listeners:{
            exception:function (proxy, response, operation) {
                Ext.MessageBox.show({
                    title:'REMOTE EXCEPTION',
                    msg:operation.getError(),
                    icon:Ext.MessageBox.ERROR,
                    buttons:Ext.Msg.OK
                });
            }
        }
    }
});

var cmbstore_aw_town = Ext.create('Ext.data.Store', {
    model:'cmbmodel_aw_region',
    autoLoad:false,
    autoSync:false,
    proxy:{
        type:'ajax',
        url:rootURL+'index.php/c_adrwin/getTown',
        reader:{
            type:'json', root:'data', successProperty:'success', messageProperty:'msg'
        },
        listeners:{
            exception:function (proxy, response, operation) {
                Ext.MessageBox.show({
                    title:'REMOTE EXCEPTION',
                    msg:operation.getError(),
                    icon:Ext.MessageBox.ERROR,
                    buttons:Ext.Msg.OK
                });
            }
        }
    }
});

Ext.require([
    'Ext.tree.*',
    'Ext.data.*'
]);


function showAddrWin(caller) {


    var treestore_aw_street = Ext.create('Ext.data.TreeStore', {
        model:'treemodel_aw',
        proxy:{
            type:'ajax',
            url:rootURL+'index.php/c_adrwin/getStreet',
            extraParams:{
                find:''
            }
        },
        /*reader: {
         type: 'xml',
         root: 'nodes',
         record: 'node'
         },*/

        root:{
            text:'Улицы',
            id:'',
            expanded:false
        },
        folderSort:true,
        sorters:[
            {
                property:'text',
                direction:'ASC'
            }
        ]
    });

    //if (!addrwin)
	{
        var form = Ext.widget('form', {
            layout:{
                type:'column'
            },
            border:false,
            bodyPadding:10,

            fieldDefaults:{
                labelAlign:'top',
                labelWidth:100,
                labelStyle:'font-weight:bold'
            },
            defaults:{
                margins:'0 0 10 0'
            },

            items:[
                {
                    columnWidth:1,
                    xtype:'combobox',
                    store:cmbstore_aw_region,
                    valueField:'treecode',
                    displayField:'name',
                    typeAhead:true,
                    queryMode:'local',
                    emptyText:'',
                    name:'region',
                    itemId:'region',
                    fieldLabel:'Регион',
                    listeners:{
                        select:function (combo, selection) {
                            var post = selection[0];
                            if (post) {
                              
								region=post.get('b2g_addrid');
								region_txt=post.get('name');
                                var dist = combo.ownerCt.getComponent('district');
                                if (dist)
                                    dist.clearValue();
                                else
                                    Ext.MessageBox.alert('Регион', combo + ' ' + combo.fieldLabel)
                                cmbstore_aw_district.load({params:{region:post.get('objectid')}});


                                treestore_aw_street.setRootNode(
                                    {
                                        text:post.get('name'),
                                        id:post.get('treecode'),
                                        expanded:true
                                    }
                                );

                            }
                        }
                    }
                },
                {
                    columnWidth:1,
                    xtype:'combobox',
                    store:cmbstore_aw_district,
                    valueField:'treecode',
                    displayField:'name',
                    typeAhead:true,
                    queryMode:'local',
                    emptyText:'',
                    name:'district',
                    itemId:'district',
                    fieldLabel:'Район',
                    listeners:{
                        select:function (combo, selection) {
						    var post = selection[0];
                            if (post) {
                               

								district=post.get('b2g_addrid');
								district_txt=post.get('name');
                                var tw = combo.ownerCt.getComponent('ctown');
                                if (tw)
                                    tw.clearValue();
                                //else
                                //    Ext.MessageBox.alert('Нас. пункт:', combo + ' ' + combo.fieldLabel)
                                cmbstore_aw_town.load({params:{district:post.get('objectid')}});
							
							 //var tree = combo.ownerCt.getComponent('tree');
							 treestore_aw_street.setRootNode(
                                    {
                                        text:post.get('name'),
                                        id:post.get('treecode'),
                                        expanded:true
                                    }
                                );
                            }
                        }
                    }

                },
                {
                    columnWidth:1,
                    xtype:'combobox',
                    store:cmbstore_aw_town,
                    valueField:'treecode',
                    displayField:'name',
                    typeAhead:true,
                    queryMode:'local',
                    emptyText:'',
                    name:'ctown',
                    itemId:'ctown',
                    fieldLabel:'Нас. пункт',
                    listeners:{
                        select:function (combo, selection) {
                            var post = selection[0];
                            if (post) {
                                town=post.get('b2g_addrid');
								town_txt=post.get('name');
								//var tree = combo.ownerCt.getComponent('tree');
                                treestore_aw_street.setRootNode(
                                    {
                                        text:post.get('name'),
                                        id:post.get('treecode'),
                                        expanded:true
                                    }
                                );
                            }
                        }
                    }

                }
				/*,
                {
                    columnWidth:1,
                    xtype:'textfield',
                    fieldLabel:'Улица',
                    name:'streetmask',
                    itemId:'streetmask',
                    allowBlank:true,
                    listeners:{
                        specialkey:function (f, e) {
                            if (e.getKey() == e.ENTER) {

                                var tree = f.ownerCt.getComponent('tree');
                                var root = tree.getRootNode();
                                Ext.MessageBox.alert('Улица',f.getValue())+' '+root.id+' '+root.text;
                                var proxy = treestore_aw_street.getProxy();
                                proxy.extraParams.find = f.getValue();
                                root.removeAll();
                                treestore_aw_street.load({node:root});

                            }
                        }
                    }
                }*/
				,
                {
                    xtype:'treepanel',
                    store:treestore_aw_street,
                    name:'tree',
                    itemId:'tree',
                    hideHeaders:true,
                    rootVisible:true,
               
                    height:330,
                    columnWidth:1,
                    title:'Улица' //,
              
                },

                {
                    columnWidth:.5,
                    xtype:'textfield',
                    fieldLabel:'Дом',
                    name:'house',
                    itemId:'house',
                    allowBlank:true
                },
                {
                    columnWidth:.5,
                    xtype:'textfield',
                    fieldLabel:'Корпус ',
                    name:'block',
                    itemId:'block',
                    allowBlank:true
                }
            ],

            buttons:[
                
                {
                    text:'Выбрать',
                    handler:function () {
                        if (this.up('form').getForm().isValid()) {
                            // In a real application, this would submit the form to the configured url
                            // this.up('form').getForm().submit();

                            var tree = this.up('form').getComponent('tree');
                            var selection = tree.getSelectionModel().getSelection()[0];
                            if (selection) {
                                var house = this.up('form').getComponent('house');
                                var block = this.up('form').getComponent('block');
								street=selection.get('id');
								street_txt=selection.get('name');

								var ff = caller.up('form');
								var ss =selection.get('name');
								
								if (house.getValue()!=''){
									ss=ss+' д.'+house.getValue();
								}
								if (block.getValue()!=''){
									ss=ss+' к.'+block.getValue();
								}
                                caller.setValue(ss);

                                
								if (ff){
									var form =ff.getForm()
									var active=ff.activeRecord;
									if(active){
										
										form.updateRecord(active);
										active.set('regionid',region); 
										active.set('districtid',district); 	
										active.set('cityid',town); 	
										active.set('streetid1',street); 
										active.set('house',house.getValue()); 
										active.set('block',block.getValue()); 
										
										try{
											active.set('regionid_grid',region_txt); 
											active.set('districtid_grid',district_txt); 	
											active.set('cityid_grid',town_txt); 	
											active.set('streetid1_grid',street_txt);
										}catch( e){
											alert('set error:' +e);
										}
										alert (active);
										form.loadRecord(active);
									}
								}else{
									alert('caller:' + caller);
									alert('caller.up(form):'+caller.up('form'))
								}
                            }
                            this.up('form').getForm().reset();
                            this.up('window').hide();
                        }
                    }
                },
				{
                    text:'Отмена',
                    handler:function () {
                        this.up('form').getForm().reset();
                        this.up('window').hide();
                    }
                }
            ]
        });

        addrwin = Ext.widget('window', {
            title:'Выбор адреса',
            closeAction:'hide',
            width:600,
            height:600,
            minHeight:500,
			constrainHeader:true,
            layout:'fit',
            resizable:true,
            modal:true,
            items:form
        });
    }
    addrwin.show();
    cmbstore_aw_region.load();
}