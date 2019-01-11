
<?php
class  M_v_autotpq_def extends CI_Model {
    public function  __construct()
    {
         parent::__construct();
    }
    function newRow($objtype,$name)  {
               $id = $this->jservice->get(array('Action'=>'NewGuid'));
               $this->jservice->get(array('Action'=>'NewDocument', 'TypeName'=>'TPQ', 'DocumentID'=>$id, 'DocumentCaption'=>$name));
               $rowid = $this->jservice->get(array('Action'=>'NewGuid'));
               $this->jservice->get(array('Action'=>'NewRow', 'PartName'=>'tpq_def', 'RowID'=>$rowid, 'DocumentID'=>$id));
                if ($id) {
                    return array('success'=>TRUE, 'data' => $id, 'rowid'=>$rowid);
                }
                else {
                    $return= array('success'=>FALSE, 'msg' => 'Error while create new id');
				    return $return;
                }
    }
      function getRowsSL($offset,$limit, $sort = array(), $filter = null){
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
			  case 'tpq_def_repeattimes_le':
			  $cond = 'tpq_def_repeattimes<='.$obj->value;
			  break;
			  case 'tpq_def_repeattimes_ge':
			  $cond = 'tpq_def_repeattimes>='.$obj->value;
			  break;
			  case 'tpq_def_repeatinterval_le':
			  $cond = 'tpq_def_repeatinterval<='.$obj->value;
			  break;
			  case 'tpq_def_repeatinterval_ge':
			  $cond = 'tpq_def_repeatinterval>='.$obj->value;
			  break;
			  case 'tpq_def_querytime_le':
			  $cond = 'tpq_def_querytime<="'.$obj->value.'"';
			  break;
			  case 'tpq_def_querytime_ge':
			  $cond = 'tpq_def_querytime>="'.$obj->value.'"';
			  break;
			  case 'tpq_def_archtime_le':
			  $cond = 'tpq_def_archtime<="'.$obj->value.'"';
			  break;
			  case 'tpq_def_archtime_ge':
			  $cond = 'tpq_def_archtime>="'.$obj->value.'"';
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
	    $res = $this->jservice->get(array('Action' => 'GetViewData', 'ViewName' => 'v_autotpq_def','FieldList'=>'instanceid,id,tpq_def_thedevice,tpq_def_isurgent,tpq_def_repeattimes,tpq_def_archtype,tpq_def_repeatinterval,DATE_FORMAT(tpq_def_querytime,\'%Y-%m-%d %H:%i:%s\') tpq_def_querytime,tpq_def_thesessionid,DATE_FORMAT(tpq_def_archtime,\'%Y-%m-%d %H:%i:%s\') tpq_def_archtime','Sort'=>$sort, 'WhereClause' => $whereclause,'Limit'=>$limit,'Offset'=>$offset));
	} else {
	    $res = $this->jservice->get(array('Action' => 'GetViewData', 'ViewName' => 'v_autotpq_def','FieldList'=>'instanceid,id,tpq_def_thedevice,tpq_def_isurgent,tpq_def_repeattimes,tpq_def_archtype,tpq_def_repeatinterval,DATE_FORMAT(tpq_def_querytime,\'%Y-%m-%d %H:%i:%s\') tpq_def_querytime,tpq_def_thesessionid,DATE_FORMAT(tpq_def_archtime,\'%Y-%m-%d %H:%i:%s\') tpq_def_archtime','Sort'=>$sort, 'WhereClause' => $whereclause));
	}
	$root = new stdClass();
	$root->total = $this->jservice->get(array('Action' => 'CountView', 'ViewName' => 'v_autotpq_def','FieldList'=>'instanceid,id,tpq_def_thedevice,tpq_def_isurgent,tpq_def_repeattimes,tpq_def_archtype,tpq_def_repeatinterval,DATE_FORMAT(tpq_def_querytime,\'%Y-%m-%d %H:%i:%s\') tpq_def_querytime,tpq_def_thesessionid,DATE_FORMAT(tpq_def_archtime,\'%Y-%m-%d %H:%i:%s\') tpq_def_archtime', 'WhereClause' => $whereclause));
	$root->success = true;
	$root->rows = $res;
	return $root;
}
    function deleteRow($id = null) {
	    $this->jservice->get(array('Action'=>'DeleteDocument', 'TypeName'=>'tpq', 'DocumentID'=>$id));
	    $return = array('success' => true);
	    return $return;
    }
}
?>