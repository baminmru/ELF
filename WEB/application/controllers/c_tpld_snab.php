<?php
	 class C_tpld_snab extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPLD_SNAB.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPLD_SNAB.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tpld_snabid' =>  $this->input->get_post('tpld_snabid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'cname' =>   $this->input->get_post('cname', TRUE)
                ,'caddress' =>   $this->input->get_post('caddress', TRUE)
                ,'cfio' =>   $this->input->get_post('cfio', TRUE)
                ,'cphone' =>   $this->input->get_post('cphone', TRUE)
                ,'cregion' =>   $this->input->get_post('cregion', TRUE)
                ,'supplier' =>   $this->input->get_post('supplier', TRUE)
            );
            $tpld_snab = $this->m_tpld_snab->setRow($data);
            print json_encode($tpld_snab);
    }
    function newRow() {
            log_message('debug', 'TPLD_SNAB.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tpld_snabid' =>  $this->input->get_post('tpld_snabid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'cname' =>   $this->input->get_post('cname', TRUE)
                ,'caddress' =>   $this->input->get_post('caddress', TRUE)
                ,'cfio' =>   $this->input->get_post('cfio', TRUE)
                ,'cphone' =>   $this->input->get_post('cphone', TRUE)
                ,'cregion' =>   $this->input->get_post('cregion', TRUE)
                ,'supplier' =>   $this->input->get_post('supplier', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tpld_snab= $this->m_tpld_snab->newRow($instanceid,$data);
            $return = $tpld_snab;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPLD_SNAB.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tpld_snab = $this->m_tpld_snab->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tpld_snab
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
            	$sort[] = array('property'=>'cname', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tpld_snab= $this->m_tpld_snab->getRowsByInstance($instanceid,$sort);
                }else{
                    $tpld_snab= $this->m_tpld_snab->getRows($sort);
                }
            }else{
              $tpld_snab= $this->m_tpld_snab->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpld_snab
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPLD_SNAB.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'cname', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tpld_snab= $this->m_tpld_snab->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpld_snab
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
        log_message('debug', 'TPLD_SNAB.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'cname', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tpld_snab= $this->m_tpld_snab->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tpld_snab
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
        log_message('debug', 'TPLD_SNAB.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tpld_snabid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tpld_snab->deleteRow($tempId);
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
        $this->load->model('M_tpld_snab', 'm_tpld_snab');
    }
}
?>