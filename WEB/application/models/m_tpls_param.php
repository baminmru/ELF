
<?php
class  M_tpls_param extends CI_Model {
    function getRow($empId) {
    $result = array('success' => false, 'msg' => 'No Row ID for retrive data');
	if (!empty($empId)){
	    $res = $this->jservice->get(array('Action' => 'GetRowData','FieldList'=>'B2G(tpls_paramid) as tpls_paramid, B2G(tpls_paramid) as id,B2G(instanceid) as instanceid, TPLS_PARAM_BRIEF_F(tpls_paramid , NULL) as  brief,hideparam, case hideparam  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as hideparam_grid,B2G(ArchType) archtype, TPLD_PARAMTYPE_BRIEF_F(archtype, NULL) as archtype_grid,pos_left,B2G(Param) param, TPLD_PARAM_BRIEF_F(param, NULL) as param_grid,hideonschema, case hideonschema  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as hideonschema_grid,pos_top', 'PartName' => 'tpls_param', 'ID' =>  $empId 	));
	    if (!empty($res)) {
	        $result = $res[0];
	    }
	}
	return $result;
    }
    function setRow($data)  {
	    $data = (array)$data;
	if (!empty($data)) {
	    if (empty($data['tpls_paramid'])) {
	        $data['tpls_paramid'] = $this->jservice->get(array('Action' => 'NewGuid'));
	        $res=$this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tpls_param', 'RowID' => $data['tpls_paramid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }else{
	    $res = $this->jservice->get(array('Action' => 'UpdateRow', 'PartName' => 'tpls_param', 'RowID' => $data['tpls_paramid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }
	    return array('success' => TRUE, 'data' => $this->getRow($data['tpls_paramid'] ));
	} else {
	    return array('success' => FALSE, 'msg' => 'No data to store on server');
	}
    }
    function newRow($instanceid,$data)  {
	  $id = $this->jservice->get(array('Action' => 'NewGuid'));
	if ($this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tpls_param', 'RowID' => $id, 'DocumentID' => $instanceid, 'Values'=>$data)) == 'OK') {
	    return array('success' => TRUE, 'data' => $id);
	} else {
	    return array('success' => FALSE, 'msg' => 'Error while create new id');
	}
    }
    function getRows($sort=array())
		{
	    $res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpls_paramid) as tpls_paramid, B2G(tpls_paramid) as id,B2G(instanceid) as instanceid, TPLS_PARAM_BRIEF_F(tpls_paramid , NULL) as  brief,hideparam, case hideparam  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as hideparam_grid,B2G(ArchType) archtype, TPLD_PARAMTYPE_BRIEF_F(archtype, NULL) as archtype_grid,pos_left,B2G(Param) param, TPLD_PARAM_BRIEF_F(param, NULL) as param_grid,hideonschema, case hideonschema  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as hideonschema_grid,pos_top', 'ViewName' => 'tpls_param'));
	    if (count($res)) {
	        return $res;
	    } else {
	        return null;
	    }
		}
    function getRowsByInstance($id,$sort=array())
		{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpls_paramid) as tpls_paramid, B2G(tpls_paramid) as id,B2G(instanceid) as instanceid, TPLS_PARAM_BRIEF_F(tpls_paramid , NULL) as  brief,hideparam, case hideparam  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as hideparam_grid,B2G(ArchType) archtype, TPLD_PARAMTYPE_BRIEF_F(archtype, NULL) as archtype_grid,pos_left,B2G(Param) param, TPLD_PARAM_BRIEF_F(param, NULL) as param_grid,hideonschema, case hideonschema  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as hideonschema_grid,pos_top', 'ViewName' => 'tpls_param', 'WhereClause' => 'instanceid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
		}
    function getRowsByParent($id,$sort=array())
	{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpls_paramid) as tpls_paramid, B2G(tpls_paramid) as id,B2G(instanceid) as instanceid, TPLS_PARAM_BRIEF_F(tpls_paramid , NULL) as  brief,hideparam, case hideparam  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as hideparam_grid,B2G(ArchType) archtype, TPLD_PARAMTYPE_BRIEF_F(archtype, NULL) as archtype_grid,pos_left,B2G(Param) param, TPLD_PARAM_BRIEF_F(param, NULL) as param_grid,hideonschema, case hideonschema  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as hideonschema_grid,pos_top', 'ViewName' => 'tpls_param', 'WhereClause' => ' parentstructrowid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
  }
    function deleteRow($id = null) {
	  if (!empty($id) && $this->jservice->get(array('Action' => 'DeleteRow', 'PartName' => 'tpls_param', 'RowID' => $id)) == 'OK')
	    $result = array('success' => TRUE);
	else
	    $result = array('success' => FALSE, 'msg' => 'Error while deleting record!');
	return $result;
    }
}
?>