<?php
	 class C_tpld_grp extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPLD_GRP.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPLD_GRP.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tpld_grpid' =>  $this->input->get_post('tpld_grpid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'theclient' =>   $this->input->get_post('theclient', TRUE)
                ,'cgrpnm' =>   $this->input->get_post('cgrpnm', TRUE)
                ,'ctxt' =>   $this->input->get_post('ctxt', TRUE)
            );
            $tpld_grp = $this->m_tpld_grp->setRow($data);
            print json_encode($tpld_grp);
    }
    function newRow() {
            log_message('debug', 'TPLD_GRP.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tpld_grpid' =>  $this->input->get_post('tpld_grpid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'theclient' =>   $this->input->get_post('theclient', TRUE)
                ,'cgrpnm' =>   $this->input->get_post('cgrpnm', TRUE)
                ,'ctxt' =>   $this->input->get_post('ctxt', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tpld_grp= $this->m_tpld_grp->newRow($instanceid,$data);
            $return = $tpld_grp;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPLD_GRP.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tpld_grp = $this->m_tpld_grp->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tpld_grp
            );
            print json_encode($return);
        }
    }
    function getRows() {
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'cgrpnm', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tpld_grp= $this->m_tpld_grp->getRowsByInstance($instanceid,$sort);
                }else{
                    $tpld_grp= $this->m_tpld_grp->getRows($sort);
                }
            }else{
              $tpld_grp= $this->m_tpld_grp->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpld_grp
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPLD_GRP.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'cgrpnm', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tpld_grp= $this->m_tpld_grp->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpld_grp
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need instanceid to query.'
            );
        }
        print json_encode($return);
    }
    function getRowsByParent() {
        log_message('debug', 'TPLD_GRP.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'cgrpnm', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tpld_grp= $this->m_tpld_grp->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tpld_grp
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need parent parentid to query.'
            );
        }
        print json_encode($return);
    }
    function deleteRow() {
        log_message('debug', 'TPLD_GRP.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tpld_grpid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tpld_grp->deleteRow($tempId);
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'No  ID to delete'
            );
        }
        print json_encode($return);
    }
    private function _loadModels () {
        $this->load->model('M_tpld_grp', 'm_tpld_grp');
    }
}
?>