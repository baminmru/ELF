


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
            /*    Ext.MessageBox.show({
                    title:'REMOTE EXCEPTION',
                    msg:operation.getError(),
                    icon:Ext.MessageBox.ERROR,
                    buttons:Ext.Msg.OK
                }); */
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
            /*    Ext.MessageBox.show({
                    title:'REMOTE EXCEPTION',
                    msg:operation.getError(),
                    icon:Ext.MessageBox.ERROR,
                    buttons:Ext.Msg.OK
                }); */
            }
        }
    }
});

var cmbstore_aw_region2 = Ext.create('Ext.data.Store', {
    model:'cmbmodel_aw_region',
    autoLoad:false,
    autoSync:false,
    proxy:{
        type:'ajax',
        url:rootURL+'index.php/c_adrwin/getCountryRegion',
        reader:{
            type:'json', root:'data', successProperty:'success', messageProperty:'msg'
        },
        listeners:{
            exception:function (proxy, response, operation) {
             /*   Ext.MessageBox.show({
                    title:'REMOTE EXCEPTION',
                    msg:operation.getError(),
                    icon:Ext.MessageBox.ERROR,
                    buttons:Ext.Msg.OK
                }); */
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
            /*    Ext.MessageBox.show({
                    title:'REMOTE EXCEPTION',
                    msg:operation.getError(),
                    icon:Ext.MessageBox.ERROR,
                    buttons:Ext.Msg.OK
                }); */
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
             /*   Ext.MessageBox.show({
                    title:'REMOTE EXCEPTION',
                    msg:operation.getError(),
                    icon:Ext.MessageBox.ERROR,
                    buttons:Ext.Msg.OK
                }); */
            }
        }
    }
});

var cmbstore_aw_street = Ext.create('Ext.data.Store', {
    model:'cmbmodel_aw_region',
    autoLoad:false,
    autoSync:false,
    proxy:{
        type:'ajax',
        url:rootURL+'index.php/c_adrwin/getStreet',
        reader:{
            type:'json', root:'data', successProperty:'success', messageProperty:'msg'
        },
        listeners:{
            exception:function (proxy, response, operation) {
            /*    Ext.MessageBox.show({
                    title:'REMOTE EXCEPTION',
                    msg:operation.getError(),
                    icon:Ext.MessageBox.ERROR,
                    buttons:Ext.Msg.OK
                }); */
            }
        }
    }
});

var cmbstore_aw_street2 = Ext.create('Ext.data.Store', {
    model:'cmbmodel_aw_region',
    autoLoad:false,
    autoSync:false,
    proxy:{
        type:'ajax',
        url:rootURL+'index.php/c_adrwin/getStreet',
        reader:{
            type:'json', root:'data', successProperty:'success', messageProperty:'msg'
        },
        listeners:{
            exception:function (proxy, response, operation) {
            /*    Ext.MessageBox.show({
                    title:'REMOTE EXCEPTION',
                    msg:operation.getError(),
                    icon:Ext.MessageBox.ERROR,
                    buttons:Ext.Msg.OK
                }); */
            }
        }
    }
});

 Ext.define('cmbmodel_mart_bfrm_def',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'bfrm_defid',type: 'string'}
            ,{name: 'brief',type: 'string'}
			,{name: 'name',type: 'string'}
        ]
    });
var cmbstore_mart_bfrm_def_loaded=false;
var cmbstore_mart_bfrm_def = Ext.create('Ext.data.Store', {
	model:'cmbmodel_mart_bfrm_def',
	autoLoad: false,
	autoSync: false,
	proxy: {
		type:   'ajax',
			url:   rootURL+'index.php/c_mart_bfrm_def/getRows',
		reader: {
			type:   'json'
			,root:  'data'
			,successProperty:  'success'
			,messageProperty:  'msg'
		}
	},
   listeners: {
   'load': function(){combo_mart_bfrm_def_loaded =true;}
   }
});








