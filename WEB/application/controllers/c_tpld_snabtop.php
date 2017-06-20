<?php
	 class C_tpld_snabtop extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPLD_SNABTOP.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPLD_SNABTOP.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tpld_snabtopid' =>  $this->input->get_post('tpld_snabtopid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'cname' =>   $this->input->get_post('cname', TRUE)
                ,'caddress' =>   $this->input->get_post('caddress', TRUE)
                ,'cfio' =>   $this->input->get_post('cfio', TRUE)
                ,'cphone' =>   $this->input->get_post('cphone', TRUE)
                ,'cregion' =>   $this->input->get_post('cregion', TRUE)
            );
            $tpld_snabtop = $this->m_tpld_snabtop->setRow($data);
            print json_encode($tpld_snabtop);
    }
    function newRow() {
            log_message('debug', 'TPLD_SNABTOP.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tpld_snabtopid' =>  $this->input->get_post('tpld_snabtopid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'cname' =>   $this->input->get_post('cname', TRUE)
                ,'caddress' =>   $this->input->get_post('caddress', TRUE)
                ,'cfio' =>   $this->input->get_post('cfio', TRUE)
                ,'cphone' =>   $this->input->get_post('cphone', TRUE)
                ,'cregion' =>   $this->input->get_post('cregion', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tpld_snabtop= $this->m_tpld_snabtop->newRow($instanceid,$data);
            $return = $tpld_snabtop;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPLD_SNABTOP.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tpld_snabtop = $this->m_tpld_snabtop->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tpld_snabtop
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
                    $tpld_snabtop= $this->m_tpld_snabtop->getRowsByInstance($instanceid,$sort);
                }else{
                    $tpld_snabtop= $this->m_tpld_snabtop->getRows($sort);
                }
            }else{
              $tpld_snabtop= $this->m_tpld_snabtop->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpld_snabtop
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPLD_SNABTOP.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
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
            $tpld_snabtop= $this->m_tpld_snabtop->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpld_snabtop
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
        log_message('debug', 'TPLD_SNABTOP.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
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
            $tpld_snabtop= $this->m_tpld_snabtop->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tpld_snabtop
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
        log_message('debug', 'TPLD_SNABTOP.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tpld_snabtopid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tpld_snabtop->deleteRow($tempId);
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
        $this->load->model('M_tpld_snabtop', 'm_tpld_snabtop');
    }
}
?>