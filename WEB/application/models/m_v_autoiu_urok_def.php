
<?php
class  M_v_autoiu_urok_def extends CI_Model {
    public function  __construct()
    {
         parent::__construct();
    }
    function newRow($objtype,$name)  {
               $id = $this->jservice->get(array('Action'=>'NewGuid'));
               $this->jservice->get(array('Action'=>'NewDocument', 'TypeName'=>'iu_urok', 'DocumentID'=>$id, 'DocumentCaption'=>$name));
               $rowid = $this->jservice->get(array('Action'=>'NewGuid'));
               $this->jservice->get(array('Action'=>'NewRow', 'PartName'=>'iu_urok_def', 'RowID'=>$rowid, 'DocumentID'=>$id));
                if ($id) {
                    return array('success'=>TRUE, 'data' => $id, 'rowid'=>$rowid);
                }
                else {
                    $return= array('success'=>FALSE, 'msg' => 'Error while create new id');
				    return $return;
                }
    }
      function getRowsSL($offset,$limit, $sort = array(), $filter = null)
{
        $filter = (array)json_decode($filter);
       	$cond ='';
        $whereclause = '';
    try{
	    foreach($filter as $obj) {
		    $tmp = json_decode($obj->value);
		    if(is_array($tmp)) $obj->value = $tmp;	
		    switch($obj->property) {
			    //case 'value':
			    	//$cond = '';
			    	//break;
			  case 'iu_urok_def_actiondate_le':
			  $cond = 'iu_urok_def_actiondate<="'.$obj->value.'"';
			  break;
			  case 'iu_urok_def_actiondate_ge':
			  $cond = 'iu_urok_def_actiondate>="'.$obj->value.'"';
			  break;
			  case 'iu_urok_def_schooldate_le':
			  $cond = 'iu_urok_def_schooldate<="'.$obj->value.'"';
			  break;
			  case 'iu_urok_def_schooldate_ge':
			  $cond = 'iu_urok_def_schooldate>="'.$obj->value.'"';
			  break;
			  case 'iu_urok_def_datecreated_le':
			  $cond = 'iu_urok_def_datecreated<="'.$obj->value.'"';
			  break;
			  case 'iu_urok_def_datecreated_ge':
			  $cond = 'iu_urok_def_datecreated>="'.$obj->value.'"';
			  break;
		    	default:
			    	if(isset($obj->value))
			    	{
			    		if(is_array($obj->value))
				    	{
				    		$cond = $obj->property . ' IN ("' . implode('", "',$obj->value).'") ';
				    		//echo $cond;
					    }else
					    {
					    	$cond = $obj->property . ' LIKE "%' . $obj->value . '%"';
					    }
				    }else{
				        $cond='1=1';
				    }
		    }
		    $whereclause .= (empty($whereclause)) ? $cond : ' AND ' . $cond;
	    }
    }catch(Exception $e) {
	    log_message('error','Exception: '. $e->getMessage());
    }
	 if (isset($offset) && isset($limit)) {
	    $res = $this->jservice->get(array('Action' => 'GetViewData', 'ViewName' => 'v_autoiu_urok_def','FieldList'=>'instanceid,id,iu_urok_def_ucode,iu_urok_def_mainref,iu_urok_def_curator,iu_urok_def_info,iu_urok_def_subject,iu_urok_def_methodist2,iu_urok_def_methodist,DATE_FORMAT(iu_urok_def_actiondate,\'%Y-%m-%d\') iu_urok_def_actiondate,iu_urok_def_rtheme,iu_urok_def_coursetype,iu_urok_def_testpageref,iu_urok_def_plannum,iu_urok_def_maketown,iu_urok_def_thefilm,iu_urok_def_thequarter,iu_urok_def_theteacher,iu_urok_def_theclassnum,iu_urok_def_schooldate ,iu_urok_def_processtype,DATE_FORMAT(iu_urok_def_datecreated,\'%Y-%m-%d %H:%i:%s\') iu_urok_def_datecreated,iu_urok_def_classtheme','Sort'=>$sort, 'WhereClause' => $whereclause,'Limit'=>$limit,'Offset'=>$offset));
	} else {
	    $res = $this->jservice->get(array('Action' => 'GetViewData', 'ViewName' => 'v_autoiu_urok_def','FieldList'=>'instanceid,id,iu_urok_def_ucode,iu_urok_def_mainref,iu_urok_def_curator,iu_urok_def_info,iu_urok_def_subject,iu_urok_def_methodist2,iu_urok_def_methodist,DATE_FORMAT(iu_urok_def_actiondate,\'%Y-%m-%d\') iu_urok_def_actiondate,iu_urok_def_rtheme,iu_urok_def_coursetype,iu_urok_def_testpageref,iu_urok_def_plannum,iu_urok_def_maketown,iu_urok_def_thefilm,iu_urok_def_thequarter,iu_urok_def_theteacher,iu_urok_def_theclassnum,iu_urok_def_schooldate ,iu_urok_def_processtype,DATE_FORMAT(iu_urok_def_datecreated,\'%Y-%m-%d %H:%i:%s\') iu_urok_def_datecreated,iu_urok_def_classtheme','Sort'=>$sort, 'WhereClause' => $whereclause));
	}
	$root = new stdClass();
	$root->total = $this->jservice->get(array('Action' => 'CountView', 'ViewName' => 'v_autoiu_urok_def','FieldList'=>'instanceid,id,iu_urok_def_ucode,iu_urok_def_mainref,iu_urok_def_curator,iu_urok_def_info,iu_urok_def_subject,iu_urok_def_methodist2,iu_urok_def_methodist,DATE_FORMAT(iu_urok_def_actiondate,\'%Y-%m-%d\') iu_urok_def_actiondate,iu_urok_def_rtheme,iu_urok_def_coursetype,iu_urok_def_testpageref,iu_urok_def_plannum,iu_urok_def_maketown,iu_urok_def_thefilm,iu_urok_def_thequarter,iu_urok_def_theteacher,iu_urok_def_theclassnum,iu_urok_def_schooldate ,iu_urok_def_processtype,DATE_FORMAT(iu_urok_def_datecreated,\'%Y-%m-%d %H:%i:%s\') iu_urok_def_datecreated,iu_urok_def_classtheme', 'WhereClause' => $whereclause));
	$root->success = true;
	$root->rows = $res;
	return $root;
}
    function deleteRow($id = null) {
	    $this->jservice->get(array('Action'=>'DeleteDocument', 'TypeName'=>'iu_urok', 'DocumentID'=>$id));
	    $return = array('success' => true);
	    return $return;
    }
}
?>