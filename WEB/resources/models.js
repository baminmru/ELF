

 Ext.define('model_bpc_info',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'bpc_infoid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'name', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_bpc_info',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'bpc_infoid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_bpc_info_loaded=false;
    var cmbstore_bpc_info = Ext.create('Ext.data.Store', {
        model:'cmbmodel_bpc_info',
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
            }
        },
       listeners: {
       'load': function(){combo_bpc_info_loaded =true;}
       }
    });

 Ext.define('model_iu_int_modules',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'iu_int_modulesid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'substructobjects', type: 'int'}
            ,{name:'substructobjects_grid', type: 'string'}
            ,{name:'sequence', type: 'number'}
            ,{name:'visiblecontrol', type: 'int'}
            ,{name:'visiblecontrol_grid', type: 'string'}
            ,{name:'otherdocmode', type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'allobjects', type: 'int'}
            ,{name:'allobjects_grid', type: 'string'}
            ,{name:'caption', type: 'string'}
            ,{name:'colegsobject', type: 'int'}
            ,{name:'colegsobject_grid', type: 'string'}
            ,{name:'mydocmode', type: 'string'}
            ,{name:'theicon', type: 'string'}
            ,{name:'controldocmode', type: 'string'}
            ,{name:'groupname', type: 'string'}
        ]
    });


 Ext.define('model_iu_crole',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'iu_croleid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'allowsetuser', type: 'int'}
            ,{name:'allowsetuser_grid', type: 'string'}
            ,{name:'name', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_iu_crole',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'iu_croleid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_iu_crole_loaded=false;
    var cmbstore_iu_crole = Ext.create('Ext.data.Store', {
        model:'cmbmodel_iu_crole',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_iu_crole/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_iu_crole_loaded =true;}
       }
    });

 Ext.define('model_iu_rcfg_mod',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'iu_rcfg_modid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'controldocmode', type: 'string'}
            ,{name:'visiblecontrol', type: 'int'}
            ,{name:'visiblecontrol_grid', type: 'string'}
            ,{name:'allobjects', type: 'int'}
            ,{name:'allobjects_grid', type: 'string'}
            ,{name:'theicon', type: 'string'}
            ,{name:'sequence', type: 'number'}
            ,{name:'moduleaccessible', type: 'int'}
            ,{name:'moduleaccessible_grid', type: 'string'}
            ,{name:'colegsobject', type: 'int'}
            ,{name:'colegsobject_grid', type: 'string'}
            ,{name:'otherdocmode', type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'mydocmode', type: 'string'}
            ,{name:'groupname', type: 'string'}
            ,{name:'caption', type: 'string'}
            ,{name:'substructobjects', type: 'int'}
            ,{name:'substructobjects_grid', type: 'string'}
        ]
    });


 Ext.define('model_iu_rcfg_docmode',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'iu_rcfg_docmodeid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'allowadd', type: 'int'}
            ,{name:'allowadd_grid', type: 'string'}
            ,{name:'editmode', type: 'string'}
            ,{name:'addmode', type: 'string'}
            ,{name:'the_document', type: 'string'}
            ,{name:'the_document_grid', type: 'string'}
            ,{name:'allowdelete', type: 'int'}
            ,{name:'allowdelete_grid', type: 'string'}
        ]
    });


 Ext.define('model_iu_rcfg_def',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'iu_rcfg_defid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'therole', type: 'string'}
            ,{name:'therole_grid', type: 'string'}
        ]
    });


 Ext.define('model_iu_u_def',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'iu_u_defid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'thephone', type: 'string'}
            ,{name:'surname', type: 'string'}
            ,{name:'email', type: 'string'}
            ,{name:'sendtomail', type: 'int'}
            ,{name:'sendtomail_grid', type: 'string'}
            ,{name:'theclient', type: 'string'}
            ,{name:'theclient_grid', type: 'string'}
            ,{name:'login', type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'lastname', type: 'string'}
            ,{name:'currole', type: 'string'}
            ,{name:'currole_grid', type: 'string'}
            ,{name:'freelancer', type: 'int'}
            ,{name:'freelancer_grid', type: 'string'}
        ]
    });


 Ext.define('model_mtzext_def',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'mtzext_defid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'exttype', type: 'int'}
            ,{name:'exttype_grid', type: 'string'}
            ,{name:'thedescription', type: 'string'}
        ]
    });


 Ext.define('model_mtzextrel',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'mtzextrelid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'theclassname', type: 'string'}
            ,{name:'theplatform', type: 'int'}
            ,{name:'theplatform_grid', type: 'string'}
            ,{name:'thelibraryname', type: 'string'}
        ]
    });


 Ext.define('model_filterfieldgroup',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'filterfieldgroupid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'caption', type: 'string'}
            ,{name:'sequence', type: 'number'}
            ,{name:'name', type: 'string'}
            ,{name:'allowignore', type: 'int'}
            ,{name:'allowignore_grid', type: 'string'}
        ]
    });


 Ext.define('model_fileterfield',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'fileterfieldid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'fieldsize', type: 'number'}
            ,{name:'reftotype', type: 'string'}
            ,{name:'reftotype_grid', type: 'string'}
            ,{name:'reftype', type: 'int'}
            ,{name:'reftype_grid', type: 'string'}
            ,{name:'caption', type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'fieldtype', type: 'string'}
            ,{name:'fieldtype_grid', type: 'string'}
            ,{name:'valuearray', type: 'int'}
            ,{name:'valuearray_grid', type: 'string'}
            ,{name:'sequence', type: 'number'}
            ,{name:'reftopart', type: 'string'}
            ,{name:'reftopart_grid', type: 'string'}
        ]
    });


 Ext.define('model_filters',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'filtersid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'thecaption', type: 'string'}
            ,{name:'thecomment', type: 'string'}
            ,{name:'name', type: 'string'}
        ]
    });


 Ext.define('model_journalcolumn',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'journalcolumnid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'columnalignment', type: 'int'}
            ,{name:'columnalignment_grid', type: 'string'}
            ,{name:'groupaggregation', type: 'int'}
            ,{name:'groupaggregation_grid', type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'colsort', type: 'int'}
            ,{name:'colsort_grid', type: 'string'}
            ,{name:'sequence', type: 'number'}
        ]
    });


 Ext.define('model_jcolumnsource',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'jcolumnsourceid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'viewfield', type: 'string'}
            ,{name:'srcpartview', type: 'string'}
            ,{name:'srcpartview_grid', type: 'string'}
        ]
    });


 Ext.define('model_journalsrc',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'journalsrcid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'viewalias', type: 'string'}
            ,{name:'onrun', type: 'int'}
            ,{name:'onrun_grid', type: 'string'}
            ,{name:'openmode', type: 'string'}
            ,{name:'partview', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_journalsrc',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'journalsrcid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_journalsrc_loaded=false;
    var cmbstore_journalsrc = Ext.create('Ext.data.Store', {
        model:'cmbmodel_journalsrc',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_journalsrc/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_journalsrc_loaded =true;}
       }
    });

 Ext.define('model_journal',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'journalid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'thecomment', type: 'string'}
            ,{name:'jrnliconcls', type: 'string'}
            ,{name:'the_alias', type: 'string'}
            ,{name:'usefavorites', type: 'int'}
            ,{name:'usefavorites_grid', type: 'string'}
        ]
    });


 Ext.define('model_genpackage',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'genpackageid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'name', type: 'string'}
        ]
    });


 Ext.define('model_generator_target',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'generator_targetid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'generatorstyle', type: 'int'}
            ,{name:'generatorstyle_grid', type: 'string'}
            ,{name:'queuename', type: 'string'}
            ,{name:'thedevelopmentenv', type: 'int'}
            ,{name:'thedevelopmentenv_grid', type: 'string'}
            ,{name:'generatorprogid', type: 'string'}
            ,{name:'targettype', type: 'int'}
            ,{name:'targettype_grid', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_generator_target',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'generator_targetid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_generator_target_loaded=false;
    var cmbstore_generator_target = Ext.create('Ext.data.Store', {
        model:'cmbmodel_generator_target',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_generator_target/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_generator_target_loaded =true;}
       }
    });

 Ext.define('model_genreference',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'genreferenceid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'refclassid', type: 'string'}
            ,{name:'versionmajor', type: 'number'}
            ,{name:'name', type: 'string'}
            ,{name:'versionminor', type: 'number'}
        ]
    });


 Ext.define('model_genmanualcode',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'genmanualcodeid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'code', type: 'string'}
            ,{name:'the_alias', type: 'string'}
            ,{name:'name', type: 'string'}
        ]
    });


 Ext.define('model_gencontrols',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'gencontrolsid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'versionminor', type: 'number'}
            ,{name:'versionmajor', type: 'number'}
            ,{name:'controlprogid', type: 'string'}
            ,{name:'controlclassid', type: 'string'}
        ]
    });


 Ext.define('model_localizeinfo',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'localizeinfoid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'langfull', type: 'string'}
            ,{name:'langshort', type: 'string'}
        ]
    });


 Ext.define('model_fieldtype',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'fieldtypeid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'delayedsave', type: 'int'}
            ,{name:'delayedsave_grid', type: 'string'}
            ,{name:'typestyle', type: 'int'}
            ,{name:'typestyle_grid', type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'gridsorttype', type: 'int'}
            ,{name:'gridsorttype_grid', type: 'string'}
            ,{name:'the_comment', type: 'string'}
            ,{name:'allowsize', type: 'int'}
            ,{name:'allowsize_grid', type: 'string'}
            ,{name:'allowlikesearch', type: 'int'}
            ,{name:'allowlikesearch_grid', type: 'string'}
            ,{name:'maximum', type: 'string'}
            ,{name:'minimum', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_fieldtype',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'fieldtypeid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_fieldtype_loaded=false;
    var cmbstore_fieldtype = Ext.create('Ext.data.Store', {
        model:'cmbmodel_fieldtype',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_fieldtype/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_fieldtype_loaded =true;}
       }
    });

 Ext.define('model_enumitem',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'enumitemid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'nameincode', type: 'string'}
            ,{name:'namevalue', type: 'number'}
        ]
    });


 Ext.define('model_fieldtypemap',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'fieldtypemapid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'fixedsize', type: 'number'}
            ,{name:'stoagetype', type: 'string'}
            ,{name:'target', type: 'string'}
            ,{name:'target_grid', type: 'string'}
        ]
    });


 Ext.define('model_sharedmethod',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'sharedmethodid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'the_comment', type: 'string'}
            ,{name:'returntype', type: 'string'}
            ,{name:'returntype_grid', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_sharedmethod',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'sharedmethodid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_sharedmethod_loaded=false;
    var cmbstore_sharedmethod = Ext.create('Ext.data.Store', {
        model:'cmbmodel_sharedmethod',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_sharedmethod/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_sharedmethod_loaded =true;}
       }
    });

 Ext.define('model_script',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'scriptid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'code', type: 'string'}
            ,{name:'target', type: 'string'}
            ,{name:'target_grid', type: 'string'}
        ]
    });


 Ext.define('model_parameters',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'parametersid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'caption', type: 'string'}
            ,{name:'reftopart', type: 'string'}
            ,{name:'reftopart_grid', type: 'string'}
            ,{name:'outparam', type: 'int'}
            ,{name:'outparam_grid', type: 'string'}
            ,{name:'datasize', type: 'number'}
            ,{name:'name', type: 'string'}
            ,{name:'typeofparm', type: 'string'}
            ,{name:'typeofparm_grid', type: 'string'}
            ,{name:'sequence', type: 'number'}
            ,{name:'referencetype', type: 'int'}
            ,{name:'referencetype_grid', type: 'string'}
            ,{name:'allownull', type: 'int'}
            ,{name:'allownull_grid', type: 'string'}
            ,{name:'reftotype', type: 'string'}
            ,{name:'reftotype_grid', type: 'string'}
        ]
    });


 Ext.define('model_objecttype',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'objecttypeid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'objiconcls', type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'thecomment', type: 'string'}
            ,{name:'useownership', type: 'int'}
            ,{name:'useownership_grid', type: 'string'}
            ,{name:'ondelete', type: 'string'}
            ,{name:'ondelete_grid', type: 'string'}
            ,{name:'usearchiving', type: 'int'}
            ,{name:'usearchiving_grid', type: 'string'}
            ,{name:'replicatype', type: 'int'}
            ,{name:'replicatype_grid', type: 'string'}
            ,{name:'oncreate', type: 'string'}
            ,{name:'oncreate_grid', type: 'string'}
            ,{name:'commitfullobject', type: 'int'}
            ,{name:'commitfullobject_grid', type: 'string'}
            ,{name:'allowreftoobject', type: 'int'}
            ,{name:'allowreftoobject_grid', type: 'string'}
            ,{name:'package', type: 'string'}
            ,{name:'package_grid', type: 'string'}
            ,{name:'onrun', type: 'string'}
            ,{name:'onrun_grid', type: 'string'}
            ,{name:'the_comment', type: 'string'}
            ,{name:'chooseview', type: 'string'}
            ,{name:'chooseview_grid', type: 'string'}
            ,{name:'issingleinstance', type: 'int'}
            ,{name:'issingleinstance_grid', type: 'string'}
            ,{name:'allowsearch', type: 'int'}
            ,{name:'allowsearch_grid', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_objecttype',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'objecttypeid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_objecttype_loaded=false;
    var cmbstore_objecttype = Ext.create('Ext.data.Store', {
        model:'cmbmodel_objecttype',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_objecttype/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_objecttype_loaded =true;}
       }
    });

 Ext.define('model_objstatus',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'objstatusid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'isarchive', type: 'int'}
            ,{name:'isarchive_grid', type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'the_comment', type: 'string'}
            ,{name:'isstartup', type: 'int'}
            ,{name:'isstartup_grid', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_objstatus',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'objstatusid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_objstatus_loaded=false;
    var cmbstore_objstatus = Ext.create('Ext.data.Store', {
        model:'cmbmodel_objstatus',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_objstatus/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_objstatus_loaded =true;}
       }
    });

 Ext.define('model_nextstate',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'nextstateid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'thestate', type: 'string'}
            ,{name:'thestate_grid', type: 'string'}
        ]
    });


 Ext.define('model_objectmode',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'objectmodeid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'thecomment', type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'defaultmode', type: 'int'}
            ,{name:'defaultmode_grid', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_objectmode',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'objectmodeid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_objectmode_loaded=false;
    var cmbstore_objectmode = Ext.create('Ext.data.Store', {
        model:'cmbmodel_objectmode',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_objectmode/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_objectmode_loaded =true;}
       }
    });

 Ext.define('model_structrestriction',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'structrestrictionid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'allowadd', type: 'int'}
            ,{name:'allowadd_grid', type: 'string'}
            ,{name:'allowdelete', type: 'int'}
            ,{name:'allowdelete_grid', type: 'string'}
            ,{name:'allowread', type: 'int'}
            ,{name:'allowread_grid', type: 'string'}
            ,{name:'struct', type: 'string'}
            ,{name:'struct_grid', type: 'string'}
            ,{name:'allowedit', type: 'int'}
            ,{name:'allowedit_grid', type: 'string'}
        ]
    });


 Ext.define('model_methodrestriction',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'methodrestrictionid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'isrestricted', type: 'int'}
            ,{name:'isrestricted_grid', type: 'string'}
            ,{name:'part', type: 'string'}
            ,{name:'part_grid', type: 'string'}
            ,{name:'method', type: 'string'}
            ,{name:'method_grid', type: 'string'}
        ]
    });


 Ext.define('model_fieldrestriction',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'fieldrestrictionid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'mandatoryfield', type: 'int'}
            ,{name:'mandatoryfield_grid', type: 'string'}
            ,{name:'thefield', type: 'string'}
            ,{name:'thefield_grid', type: 'string'}
            ,{name:'thepart', type: 'string'}
            ,{name:'thepart_grid', type: 'string'}
            ,{name:'allowmodify', type: 'int'}
            ,{name:'allowmodify_grid', type: 'string'}
            ,{name:'allowread', type: 'int'}
            ,{name:'allowread_grid', type: 'string'}
        ]
    });


 Ext.define('model_typemenu',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'typemenuid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'caption', type: 'string'}
            ,{name:'tooltip', type: 'string'}
            ,{name:'ismenuitem', type: 'int'}
            ,{name:'ismenuitem_grid', type: 'string'}
            ,{name:'hotkey', type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'istoolbarbutton', type: 'int'}
            ,{name:'istoolbarbutton_grid', type: 'string'}
            ,{name:'the_action', type: 'string'}
            ,{name:'the_action_grid', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_typemenu',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'typemenuid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_typemenu_loaded=false;
    var cmbstore_typemenu = Ext.create('Ext.data.Store', {
        model:'cmbmodel_typemenu',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_typemenu/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_typemenu_loaded =true;}
       }
    });

 Ext.define('model_instancevalidator',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'instancevalidatorid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'target', type: 'string'}
            ,{name:'target_grid', type: 'string'}
            ,{name:'code', type: 'string'}
        ]
    });


 Ext.define('model_part',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'partid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name: 'parentrowid',type: 'string'}
            ,{name:'particoncls', type: 'string'}
            ,{name:'rulebrief', type: 'string'}
            ,{name:'integerpkey', type: 'int'}
            ,{name:'integerpkey_grid', type: 'string'}
            ,{name:'manualregister', type: 'int'}
            ,{name:'manualregister_grid', type: 'string'}
            ,{name:'ondelete', type: 'string'}
            ,{name:'ondelete_grid', type: 'string'}
            ,{name:'addbehaivor', type: 'int'}
            ,{name:'addbehaivor_grid', type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'onsave', type: 'string'}
            ,{name:'onsave_grid', type: 'string'}
            ,{name:'oncreate', type: 'string'}
            ,{name:'oncreate_grid', type: 'string'}
            ,{name:'the_comment', type: 'string'}
            ,{name:'usearchiving', type: 'int'}
            ,{name:'usearchiving_grid', type: 'string'}
            ,{name:'onrun', type: 'string'}
            ,{name:'onrun_grid', type: 'string'}
            ,{name:'extenderobject', type: 'string'}
            ,{name:'extenderobject_grid', type: 'string'}
            ,{name:'nolog', type: 'int'}
            ,{name:'nolog_grid', type: 'string'}
            ,{name:'shablonbrief', type: 'string'}
            ,{name:'parttype', type: 'int'}
            ,{name:'parttype_grid', type: 'string'}
            ,{name:'sequence', type: 'number'}
            ,{name:'isjormalchange', type: 'int'}
            ,{name:'isjormalchange_grid', type: 'string'}
            ,{name:'caption', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_part',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'partid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_part_loaded=false;
    var cmbstore_part = Ext.create('Ext.data.Store', {
        model:'cmbmodel_part',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_part/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_part_loaded =true;}
       }
    });

 Ext.define('model_partmenu',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'partmenuid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'the_action', type: 'string'}
            ,{name:'the_action_grid', type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'caption', type: 'string'}
            ,{name:'ismenuitem', type: 'int'}
            ,{name:'ismenuitem_grid', type: 'string'}
            ,{name:'istoolbarbutton', type: 'int'}
            ,{name:'istoolbarbutton_grid', type: 'string'}
            ,{name:'hotkey', type: 'string'}
            ,{name:'tooltip', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_partmenu',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'partmenuid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_partmenu_loaded=false;
    var cmbstore_partmenu = Ext.create('Ext.data.Store', {
        model:'cmbmodel_partmenu',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_partmenu/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_partmenu_loaded =true;}
       }
    });

 Ext.define('model_partparammap',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'partparammapid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'paramname', type: 'string'}
            ,{name:'fieldname', type: 'string'}
            ,{name:'noedit', type: 'int'}
            ,{name:'noedit_grid', type: 'string'}
        ]
    });


 Ext.define('model_partview',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'partviewid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'filterfield2', type: 'string'}
            ,{name:'filterfield0', type: 'string'}
            ,{name:'the_alias', type: 'string'}
            ,{name:'forchoose', type: 'int'}
            ,{name:'forchoose_grid', type: 'string'}
            ,{name:'filterfield1', type: 'string'}
            ,{name:'filterfield3', type: 'string'}
            ,{name:'name', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_partview',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'partviewid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_partview_loaded=false;
    var cmbstore_partview = Ext.create('Ext.data.Store', {
        model:'cmbmodel_partview',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_partview/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_partview_loaded =true;}
       }
    });

 Ext.define('model_viewcolumn',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'viewcolumnid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'forcombo', type: 'int'}
            ,{name:'forcombo_grid', type: 'string'}
            ,{name:'frompart', type: 'string'}
            ,{name:'frompart_grid', type: 'string'}
            ,{name:'aggregation', type: 'int'}
            ,{name:'aggregation_grid', type: 'string'}
            ,{name:'sequence', type: 'number'}
            ,{name:'the_alias', type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'field', type: 'string'}
            ,{name:'field_grid', type: 'string'}
            ,{name:'expression', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_viewcolumn',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'viewcolumnid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_viewcolumn_loaded=false;
    var cmbstore_viewcolumn = Ext.create('Ext.data.Store', {
        model:'cmbmodel_viewcolumn',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_viewcolumn/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_viewcolumn_loaded =true;}
       }
    });

 Ext.define('model_partview_lnk',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'partview_lnkid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'thejoindestination', type: 'string'}
            ,{name:'thejoindestination_grid', type: 'string'}
            ,{name:'handjoin', type: 'string'}
            ,{name:'seq', type: 'number'}
            ,{name:'thejoinsource', type: 'string'}
            ,{name:'thejoinsource_grid', type: 'string'}
            ,{name:'theview', type: 'string'}
            ,{name:'theview_grid', type: 'string'}
            ,{name:'reftype', type: 'int'}
            ,{name:'reftype_grid', type: 'string'}
        ]
    });


 Ext.define('model_validator',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'validatorid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'code', type: 'string'}
            ,{name:'target', type: 'string'}
            ,{name:'target_grid', type: 'string'}
        ]
    });


 Ext.define('model_uniqueconstraint',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'uniqueconstraintid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'thecomment', type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'perparent', type: 'int'}
            ,{name:'perparent_grid', type: 'string'}
        ]
    });


 Ext.define('model_constraintfield',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'constraintfieldid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'thefield', type: 'string'}
            ,{name:'thefield_grid', type: 'string'}
        ]
    });


 Ext.define('model_extenderinterface',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'extenderinterfaceid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'theconfig', type: 'string'}
            ,{name:'targetplatform', type: 'string'}
            ,{name:'targetplatform_grid', type: 'string'}
            ,{name:'theobject', type: 'string'}
            ,{name:'thename', type: 'string'}
        ]
    });


 Ext.define('model_field',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'fieldid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'allownull', type: 'int'}
            ,{name:'allownull_grid', type: 'string'}
            ,{name:'themask', type: 'string'}
            ,{name:'reftopart', type: 'string'}
            ,{name:'reftopart_grid', type: 'string'}
            ,{name:'tabname', type: 'string'}
            ,{name:'thenumerator', type: 'string'}
            ,{name:'thenumerator_grid', type: 'string'}
            ,{name:'shablonbrief', type: 'string'}
            ,{name:'datasize', type: 'number'}
            ,{name:'caption', type: 'string'}
            ,{name:'fieldgroupbox', type: 'string'}
            ,{name:'thestyle', type: 'string'}
            ,{name:'zonetemplate', type: 'string'}
            ,{name:'thecomment', type: 'string'}
            ,{name:'reftotype', type: 'string'}
            ,{name:'reftotype_grid', type: 'string'}
            ,{name:'isbrief', type: 'int'}
            ,{name:'isbrief_grid', type: 'string'}
            ,{name:'fieldtype', type: 'string'}
            ,{name:'fieldtype_grid', type: 'string'}
            ,{name:'isautonumber', type: 'int'}
            ,{name:'isautonumber_grid', type: 'string'}
            ,{name:'referencetype', type: 'int'}
            ,{name:'referencetype_grid', type: 'string'}
            ,{name:'sequence', type: 'number'}
            ,{name:'internalreference', type: 'int'}
            ,{name:'internalreference_grid', type: 'string'}
            ,{name:'createrefonly', type: 'int'}
            ,{name:'createrefonly_grid', type: 'string'}
            ,{name:'istabbrief', type: 'int'}
            ,{name:'istabbrief_grid', type: 'string'}
            ,{name:'thenameclass', type: 'string'}
            ,{name:'numberdatefield', type: 'string'}
            ,{name:'numberdatefield_grid', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_field',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'fieldid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_field_loaded=false;
    var cmbstore_field = Ext.create('Ext.data.Store', {
        model:'cmbmodel_field',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_field/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_field_loaded =true;}
       }
    });

 Ext.define('model_fldextenders',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'fldextendersid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'theobject', type: 'string'}
            ,{name:'thename', type: 'string'}
            ,{name:'targetplatform', type: 'string'}
            ,{name:'targetplatform_grid', type: 'string'}
            ,{name:'theconfig', type: 'string'}
        ]
    });


 Ext.define('model_fieldsrcdef',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'fieldsrcdefid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'connectionstring', type: 'string'}
            ,{name:'descriptionstring', type: 'string'}
            ,{name:'sortfield', type: 'string'}
            ,{name:'provider', type: 'string'}
            ,{name:'filterstring', type: 'string'}
            ,{name:'datasource', type: 'string'}
            ,{name:'dontshowdialog', type: 'int'}
            ,{name:'dontshowdialog_grid', type: 'string'}
            ,{name:'briefstring', type: 'string'}
            ,{name:'idfield', type: 'string'}
        ]
    });


 Ext.define('model_dinamicfilterscript',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'dinamicfilterscriptid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'target', type: 'string'}
            ,{name:'target_grid', type: 'string'}
            ,{name:'code', type: 'string'}
        ]
    });


 Ext.define('model_fieldexpression',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'fieldexpressionid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'code', type: 'string'}
            ,{name:'target', type: 'string'}
            ,{name:'target_grid', type: 'string'}
        ]
    });


 Ext.define('model_fieldvalidator',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'fieldvalidatorid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'code', type: 'string'}
            ,{name:'target', type: 'string'}
            ,{name:'target_grid', type: 'string'}
        ]
    });


 Ext.define('model_fieldmenu',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'fieldmenuid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'caption', type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'hotkey', type: 'string'}
            ,{name:'tooltip', type: 'string'}
            ,{name:'actionid', type: 'string'}
            ,{name:'actionid_grid', type: 'string'}
            ,{name:'ismenuitem', type: 'int'}
            ,{name:'ismenuitem_grid', type: 'string'}
            ,{name:'istoolbarbutton', type: 'int'}
            ,{name:'istoolbarbutton_grid', type: 'string'}
        ]
    });


 Ext.define('model_fieldparammap',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'fieldparammapid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'noedit', type: 'int'}
            ,{name:'noedit_grid', type: 'string'}
            ,{name:'paramname', type: 'string'}
            ,{name:'fieldname', type: 'string'}
        ]
    });


 Ext.define('model_mtzapp',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'mtzappid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'dbname', type: 'string'}
            ,{name:'thecomment', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_mtzapp',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'mtzappid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_mtzapp_loaded=false;
    var cmbstore_mtzapp = Ext.create('Ext.data.Store', {
        model:'cmbmodel_mtzapp',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_mtzapp/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_mtzapp_loaded =true;}
       }
    });

 Ext.define('model_parentpackage',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'parentpackageid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'package', type: 'string'}
            ,{name:'package_grid', type: 'string'}
        ]
    });


 Ext.define('model_rptstruct',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'rptstructid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name: 'parentrowid',type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'caption', type: 'string'}
        ]
    });


 Ext.define('model_rptfields',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'rptfieldsid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'fieldtype', type: 'string'}
            ,{name:'fieldtype_grid', type: 'string'}
            ,{name:'fieldsize', type: 'number'}
            ,{name:'caption', type: 'string'}
            ,{name:'name', type: 'string'}
        ]
    });


 Ext.define('model_rptformula',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'rptformulaid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'platform', type: 'string'}
            ,{name:'platform_grid', type: 'string'}
            ,{name:'code', type: 'string'}
            ,{name:'name', type: 'string'}
        ]
    });


 Ext.define('model_reports',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'reportsid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'preparemethod', type: 'string'}
            ,{name:'preparemethod_grid', type: 'string'}
            ,{name:'caption', type: 'string'}
            ,{name:'reporttype', type: 'int'}
            ,{name:'reporttype_grid', type: 'string'}
            ,{name:'thecomment', type: 'string'}
            ,{name:'reportfile', type: 'string'}
            ,{name:'reportfile_ext', type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'reportview', type: 'string'}
            ,{name:'thereportext', type: 'string'}
            ,{name:'thereportext_grid', type: 'string'}
        ]
    });


 Ext.define('model_the_session',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'the_sessionid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'login', type: 'string'}
            ,{name:'userrole', type: 'string'}
            ,{name:'userrole_grid', type: 'string'}
            ,{name:'lastaccess', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'usersid', type: 'string'}
            ,{name:'usersid_grid', type: 'string'}
            ,{name:'closed', type: 'int'}
            ,{name:'closed_grid', type: 'string'}
            ,{name:'startat', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'closedat', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'applicationid', type: 'string'}
            ,{name:'applicationid_grid', type: 'string'}
            ,{name:'lang', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_the_session',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'the_sessionid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_the_session_loaded=false;
    var cmbstore_the_session = Ext.create('Ext.data.Store', {
        model:'cmbmodel_the_session',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_the_session/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_the_session_loaded =true;}
       }
    });

 Ext.define('model_sysrefcache',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'sysrefcacheid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'modulename', type: 'string'}
            ,{name:'objectownerid', type: 'string'}
            ,{name:'sessionid', type: 'string'}
            ,{name:'sessionid_grid', type: 'string'}
            ,{name:'cachetype', type: 'int'}
            ,{name:'cachetype_grid', type: 'string'}
        ]
    });


 Ext.define('model_syslog',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'syslogid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'the_resource', type: 'string'}
            ,{name:'verb', type: 'string'}
            ,{name:'loginstanceid', type: 'string'}
            ,{name:'logstructid', type: 'string'}
            ,{name:'thesession', type: 'string'}
            ,{name:'thesession_grid', type: 'string'}
        ]
    });


 Ext.define('model_users',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'usersid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'family', type: 'string'}
            ,{name:'login', type: 'string'}
            ,{name:'password', type: 'string'}
            ,{name:'email', type: 'string'}
            ,{name:'phone', type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'domainame', type: 'string'}
            ,{name:'localphone', type: 'string'}
            ,{name:'surname', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_users',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'usersid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_users_loaded=false;
    var cmbstore_users = Ext.create('Ext.data.Store', {
        model:'cmbmodel_users',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_users/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_users_loaded =true;}
       }
    });

 Ext.define('model_groups',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'groupsid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'adgroup', type: 'string'}
            ,{name:'name', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_groups',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'groupsid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_groups_loaded=false;
    var cmbstore_groups = Ext.create('Ext.data.Store', {
        model:'cmbmodel_groups',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_groups/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_groups_loaded =true;}
       }
    });

 Ext.define('model_groupuser',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'groupuserid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'theuser', type: 'string'}
            ,{name:'theuser_grid', type: 'string'}
        ]
    });


 Ext.define('model_armjournal',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'armjournalid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'thejournal', type: 'string'}
            ,{name:'thejournal_grid', type: 'string'}
        ]
    });


 Ext.define('model_armjrnlrep',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'armjrnlrepid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'repname', type: 'string'}
            ,{name:'thereport', type: 'string'}
            ,{name:'thereport_grid', type: 'string'}
        ]
    });


 Ext.define('model_armjrnlrun',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'armjrnlrunid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'theextention', type: 'string'}
            ,{name:'theextention_grid', type: 'string'}
            ,{name:'name', type: 'string'}
        ]
    });


 Ext.define('model_armjrnladd',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'armjrnladdid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'theextention', type: 'string'}
            ,{name:'theextention_grid', type: 'string'}
            ,{name:'name', type: 'string'}
        ]
    });


 Ext.define('model_entrypoints',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'entrypointsid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name: 'parentrowid',type: 'string'}
            ,{name:'thecomment', type: 'string'}
            ,{name:'allowprint', type: 'int'}
            ,{name:'allowprint_grid', type: 'string'}
            ,{name:'iconfile', type: 'string'}
            ,{name:'allowfilter', type: 'int'}
            ,{name:'allowfilter_grid', type: 'string'}
            ,{name:'thefilter', type: 'string'}
            ,{name:'thefilter_grid', type: 'string'}
            ,{name:'journalfixedquery', type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'report', type: 'string'}
            ,{name:'report_grid', type: 'string'}
            ,{name:'document', type: 'string'}
            ,{name:'document_grid', type: 'string'}
            ,{name:'caption', type: 'string'}
            ,{name:'theextention', type: 'string'}
            ,{name:'theextention_grid', type: 'string'}
            ,{name:'arm', type: 'string'}
            ,{name:'arm_grid', type: 'string'}
            ,{name:'objecttype', type: 'string'}
            ,{name:'objecttype_grid', type: 'string'}
            ,{name:'allowadd', type: 'int'}
            ,{name:'allowadd_grid', type: 'string'}
            ,{name:'journal', type: 'string'}
            ,{name:'journal_grid', type: 'string'}
            ,{name:'method', type: 'string'}
            ,{name:'method_grid', type: 'string'}
            ,{name:'allowedit', type: 'int'}
            ,{name:'allowedit_grid', type: 'string'}
            ,{name:'allowdel', type: 'int'}
            ,{name:'allowdel_grid', type: 'string'}
            ,{name:'astoolbaritem', type: 'int'}
            ,{name:'astoolbaritem_grid', type: 'string'}
            ,{name:'actiontype', type: 'int'}
            ,{name:'actiontype_grid', type: 'string'}
            ,{name:'sequence', type: 'number'}
        ]
    });


 Ext.define('model_epfilterlink',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'epfilterlinkid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'rowsource', type: 'string'}
            ,{name:'theexpression', type: 'string'}
            ,{name:'filterfield', type: 'string'}
        ]
    });


 Ext.define('model_workplace',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'workplaceid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'thecomment', type: 'string'}
            ,{name:'theversion', type: 'string'}
            ,{name:'caption', type: 'string'}
            ,{name:'theplatform', type: 'int'}
            ,{name:'theplatform_grid', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_workplace',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'workplaceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_workplace_loaded=false;
    var cmbstore_workplace = Ext.create('Ext.data.Store', {
        model:'cmbmodel_workplace',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_workplace/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_workplace_loaded =true;}
       }
    });

 Ext.define('model_armtypes',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'armtypesid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'thedocumenttype', type: 'string'}
            ,{name:'thedocumenttype_grid', type: 'string'}
        ]
    });


 Ext.define('model_num_zones',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'num_zonesid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'zonemask', type: 'string'}
        ]
    });


 Ext.define('model_num_values',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'num_valuesid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'parentid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'the_value', type: 'number'}
            ,{name:'ownerrowid', type: 'string'}
            ,{name:'ownerpartname', type: 'string'}
        ]
    });


 Ext.define('model_num_head',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'num_headid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'shema', type: 'int'}
            ,{name:'shema_grid', type: 'string'}
        ]
    });


 Ext.define('model_tplc_e',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tplc_eid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'dcall', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'u2', type: 'number'}
            ,{name:'e0s', type: 'number'}
            ,{name:'i2', type: 'number'}
            ,{name:'am', type: 'number'}
            ,{name:'worktime', type: 'number'}
            ,{name:'errinfo', type: 'string'}
            ,{name:'e1s', type: 'number'}
            ,{name:'i3', type: 'number'}
            ,{name:'e1', type: 'number'}
            ,{name:'rm', type: 'number'}
            ,{name:'u1', type: 'number'}
            ,{name:'dcounter', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'e2', type: 'number'}
            ,{name:'i1', type: 'number'}
            ,{name:'ap', type: 'number'}
            ,{name:'e2s', type: 'number'}
            ,{name:'u3', type: 'number'}
            ,{name:'e3s', type: 'number'}
            ,{name:'e0', type: 'number'}
            ,{name:'e3', type: 'number'}
            ,{name:'oktime', type: 'number'}
            ,{name:'e4s', type: 'number'}
            ,{name:'rp', type: 'number'}
            ,{name:'e4', type: 'number'}
        ]
    });


 Ext.define('model_tplc_m',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tplc_mid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'v4', type: 'number'}
            ,{name:'errtime', type: 'number'}
            ,{name:'check_a', type: 'number'}
            ,{name:'p4', type: 'number'}
            ,{name:'dq', type: 'number'}
            ,{name:'v5h', type: 'number'}
            ,{name:'v3', type: 'number'}
            ,{name:'dp45', type: 'number'}
            ,{name:'dv45', type: 'number'}
            ,{name:'g4', type: 'number'}
            ,{name:'v6', type: 'number'}
            ,{name:'dp12', type: 'number'}
            ,{name:'dans6', type: 'number'}
            ,{name:'m6', type: 'number'}
            ,{name:'hc_2', type: 'string'}
            ,{name:'g6', type: 'number'}
            ,{name:'tce2', type: 'number'}
            ,{name:'dans1', type: 'number'}
            ,{name:'tce1', type: 'number'}
            ,{name:'t5', type: 'number'}
            ,{name:'dans5', type: 'number'}
            ,{name:'g2', type: 'number'}
            ,{name:'sp_tb2', type: 'number'}
            ,{name:'v5', type: 'number'}
            ,{name:'q4', type: 'number'}
            ,{name:'q2', type: 'number'}
            ,{name:'m5', type: 'number'}
            ,{name:'q5', type: 'number'}
            ,{name:'t6', type: 'number'}
            ,{name:'t3', type: 'number'}
            ,{name:'worktime', type: 'number'}
            ,{name:'p5', type: 'number'}
            ,{name:'q2h', type: 'number'}
            ,{name:'v1', type: 'number'}
            ,{name:'g1', type: 'number'}
            ,{name:'q3', type: 'number'}
            ,{name:'v2h', type: 'number'}
            ,{name:'m1', type: 'number'}
            ,{name:'q1h', type: 'number'}
            ,{name:'sp', type: 'number'}
            ,{name:'dm45', type: 'number'}
            ,{name:'tsum2', type: 'number'}
            ,{name:'dcall', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'hc_code', type: 'string'}
            ,{name:'dq12', type: 'number'}
            ,{name:'unitsr', type: 'string'}
            ,{name:'v4h', type: 'number'}
            ,{name:'sp_tb1', type: 'number'}
            ,{name:'oktime', type: 'number'}
            ,{name:'patm', type: 'number'}
            ,{name:'tair2', type: 'number'}
            ,{name:'datetimecounter', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'p2', type: 'number'}
            ,{name:'dans4', type: 'number'}
            ,{name:'dans2', type: 'number'}
            ,{name:'dm12', type: 'number'}
            ,{name:'tsum1', type: 'number'}
            ,{name:'hc', type: 'string'}
            ,{name:'dt12', type: 'number'}
            ,{name:'dcounter', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'m4', type: 'number'}
            ,{name:'dg12', type: 'number'}
            ,{name:'thot', type: 'number'}
            ,{name:'p1', type: 'number'}
            ,{name:'t4', type: 'number'}
            ,{name:'dans3', type: 'number'}
            ,{name:'q1', type: 'number'}
            ,{name:'t2', type: 'number'}
            ,{name:'g5', type: 'number'}
            ,{name:'dg45', type: 'number'}
            ,{name:'p3', type: 'number'}
            ,{name:'m2', type: 'number'}
            ,{name:'tcool', type: 'number'}
            ,{name:'t1', type: 'number'}
            ,{name:'dt45', type: 'number'}
            ,{name:'dv12', type: 'number'}
            ,{name:'hc_1', type: 'string'}
            ,{name:'pxb', type: 'number'}
            ,{name:'v1h', type: 'number'}
            ,{name:'errtimeh', type: 'number'}
            ,{name:'g3', type: 'number'}
            ,{name:'v2', type: 'number'}
            ,{name:'dq45', type: 'number'}
            ,{name:'m3', type: 'number'}
            ,{name:'p6', type: 'number'}
            ,{name:'tair1', type: 'number'}
        ]
    });

 Ext.define('cmbmodel_tplc_m',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tplc_mid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_tplc_m_loaded=false;
    var cmbstore_tplc_m = Ext.create('Ext.data.Store', {
        model:'cmbmodel_tplc_m',
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
            }
        },
       listeners: {
       'load': function(){combo_tplc_m_loaded =true;}
       }
    });

 Ext.define('model_tplc_header',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tplc_headerid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'id_bd', type: 'string'}
            ,{name:'id_bd_grid', type: 'string'}
        ]
    });


 Ext.define('model_tplc_d',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tplc_did',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'g5', type: 'number'}
            ,{name:'worktime', type: 'number'}
            ,{name:'m5', type: 'number'}
            ,{name:'q1h', type: 'number'}
            ,{name:'dans3', type: 'number'}
            ,{name:'dv12', type: 'number'}
            ,{name:'g3', type: 'number'}
            ,{name:'v2', type: 'number'}
            ,{name:'p4', type: 'number'}
            ,{name:'q2h', type: 'number'}
            ,{name:'dg45', type: 'number'}
            ,{name:'m3', type: 'number'}
            ,{name:'tsum1', type: 'number'}
            ,{name:'q4', type: 'number'}
            ,{name:'v3', type: 'number'}
            ,{name:'datetimecounter', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'m1', type: 'number'}
            ,{name:'g4', type: 'number'}
            ,{name:'sp_tb1', type: 'number'}
            ,{name:'dcall', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'p1', type: 'number'}
            ,{name:'sp', type: 'number'}
            ,{name:'q3', type: 'number'}
            ,{name:'dq', type: 'number'}
            ,{name:'hc_code', type: 'string'}
            ,{name:'t1', type: 'number'}
            ,{name:'dans1', type: 'number'}
            ,{name:'dm12', type: 'number'}
            ,{name:'errtime', type: 'number'}
            ,{name:'g2', type: 'number'}
            ,{name:'g6', type: 'number'}
            ,{name:'oktime', type: 'number'}
            ,{name:'tcool', type: 'number'}
            ,{name:'dans4', type: 'number'}
            ,{name:'dt45', type: 'number'}
            ,{name:'dt12', type: 'number'}
            ,{name:'dm45', type: 'number'}
            ,{name:'m4', type: 'number'}
            ,{name:'dq12', type: 'number'}
            ,{name:'dq45', type: 'number'}
            ,{name:'sp_tb2', type: 'number'}
            ,{name:'v5', type: 'number'}
            ,{name:'v4h', type: 'number'}
            ,{name:'dans6', type: 'number'}
            ,{name:'hc', type: 'string'}
            ,{name:'v4', type: 'number'}
            ,{name:'v5h', type: 'number'}
            ,{name:'tair1', type: 'number'}
            ,{name:'g1', type: 'number'}
            ,{name:'dp45', type: 'number'}
            ,{name:'q5', type: 'number'}
            ,{name:'v6', type: 'number'}
            ,{name:'q1', type: 'number'}
            ,{name:'patm', type: 'number'}
            ,{name:'v1', type: 'number'}
            ,{name:'t2', type: 'number'}
            ,{name:'tce2', type: 'number'}
            ,{name:'t3', type: 'number'}
            ,{name:'p6', type: 'number'}
            ,{name:'pxb', type: 'number'}
            ,{name:'tce1', type: 'number'}
            ,{name:'dp12', type: 'number'}
            ,{name:'p3', type: 'number'}
            ,{name:'v2h', type: 'number'}
            ,{name:'t5', type: 'number'}
            ,{name:'check_a', type: 'number'}
            ,{name:'dans2', type: 'number'}
            ,{name:'m2', type: 'number'}
            ,{name:'t6', type: 'number'}
            ,{name:'t4', type: 'number'}
            ,{name:'v1h', type: 'number'}
            ,{name:'errtimeh', type: 'number'}
            ,{name:'p5', type: 'number'}
            ,{name:'dans5', type: 'number'}
            ,{name:'m6', type: 'number'}
            ,{name:'hc_1', type: 'string'}
            ,{name:'hc_2', type: 'string'}
            ,{name:'dv45', type: 'number'}
            ,{name:'unitsr', type: 'string'}
            ,{name:'thot', type: 'number'}
            ,{name:'q2', type: 'number'}
            ,{name:'tsum2', type: 'number'}
            ,{name:'p2', type: 'number'}
            ,{name:'dg12', type: 'number'}
            ,{name:'tair2', type: 'number'}
            ,{name:'dcounter', type: 'date',dateFormat:'Y-m-d H:i:s'}
        ]
    });

 Ext.define('cmbmodel_tplc_d',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tplc_did',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_tplc_d_loaded=false;
    var cmbstore_tplc_d = Ext.create('Ext.data.Store', {
        model:'cmbmodel_tplc_d',
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
            }
        },
       listeners: {
       'load': function(){combo_tplc_d_loaded =true;}
       }
    });

 Ext.define('model_tplc_h',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tplc_hid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'q5', type: 'number'}
            ,{name:'datetimecounter', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'dg45', type: 'number'}
            ,{name:'m1', type: 'number'}
            ,{name:'tair2', type: 'number'}
            ,{name:'dv45', type: 'number'}
            ,{name:'dans4', type: 'number'}
            ,{name:'v1h', type: 'number'}
            ,{name:'dt45', type: 'number'}
            ,{name:'hc', type: 'string'}
            ,{name:'errtimeh', type: 'number'}
            ,{name:'unitsr', type: 'string'}
            ,{name:'patm', type: 'number'}
            ,{name:'q3', type: 'number'}
            ,{name:'dm45', type: 'number'}
            ,{name:'dp12', type: 'number'}
            ,{name:'check_a', type: 'number'}
            ,{name:'m4', type: 'number'}
            ,{name:'p6', type: 'number'}
            ,{name:'p5', type: 'number'}
            ,{name:'t4', type: 'number'}
            ,{name:'tcool', type: 'number'}
            ,{name:'v3', type: 'number'}
            ,{name:'v4h', type: 'number'}
            ,{name:'dans5', type: 'number'}
            ,{name:'dans1', type: 'number'}
            ,{name:'g5', type: 'number'}
            ,{name:'hc_code', type: 'string'}
            ,{name:'dcall', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'dq45', type: 'number'}
            ,{name:'v1', type: 'number'}
            ,{name:'q4', type: 'number'}
            ,{name:'sp_tb1', type: 'number'}
            ,{name:'t6', type: 'number'}
            ,{name:'p3', type: 'number'}
            ,{name:'dq12', type: 'number'}
            ,{name:'q1', type: 'number'}
            ,{name:'v4', type: 'number'}
            ,{name:'m6', type: 'number'}
            ,{name:'dcounter', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'m2', type: 'number'}
            ,{name:'t5', type: 'number'}
            ,{name:'errtime', type: 'number'}
            ,{name:'dm12', type: 'number'}
            ,{name:'p4', type: 'number'}
            ,{name:'tce2', type: 'number'}
            ,{name:'g4', type: 'number'}
            ,{name:'v5', type: 'number'}
            ,{name:'q2', type: 'number'}
            ,{name:'g6', type: 'number'}
            ,{name:'dv12', type: 'number'}
            ,{name:'dt12', type: 'number'}
            ,{name:'sp', type: 'number'}
            ,{name:'dq', type: 'number'}
            ,{name:'thot', type: 'number'}
            ,{name:'t2', type: 'number'}
            ,{name:'p2', type: 'number'}
            ,{name:'tce1', type: 'number'}
            ,{name:'tair1', type: 'number'}
            ,{name:'dg12', type: 'number'}
            ,{name:'g2', type: 'number'}
            ,{name:'tsum1', type: 'number'}
            ,{name:'tsum2', type: 'number'}
            ,{name:'v2', type: 'number'}
            ,{name:'dans2', type: 'number'}
            ,{name:'pxb', type: 'number'}
            ,{name:'m3', type: 'number'}
            ,{name:'v5h', type: 'number'}
            ,{name:'oktime', type: 'number'}
            ,{name:'dans6', type: 'number'}
            ,{name:'dans3', type: 'number'}
            ,{name:'sp_tb2', type: 'number'}
            ,{name:'t1', type: 'number'}
            ,{name:'dp45', type: 'number'}
            ,{name:'t3', type: 'number'}
            ,{name:'v6', type: 'number'}
            ,{name:'p1', type: 'number'}
            ,{name:'g3', type: 'number'}
            ,{name:'hc_2', type: 'string'}
            ,{name:'q2h', type: 'number'}
            ,{name:'v2h', type: 'number'}
            ,{name:'q1h', type: 'number'}
            ,{name:'g1', type: 'number'}
            ,{name:'hc_1', type: 'string'}
            ,{name:'m5', type: 'number'}
            ,{name:'worktime', type: 'number'}
        ]
    });

 Ext.define('cmbmodel_tplc_h',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tplc_hid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_tplc_h_loaded=false;
    var cmbstore_tplc_h = Ext.create('Ext.data.Store', {
        model:'cmbmodel_tplc_h',
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
            }
        },
       listeners: {
       'load': function(){combo_tplc_h_loaded =true;}
       }
    });

 Ext.define('model_tplc_missing',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tplc_missingid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'adate', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'querycount', type: 'number'}
            ,{name:'atype', type: 'string'}
            ,{name:'atype_grid', type: 'string'}
        ]
    });


 Ext.define('model_tplc_t',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tplc_tid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'g3', type: 'number'}
            ,{name:'t6', type: 'number'}
            ,{name:'v4h', type: 'number'}
            ,{name:'p2', type: 'number'}
            ,{name:'pxb', type: 'number'}
            ,{name:'dv45', type: 'number'}
            ,{name:'v2h', type: 'number'}
            ,{name:'q5', type: 'number'}
            ,{name:'p3', type: 'number'}
            ,{name:'t2', type: 'number'}
            ,{name:'q2', type: 'number'}
            ,{name:'tsum2', type: 'number'}
            ,{name:'v1h', type: 'number'}
            ,{name:'dq', type: 'number'}
            ,{name:'tair1', type: 'number'}
            ,{name:'dt45', type: 'number'}
            ,{name:'dq12', type: 'number'}
            ,{name:'errtimeh', type: 'number'}
            ,{name:'m3', type: 'number'}
            ,{name:'unitsr', type: 'string'}
            ,{name:'v5', type: 'number'}
            ,{name:'tce1', type: 'number'}
            ,{name:'q1', type: 'number'}
            ,{name:'dq45', type: 'number'}
            ,{name:'sp_tb1', type: 'number'}
            ,{name:'dcall', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'dm45', type: 'number'}
            ,{name:'v1', type: 'number'}
            ,{name:'t4', type: 'number'}
            ,{name:'m4', type: 'number'}
            ,{name:'thot', type: 'number'}
            ,{name:'g6', type: 'number'}
            ,{name:'sp', type: 'number'}
            ,{name:'sp_tb2', type: 'number'}
            ,{name:'datetimecounter', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'q2h', type: 'number'}
            ,{name:'t5', type: 'number'}
            ,{name:'v6', type: 'number'}
            ,{name:'dp45', type: 'number'}
            ,{name:'m6', type: 'number'}
            ,{name:'v4', type: 'number'}
            ,{name:'hc_1', type: 'string'}
            ,{name:'g1', type: 'number'}
            ,{name:'dans1', type: 'number'}
            ,{name:'dans6', type: 'number'}
            ,{name:'m1', type: 'number'}
            ,{name:'check_a', type: 'number'}
            ,{name:'patm', type: 'number'}
            ,{name:'dp12', type: 'number'}
            ,{name:'errtime', type: 'number'}
            ,{name:'tcool', type: 'number'}
            ,{name:'q1h', type: 'number'}
            ,{name:'g4', type: 'number'}
            ,{name:'dt12', type: 'number'}
            ,{name:'v3', type: 'number'}
            ,{name:'dg12', type: 'number'}
            ,{name:'t1', type: 'number'}
            ,{name:'dm12', type: 'number'}
            ,{name:'p4', type: 'number'}
            ,{name:'g2', type: 'number'}
            ,{name:'worktime', type: 'number'}
            ,{name:'p1', type: 'number'}
            ,{name:'m2', type: 'number'}
            ,{name:'tair2', type: 'number'}
            ,{name:'p5', type: 'number'}
            ,{name:'m5', type: 'number'}
            ,{name:'t3', type: 'number'}
            ,{name:'tsum1', type: 'number'}
            ,{name:'q3', type: 'number'}
            ,{name:'dans3', type: 'number'}
            ,{name:'tce2', type: 'number'}
            ,{name:'oktime', type: 'number'}
            ,{name:'v2', type: 'number'}
            ,{name:'g5', type: 'number'}
            ,{name:'hc_2', type: 'string'}
            ,{name:'hc', type: 'string'}
            ,{name:'dcounter', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'dg45', type: 'number'}
            ,{name:'dans5', type: 'number'}
            ,{name:'v5h', type: 'number'}
            ,{name:'q4', type: 'number'}
            ,{name:'dans4', type: 'number'}
            ,{name:'dans2', type: 'number'}
            ,{name:'hc_code', type: 'string'}
            ,{name:'p6', type: 'number'}
            ,{name:'dv12', type: 'number'}
        ]
    });

 Ext.define('cmbmodel_tplc_t',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tplc_tid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_tplc_t_loaded=false;
    var cmbstore_tplc_t = Ext.create('Ext.data.Store', {
        model:'cmbmodel_tplc_t',
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
            }
        },
       listeners: {
       'load': function(){combo_tplc_t_loaded =true;}
       }
    });

 Ext.define('model_tpld_connecttype',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpld_connecttypeid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'name', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_tpld_connecttype',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpld_connecttypeid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_tpld_connecttype_loaded=false;
    var cmbstore_tpld_connecttype = Ext.create('Ext.data.Store', {
        model:'cmbmodel_tpld_connecttype',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpld_connecttype/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_tpld_connecttype_loaded =true;}
       }
    });

 Ext.define('model_tpld_devclass',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpld_devclassid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'name', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_tpld_devclass',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpld_devclassid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_tpld_devclass_loaded=false;
    var cmbstore_tpld_devclass = Ext.create('Ext.data.Store', {
        model:'cmbmodel_tpld_devclass',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpld_devclass/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_tpld_devclass_loaded =true;}
       }
    });

 Ext.define('model_tpld_f',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpld_fid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'name', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_tpld_f',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpld_fid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_tpld_f_loaded=false;
    var cmbstore_tpld_f = Ext.create('Ext.data.Store', {
        model:'cmbmodel_tpld_f',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpld_f/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_tpld_f_loaded =true;}
       }
    });

 Ext.define('model_tpld_snab',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpld_snabid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'caddress', type: 'string'}
            ,{name:'cphone', type: 'string'}
            ,{name:'cfio', type: 'string'}
            ,{name:'cregion', type: 'string'}
            ,{name:'supplier', type: 'string'}
            ,{name:'supplier_grid', type: 'string'}
            ,{name:'cname', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_tpld_snab',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpld_snabid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_tpld_snab_loaded=false;
    var cmbstore_tpld_snab = Ext.create('Ext.data.Store', {
        model:'cmbmodel_tpld_snab',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpld_snab/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_tpld_snab_loaded =true;}
       }
    });

 Ext.define('model_tpld_paramtype',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpld_paramtypeid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'thecode', type: 'string'}
            ,{name:'name', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_tpld_paramtype',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpld_paramtypeid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_tpld_paramtype_loaded=false;
    var cmbstore_tpld_paramtype = Ext.create('Ext.data.Store', {
        model:'cmbmodel_tpld_paramtype',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpld_paramtype/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_tpld_paramtype_loaded =true;}
       }
    });

 Ext.define('model_tpld_grp',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpld_grpid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'cgrpnm', type: 'string'}
            ,{name:'theclient', type: 'string'}
            ,{name:'theclient_grid', type: 'string'}
            ,{name:'ctxt', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_tpld_grp',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpld_grpid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_tpld_grp_loaded=false;
    var cmbstore_tpld_grp = Ext.create('Ext.data.Store', {
        model:'cmbmodel_tpld_grp',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpld_grp/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_tpld_grp_loaded =true;}
       }
    });

 Ext.define('model_tpld_snabtop',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpld_snabtopid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'cphone', type: 'string'}
            ,{name:'cfio', type: 'string'}
            ,{name:'cname', type: 'string'}
            ,{name:'caddress', type: 'string'}
            ,{name:'cregion', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_tpld_snabtop',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpld_snabtopid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_tpld_snabtop_loaded=false;
    var cmbstore_tpld_snabtop = Ext.create('Ext.data.Store', {
        model:'cmbmodel_tpld_snabtop',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpld_snabtop/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_tpld_snabtop_loaded =true;}
       }
    });

 Ext.define('model_tpld_param',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpld_paramid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'paramfield', type: 'string'}
            ,{name:'showas', type: 'int'}
            ,{name:'showas_grid', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_tpld_param',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpld_paramid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_tpld_param_loaded=false;
    var cmbstore_tpld_param = Ext.create('Ext.data.Store', {
        model:'cmbmodel_tpld_param',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpld_param/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_tpld_param_loaded =true;}
       }
    });

 Ext.define('model_tpld_devtype',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpld_devtypeid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'driverlibname', type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'devclass', type: 'string'}
            ,{name:'devclass_grid', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_tpld_devtype',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpld_devtypeid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_tpld_devtype_loaded=false;
    var cmbstore_tpld_devtype = Ext.create('Ext.data.Store', {
        model:'cmbmodel_tpld_devtype',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpld_devtype/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_tpld_devtype_loaded =true;}
       }
    });

 Ext.define('model_tpls_info',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpls_infoid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'schema_imagefile', type: 'string'}
            ,{name:'schema_imagefile_ext', type: 'string'}
            ,{name:'name', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_tpls_info',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpls_infoid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_tpls_info_loaded=false;
    var cmbstore_tpls_info = Ext.create('Ext.data.Store', {
        model:'cmbmodel_tpls_info',
        autoLoad: false,
        autoSync: false,
        proxy: {
            type:   'ajax',
                url:   rootURL+'index.php/c_tpls_info/getRows',
            reader: {
                type:   'json'
                ,root:  'data'
                ,successProperty:  'success'
                ,messageProperty:  'msg'
            }
        },
       listeners: {
       'load': function(){combo_tpls_info_loaded =true;}
       }
    });

 Ext.define('model_tpls_param',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpls_paramid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'hideparam', type: 'int'}
            ,{name:'hideparam_grid', type: 'string'}
            ,{name:'archtype', type: 'string'}
            ,{name:'archtype_grid', type: 'string'}
            ,{name:'pos_left', type: 'number'}
            ,{name:'param', type: 'string'}
            ,{name:'param_grid', type: 'string'}
            ,{name:'hideonschema', type: 'int'}
            ,{name:'hideonschema_grid', type: 'string'}
            ,{name:'pos_top', type: 'number'}
        ]
    });


 Ext.define('model_tplt_reports',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tplt_reportsid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'thefile', type: 'string'}
            ,{name:'thefile_ext', type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'reptype', type: 'string'}
            ,{name:'reptype_grid', type: 'string'}
        ]
    });


 Ext.define('model_tplt_connect',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tplt_connectid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'cparity', type: 'int'}
            ,{name:'cparity_grid', type: 'string'}
            ,{name:'connectionenabled', type: 'int'}
            ,{name:'connectionenabled_grid', type: 'string'}
            ,{name:'ipaddr', type: 'string'}
            ,{name:'comportnum', type: 'string'}
            ,{name:'cdatabit', type: 'string'}
            ,{name:'portnum', type: 'number'}
            ,{name:'cspeed', type: 'string'}
            ,{name:'callerid', type: 'string'}
            ,{name:'cphone', type: 'string'}
            ,{name:'username', type: 'string'}
            ,{name:'ctowncode', type: 'string'}
            ,{name:'netaddr', type: 'number'}
            ,{name:'password', type: 'string'}
            ,{name:'atcommand', type: 'string'}
            ,{name:'connecttype', type: 'string'}
            ,{name:'connecttype_grid', type: 'string'}
            ,{name:'flowcontrol', type: 'string'}
            ,{name:'theserver', type: 'string'}
            ,{name:'theserver_grid', type: 'string'}
            ,{name:'connectlimit', type: 'number'}
            ,{name:'cstopbits', type: 'number'}
        ]
    });


 Ext.define('model_tplt_valuebounds',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tplt_valueboundsid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'pmax', type: 'number'}
            ,{name:'pmin', type: 'number'}
            ,{name:'ismin', type: 'int'}
            ,{name:'ismin_grid', type: 'string'}
            ,{name:'ptype', type: 'string'}
            ,{name:'ptype_grid', type: 'string'}
            ,{name:'pname', type: 'string'}
            ,{name:'pname_grid', type: 'string'}
            ,{name:'ismax', type: 'int'}
            ,{name:'ismax_grid', type: 'string'}
        ]
    });


 Ext.define('model_tplt_plancall',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tplt_plancallid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'nmaxcall', type: 'number'}
            ,{name:'numhour', type: 'number'}
            ,{name:'dnextel', type: 'date',dateFormat:'Y-m-d'}
            ,{name:'csum', type: 'int'}
            ,{name:'csum_grid', type: 'string'}
            ,{name:'dnextcurr', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'dlasthour', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'minrepeat', type: 'number'}
            ,{name:'c24', type: 'int'}
            ,{name:'c24_grid', type: 'string'}
            ,{name:'num24', type: 'number'}
            ,{name:'dnext24', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'ccurr', type: 'int'}
            ,{name:'ccurr_grid', type: 'string'}
            ,{name:'dnextsum', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'iel', type: 'number'}
            ,{name:'icall', type: 'number'}
            ,{name:'dlastcall', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'dnexthour', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'cstatus', type: 'int'}
            ,{name:'cstatus_grid', type: 'string'}
            ,{name:'dlastday', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'dlock', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'chour', type: 'int'}
            ,{name:'chour_grid', type: 'string'}
            ,{name:'cel', type: 'int'}
            ,{name:'cel_grid', type: 'string'}
            ,{name:'icallsum', type: 'number'}
            ,{name:'icallcurr', type: 'number'}
            ,{name:'icall24', type: 'number'}
        ]
    });


 Ext.define('model_tplt_mask',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tplt_maskid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'pname', type: 'string'}
            ,{name:'pname_grid', type: 'string'}
            ,{name:'phide', type: 'int'}
            ,{name:'phide_grid', type: 'string'}
            ,{name:'colwidth', type: 'number'}
            ,{name:'sequence', type: 'number'}
            ,{name:'ptype', type: 'string'}
            ,{name:'ptype_grid', type: 'string'}
            ,{name:'paramformat', type: 'string'}
        ]
    });


 Ext.define('model_tplt_bdevices',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tplt_bdevicesid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'nplock', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'devtype', type: 'string'}
            ,{name:'devtype_grid', type: 'string'}
            ,{name:'devgrp', type: 'string'}
            ,{name:'devgrp_grid', type: 'string'}
            ,{name:'addr', type: 'string'}
            ,{name:'shab', type: 'string'}
            ,{name:'shab_grid', type: 'string'}
            ,{name:'name', type: 'string'}
            ,{name:'thenode', type: 'string'}
            ,{name:'thenode_grid', type: 'string'}
            ,{name:'thephone', type: 'string'}
            ,{name:'theschema', type: 'string'}
            ,{name:'theschema_grid', type: 'string'}
            ,{name:'theserver', type: 'string'}
            ,{name:'theserver_grid', type: 'string'}
            ,{name:'connected', type: 'int'}
            ,{name:'connected_grid', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_tplt_bdevices',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tplt_bdevicesid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_tplt_bdevices_loaded=false;
    var cmbstore_tplt_bdevices = Ext.create('Ext.data.Store', {
        model:'cmbmodel_tplt_bdevices',
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
            }
        },
       listeners: {
       'load': function(){combo_tplt_bdevices_loaded =true;}
       }
    });

 Ext.define('model_tplt_contract',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tplt_contractid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'fld37', type: 'string'}
            ,{name:'fld103', type: 'string'}
            ,{name:'fld97', type: 'string'}
            ,{name:'fld40', type: 'string'}
            ,{name:'fld51', type: 'string'}
            ,{name:'fld73', type: 'string'}
            ,{name:'fld96', type: 'string'}
            ,{name:'fld54', type: 'string'}
            ,{name:'fld92', type: 'string'}
            ,{name:'fld62', type: 'string'}
            ,{name:'fld42', type: 'string'}
            ,{name:'fld16', type: 'string'}
            ,{name:'fld65', type: 'string'}
            ,{name:'fld63', type: 'string'}
            ,{name:'fld15', type: 'string'}
            ,{name:'fld30', type: 'string'}
            ,{name:'fld59', type: 'string'}
            ,{name:'fld12', type: 'string'}
            ,{name:'fld35', type: 'string'}
            ,{name:'fld27', type: 'string'}
            ,{name:'fld29', type: 'string'}
            ,{name:'fld64', type: 'string'}
            ,{name:'fld56', type: 'string'}
            ,{name:'fld26', type: 'string'}
            ,{name:'fld43', type: 'string'}
            ,{name:'fld55', type: 'string'}
            ,{name:'fld100', type: 'string'}
            ,{name:'fld102', type: 'string'}
            ,{name:'fld87', type: 'string'}
            ,{name:'fld82', type: 'string'}
            ,{name:'fld57', type: 'string'}
            ,{name:'fld60', type: 'string'}
            ,{name:'fld53', type: 'string'}
            ,{name:'fld22', type: 'string'}
            ,{name:'fld101', type: 'string'}
            ,{name:'fld41', type: 'string'}
            ,{name:'fld81', type: 'string'}
            ,{name:'fld14', type: 'string'}
            ,{name:'fld19', type: 'string'}
            ,{name:'fld66', type: 'string'}
            ,{name:'fld89', type: 'string'}
            ,{name:'fld95', type: 'string'}
            ,{name:'fld61', type: 'string'}
            ,{name:'fld46', type: 'string'}
            ,{name:'fld99', type: 'string'}
            ,{name:'fld21', type: 'string'}
            ,{name:'fld45', type: 'string'}
            ,{name:'fld94', type: 'string'}
            ,{name:'fld28', type: 'string'}
            ,{name:'fld104', type: 'string'}
            ,{name:'fld18', type: 'string'}
            ,{name:'fld47', type: 'string'}
            ,{name:'fld68', type: 'string'}
            ,{name:'fld49', type: 'string'}
            ,{name:'fld33', type: 'string'}
            ,{name:'fld23', type: 'string'}
            ,{name:'fld69', type: 'string'}
            ,{name:'fld83', type: 'string'}
            ,{name:'fld67', type: 'string'}
            ,{name:'fld17', type: 'string'}
            ,{name:'fld36', type: 'string'}
            ,{name:'fld84', type: 'string'}
            ,{name:'fld34', type: 'string'}
            ,{name:'fld85', type: 'string'}
            ,{name:'fld48', type: 'string'}
            ,{name:'fld88', type: 'string'}
            ,{name:'fld98', type: 'string'}
            ,{name:'fld93', type: 'string'}
            ,{name:'fld13', type: 'string'}
            ,{name:'fld72', type: 'string'}
            ,{name:'fld58', type: 'string'}
            ,{name:'fld32', type: 'string'}
            ,{name:'fld25', type: 'string'}
            ,{name:'fld90', type: 'string'}
            ,{name:'fld20', type: 'string'}
            ,{name:'fld24', type: 'string'}
            ,{name:'fld50', type: 'string'}
            ,{name:'fld70', type: 'string'}
            ,{name:'fld86', type: 'string'}
            ,{name:'fld71', type: 'string'}
            ,{name:'fld31', type: 'string'}
            ,{name:'fld52', type: 'string'}
        ]
    });


 Ext.define('model_tpn_def',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpn_defid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'thephone', type: 'string'}
            ,{name:'addr', type: 'string'}
            ,{name:'orgunit', type: 'string'}
            ,{name:'orgunit_grid', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_tpn_def',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpn_defid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_tpn_def_loaded=false;
    var cmbstore_tpn_def = Ext.create('Ext.data.Store', {
        model:'cmbmodel_tpn_def',
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
            }
        },
       listeners: {
       'load': function(){combo_tpn_def_loaded =true;}
       }
    });

 Ext.define('model_tpq_def',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpq_defid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'isurgent', type: 'int'}
            ,{name:'isurgent_grid', type: 'string'}
            ,{name:'repeattimes', type: 'number'}
            ,{name:'repeatinterval', type: 'number'}
            ,{name:'querytime', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'thedevice', type: 'string'}
            ,{name:'thedevice_grid', type: 'string'}
            ,{name:'archtime', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'thesessionid', type: 'string'}
            ,{name:'thesessionid_grid', type: 'string'}
            ,{name:'archtype', type: 'string'}
            ,{name:'archtype_grid', type: 'string'}
        ]
    });


 Ext.define('model_tpq_result',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpq_resultid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'totalarch', type: 'string'}
            ,{name:'totalarch_grid', type: 'string'}
            ,{name:'textresult', type: 'string'}
            ,{name:'dayarch', type: 'string'}
            ,{name:'dayarch_grid', type: 'string'}
            ,{name:'logmessage', type: 'string'}
            ,{name:'endtime', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'hourarch', type: 'string'}
            ,{name:'hourarch_grid', type: 'string'}
            ,{name:'momentarch', type: 'string'}
            ,{name:'momentarch_grid', type: 'string'}
            ,{name:'starttime', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'iserror', type: 'int'}
            ,{name:'iserror_grid', type: 'string'}
        ]
    });


 Ext.define('model_tpsrv_modems',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpsrv_modemsid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'useduntil', type: 'date',dateFormat:'Y-m-d H:i:s'}
            ,{name:'isused', type: 'int'}
            ,{name:'isused_grid', type: 'string'}
            ,{name:'isusable', type: 'int'}
            ,{name:'isusable_grid', type: 'string'}
            ,{name:'portnum', type: 'string'}
        ]
    });


 Ext.define('model_tpsrv_info',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpsrv_infoid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'ipaddr', type: 'string'}
            ,{name:'name', type: 'string'}
        ]
    });

 Ext.define('cmbmodel_tpsrv_info',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpsrv_infoid',type: 'string'}
            ,{name: 'brief',type: 'string'}
        ]
    });
    var cmbstore_tpsrv_info_loaded=false;
    var cmbstore_tpsrv_info = Ext.create('Ext.data.Store', {
        model:'cmbmodel_tpsrv_info',
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
            }
        },
       listeners: {
       'load': function(){combo_tpsrv_info_loaded =true;}
       }
    });

 Ext.define('model_tpsrv_ports',{
            extend:'Ext.data.Model',
        fields: [
            {name: 'tpsrv_portsid',type: 'string'}
            ,{name: 'id',type: 'string'}
            ,{name: 'instanceid',type: 'string'}
            ,{name: 'brief',type: 'string'}
            ,{name:'isusable', type: 'int'}
            ,{name:'isusable_grid', type: 'string'}
            ,{name:'isused', type: 'int'}
            ,{name:'isused_grid', type: 'string'}
            ,{name:'portname', type: 'string'}
            ,{name:'useduntil', type: 'date',dateFormat:'Y-m-d H:i:s'}
        ]
    });
