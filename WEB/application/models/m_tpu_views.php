
<?php
class  M_tpu_views extends CI_Model {
    function getRow($empId) {
    $result = array('success' => false, 'msg' => 'No Row ID for retrive data');
	if (!empty($empId)){
	    $res = $this->jservice->get(array('Action' => 'GetRowData','FieldList'=>'B2G(tpu_viewsid) as tpu_viewsid, B2G(tpu_viewsid) as id,B2G(parentstructrowid) as parentid, TPU_VIEWS_BRIEF_F(tpu_viewsid , NULL) as  brief,hideparam, case hideparam  when -1 then \'Да\' when 0 then \'Нет\'End  as hideparam_grid,B2G(TheFormat) theformat, FIELDTYPE_BRIEF_F(theformat, NULL) as theformat_grid,B2G(Param) param, TPLD_PARAM_BRIEF_F(param, NULL) as param_grid,thewidth,sequence', 'PartName' => 'tpu_views', 'ID' =>  $empId 	));
	    if (!empty($res)) {
	        $result = $res[0];
	    }
	}
	return $result;
    }
    function setRow($data)  {
	    $data = (array)$data;
	if (!empty($data)) {
	    if (empty($data['tpu_viewsid'])) {
	        $data['tpu_viewsid'] = $this->jservice->get(array('Action' => 'NewGuid'));
	        $res=$this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tpu_views', 'RowID' => $data['tpu_viewsid'], 'DocumentID' => $data['instanceid'],'ParentID' => $data['parentid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }else{
	    $res = $this->jservice->get(array('Action' => 'UpdateRow', 'PartName' => 'tpu_views', 'RowID' => $data['tpu_viewsid'], 'DocumentID' => $data['instanceid'],'ParentID' => $data['parentid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }
	    return array('success' => TRUE, 'data' => $this->getRow($data['tpu_viewsid'] ));
	} else {
	    return array('success' => FALSE, 'msg' => 'No data to store on server');
	}
    }
    function newRow($instanceid,$parentid,$data)  {
	  $id = $this->jservice->get(array('Action' => 'NewGuid'));
	if ($this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tpu_views', 'RowID' => $id, 'DocumentID' => $instanceid,'ParentID'=>$parentid, 'Values'=>$data)) == 'OK') {
	    return array('success' => TRUE, 'data' => $id);
	} else {
	    return array('success' => FALSE, 'msg' => 'Error while create new id');
	}
    }
    function getRows($sort=array())
		{
	    $res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpu_viewsid) as tpu_viewsid, B2G(tpu_viewsid) as id,B2G(parentstructrowid) as parentid, TPU_VIEWS_BRIEF_F(tpu_viewsid , NULL) as  brief,hideparam, case hideparam  when -1 then \'Да\' when 0 then \'Нет\'End  as hideparam_grid,B2G(TheFormat) theformat, FIELDTYPE_BRIEF_F(theformat, NULL) as theformat_grid,B2G(Param) param, TPLD_PARAM_BRIEF_F(param, NULL) as param_grid,thewidth,sequence', 'ViewName' => 'tpu_views'));
	    if (count($res)) {
	        return $res;
	    } else {
	        return null;
	    }
		}
    function getRowsByInstance($id,$sort=array())
		{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpu_viewsid) as tpu_viewsid, B2G(tpu_viewsid) as id,B2G(parentstructrowid) as parentid, TPU_VIEWS_BRIEF_F(tpu_viewsid , NULL) as  brief,hideparam, case hideparam  when -1 then \'Да\' when 0 then \'Нет\'End  as hideparam_grid,B2G(TheFormat) theformat, FIELDTYPE_BRIEF_F(theformat, NULL) as theformat_grid,B2G(Param) param, TPLD_PARAM_BRIEF_F(param, NULL) as param_grid,thewidth,sequence', 'ViewName' => 'tpu_views', 'WhereClause' => 'instanceid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
		}
    function getRowsByParent($id,$sort=array())
	{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpu_viewsid) as tpu_viewsid, B2G(tpu_viewsid) as id,B2G(parentstructrowid) as parentid, TPU_VIEWS_BRIEF_F(tpu_viewsid , NULL) as  brief,hideparam, case hideparam  when -1 then \'Да\' when 0 then \'Нет\'End  as hideparam_grid,B2G(TheFormat) theformat, FIELDTYPE_BRIEF_F(theformat, NULL) as theformat_grid,B2G(Param) param, TPLD_PARAM_BRIEF_F(param, NULL) as param_grid,thewidth,sequence', 'ViewName' => 'tpu_views', 'WhereClause' => ' parentstructrowid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
  }
    function deleteRow($id = null) {
	  if (!empty($id) && $this->jservice->get(array('Action' => 'DeleteRow', 'PartName' => 'tpu_views', 'RowID' => $id)) == 'OK')
	    $result = array('success' => TRUE);
	else
	    $result = array('success' => FALSE, 'msg' => 'Error while deleting record!');
	return $result;
    }
}
?>