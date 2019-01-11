
<?php
class  M_tplt_plancall extends CI_Model {
    function getRow($empId) {
    $result = array('success' => false, 'msg' => 'No Row ID for retrive data');
	if (!empty($empId)){
	    $res = $this->jservice->get(array('Action' => 'GetRowData','FieldList'=>'B2G(tplt_plancallid) as tplt_plancallid, B2G(tplt_plancallid) as id,B2G(instanceid) as instanceid, TPLT_PLANCALL_BRIEF_F(tplt_plancallid , NULL) as  brief,nmaxcall,numhour,  DATE_FORMAT(dnextel,\'%Y-%m-%d\') as  dnextel,csum, case csum  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as csum_grid,  DATE_FORMAT(dnextcurr,\'%Y-%m-%d %H:%i:%s\') as  dnextcurr,  DATE_FORMAT(dlasthour,\'%Y-%m-%d %H:%i:%s\') as  dlasthour,minrepeat,c24, case c24  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as c24_grid,num24,  DATE_FORMAT(dnext24,\'%Y-%m-%d %H:%i:%s\') as  dnext24,ccurr, case ccurr  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as ccurr_grid,  DATE_FORMAT(dnextsum,\'%Y-%m-%d %H:%i:%s\') as  dnextsum,iel,icall,  DATE_FORMAT(dlastcall,\'%Y-%m-%d %H:%i:%s\') as  dlastcall,  DATE_FORMAT(dnexthour,\'%Y-%m-%d %H:%i:%s\') as  dnexthour,cstatus, case cstatus  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as cstatus_grid,  DATE_FORMAT(dlastday,\'%Y-%m-%d %H:%i:%s\') as  dlastday,  DATE_FORMAT(dlock,\'%Y-%m-%d %H:%i:%s\') as  dlock,chour, case chour  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as chour_grid,cel, case cel  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as cel_grid,icallsum,icallcurr,icall24', 'PartName' => 'tplt_plancall', 'ID' =>  $empId 	));
	    if (!empty($res)) {
	        $result = $res[0];
	    }
	}
	return $result;
    }
    function setRow($data)  {
	    $data = (array)$data;
	if (!empty($data)) {
	    if (empty($data['tplt_plancallid'])) {
	        $data['tplt_plancallid'] = $this->jservice->get(array('Action' => 'NewGuid'));
	        $res=$this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tplt_plancall', 'RowID' => $data['tplt_plancallid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }else{
	    $res = $this->jservice->get(array('Action' => 'UpdateRow', 'PartName' => 'tplt_plancall', 'RowID' => $data['tplt_plancallid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }
	    return array('success' => TRUE, 'data' => $this->getRow($data['tplt_plancallid'] ));
	} else {
	    return array('success' => FALSE, 'msg' => 'No data to store on server');
	}
    }
    function newRow($instanceid,$data)  {
	  $id = $this->jservice->get(array('Action' => 'NewGuid'));
	if ($this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tplt_plancall', 'RowID' => $id, 'DocumentID' => $instanceid, 'Values'=>$data)) == 'OK') {
	    return array('success' => TRUE, 'data' => $id);
	} else {
	    return array('success' => FALSE, 'msg' => 'Error while create new id');
	}
    }
    function getRows($sort=array())
		{
	    $res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tplt_plancallid) as tplt_plancallid, B2G(tplt_plancallid) as id,B2G(instanceid) as instanceid, TPLT_PLANCALL_BRIEF_F(tplt_plancallid , NULL) as  brief,nmaxcall,numhour,  DATE_FORMAT(dnextel,\'%Y-%m-%d\') as  dnextel,csum, case csum  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as csum_grid,  DATE_FORMAT(dnextcurr,\'%Y-%m-%d %H:%i:%s\') as  dnextcurr,  DATE_FORMAT(dlasthour,\'%Y-%m-%d %H:%i:%s\') as  dlasthour,minrepeat,c24, case c24  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as c24_grid,num24,  DATE_FORMAT(dnext24,\'%Y-%m-%d %H:%i:%s\') as  dnext24,ccurr, case ccurr  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as ccurr_grid,  DATE_FORMAT(dnextsum,\'%Y-%m-%d %H:%i:%s\') as  dnextsum,iel,icall,  DATE_FORMAT(dlastcall,\'%Y-%m-%d %H:%i:%s\') as  dlastcall,  DATE_FORMAT(dnexthour,\'%Y-%m-%d %H:%i:%s\') as  dnexthour,cstatus, case cstatus  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as cstatus_grid,  DATE_FORMAT(dlastday,\'%Y-%m-%d %H:%i:%s\') as  dlastday,  DATE_FORMAT(dlock,\'%Y-%m-%d %H:%i:%s\') as  dlock,chour, case chour  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as chour_grid,cel, case cel  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as cel_grid,icallsum,icallcurr,icall24', 'ViewName' => 'tplt_plancall'));
	    if (count($res)) {
	        return $res;
	    } else {
	        return null;
	    }
		}
    function getRowsByInstance($id,$sort=array())
		{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tplt_plancallid) as tplt_plancallid, B2G(tplt_plancallid) as id,B2G(instanceid) as instanceid, TPLT_PLANCALL_BRIEF_F(tplt_plancallid , NULL) as  brief,nmaxcall,numhour,  DATE_FORMAT(dnextel,\'%Y-%m-%d\') as  dnextel,csum, case csum  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as csum_grid,  DATE_FORMAT(dnextcurr,\'%Y-%m-%d %H:%i:%s\') as  dnextcurr,  DATE_FORMAT(dlasthour,\'%Y-%m-%d %H:%i:%s\') as  dlasthour,minrepeat,c24, case c24  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as c24_grid,num24,  DATE_FORMAT(dnext24,\'%Y-%m-%d %H:%i:%s\') as  dnext24,ccurr, case ccurr  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as ccurr_grid,  DATE_FORMAT(dnextsum,\'%Y-%m-%d %H:%i:%s\') as  dnextsum,iel,icall,  DATE_FORMAT(dlastcall,\'%Y-%m-%d %H:%i:%s\') as  dlastcall,  DATE_FORMAT(dnexthour,\'%Y-%m-%d %H:%i:%s\') as  dnexthour,cstatus, case cstatus  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as cstatus_grid,  DATE_FORMAT(dlastday,\'%Y-%m-%d %H:%i:%s\') as  dlastday,  DATE_FORMAT(dlock,\'%Y-%m-%d %H:%i:%s\') as  dlock,chour, case chour  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as chour_grid,cel, case cel  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as cel_grid,icallsum,icallcurr,icall24', 'ViewName' => 'tplt_plancall', 'WhereClause' => 'instanceid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
		}
    function getRowsByParent($id,$sort=array())
	{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tplt_plancallid) as tplt_plancallid, B2G(tplt_plancallid) as id,B2G(instanceid) as instanceid, TPLT_PLANCALL_BRIEF_F(tplt_plancallid , NULL) as  brief,nmaxcall,numhour,  DATE_FORMAT(dnextel,\'%Y-%m-%d\') as  dnextel,csum, case csum  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as csum_grid,  DATE_FORMAT(dnextcurr,\'%Y-%m-%d %H:%i:%s\') as  dnextcurr,  DATE_FORMAT(dlasthour,\'%Y-%m-%d %H:%i:%s\') as  dlasthour,minrepeat,c24, case c24  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as c24_grid,num24,  DATE_FORMAT(dnext24,\'%Y-%m-%d %H:%i:%s\') as  dnext24,ccurr, case ccurr  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as ccurr_grid,  DATE_FORMAT(dnextsum,\'%Y-%m-%d %H:%i:%s\') as  dnextsum,iel,icall,  DATE_FORMAT(dlastcall,\'%Y-%m-%d %H:%i:%s\') as  dlastcall,  DATE_FORMAT(dnexthour,\'%Y-%m-%d %H:%i:%s\') as  dnexthour,cstatus, case cstatus  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as cstatus_grid,  DATE_FORMAT(dlastday,\'%Y-%m-%d %H:%i:%s\') as  dlastday,  DATE_FORMAT(dlock,\'%Y-%m-%d %H:%i:%s\') as  dlock,chour, case chour  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as chour_grid,cel, case cel  when -1 then \'Да\' when 0 then \'Нет\' else \'\'  end   as cel_grid,icallsum,icallcurr,icall24', 'ViewName' => 'tplt_plancall', 'WhereClause' => ' parentstructrowid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
  }
    function deleteRow($id = null) {
	  if (!empty($id) && $this->jservice->get(array('Action' => 'DeleteRow', 'PartName' => 'tplt_plancall', 'RowID' => $id)) == 'OK')
	    $result = array('success' => TRUE);
	else
	    $result = array('success' => FALSE, 'msg' => 'Error while deleting record!');
	return $result;
    }
}
?>